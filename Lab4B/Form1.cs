using HtmlAgilityPack;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lab4B
{
    public partial class Form1 : Form
    {
        Stack<string> fileContent = new Stack<string>();
        private string filePath;

        /// <summary>
        /// Initializes a new instance of the Form1 class.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the Load menu item.
        /// Loads the content of an HTML file into the application.
        /// </summary>
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "HTML files | *.html";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = System.IO.Path.GetFileName(openFileDialog.FileName);

                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        while (!reader.EndOfStream)
                        {
                            fileContent.Push(reader.ReadLine());
                        }
                    }
                }
            }

            if (fileContent.Count > 0)
            {
                label.Text = "File Loaded: " + filePath;

                checkToolStripMenuItem.Enabled = true;
            }
        }

        /// <summary>
        /// Handles the Click event of the Check menu item.
        /// Checks whether the loaded HTML file has balanced tags.
        /// </summary>
        private void checkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox.Items.Clear();

            bool balanced = true;
            Stack<string> balancedCheckList = new Stack<string>();

            Stack<string> newFileContent = new Stack<string>();


            foreach (string line in fileContent)
            {
                newFileContent.Push(line);
            }

            while (newFileContent.Count > 0)
            {
                string item = newFileContent.Pop().Trim();

                if (item.Length > 0)
                {
                    MatchCollection regex = Regex.Matches(item, "<.+?>");

                    if (regex.Count > 1)
                    {
                        foreach (Match match in regex)
                        {
                            balancedCheckList = AddListItem(match.ToString(), balancedCheckList);
                        }
                    }
                    else
                    {
                        balancedCheckList = AddListItem(regex[0].ToString(), balancedCheckList);
                    }
                }
            }

            if (balancedCheckList.Count > 0)
            {
                balanced = false;
            }

            if (balanced)
            {
                label.Text = filePath + " has balanced tags";
            }
            else
            {
                label.Text = filePath + " does not have balanced tags";
            }
        }

        /// <summary>
        /// Handles the Click event of the Exit menu item.
        /// Closes the application.
        /// </summary>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Identifies the type of HTML tag based on its format.
        /// </summary>
        /// <param name="tag">The HTML tag to identify.</param>
        /// <returns>A string indicating the type of HTML tag.</returns>
        public string IdentifyHtmlTag(string tag)
        {
            if (Regex.Match(tag, "^<(br|hr|img.+)>$").Success)
            {
                return "Found non-container tag: " + ExtractTagName(tag);
            }
            else if (Regex.Match(tag, "^</.+>$").Success)
            {
                return "Found closing tag: " + ExtractTagName(tag);
            }
            else
            {
                return "Found opening tag: " + ExtractTagName(tag);
            }
        }

        /// <summary>
        /// Adds an HTML tag to the list and updates the balanced check list.
        /// </summary>
        /// <param name="item">The HTML tag to add.</param>
        /// <param name="list">The current balanced check list.</param>
        /// <returns>The updated balanced check list.</returns>
        public Stack<string> AddListItem(string item, Stack<string> list)
        {
            listBox.Items.Add(IdentifyHtmlTag(item));

            if (!Regex.Match(item, "^<(br|hr|img.+)>$").Success)
            {
                if (Regex.Match(item, "^</.+>$").Success)
                {
                    if (list.Peek() == ExtractTagName(item))
                    {
                        list.Pop();
                    }
                }
                else if (Regex.Match(item, "^<.+>$").Success)
                {
                    list.Push(ExtractTagName(item));
                }
            }

            return list;
        }

        /// <summary>
        /// Extracts the tag name from an HTML tag.
        /// </summary>
        /// <param name="tag">The HTML tag.</param>
        /// <returns>The extracted tag name.</returns>
        public string ExtractTagName(string tag)
        {
            return Regex.Replace(tag, @"(\s[^>]*>|<|<|>|/)", "").ToLower();
        }
    }
}
