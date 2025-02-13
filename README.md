# Employee Management and HTML Tag Validation

## Introduction
This repository contains two .NET solutions for a college project:
1. **Employee Management System**
2. **HTML Tag Validation**

## Solution A: Employee Management System

### Overview
This application manages employee data by reading information from a text file and sorting it based on various employee parameters. It demonstrates basic usage of object-oriented principles, such as classes, properties, and methods in C#. The sorting algorithm used is Insertion Sort, and employees can be sorted by attributes such as name, number, pay rate, hours worked, and gross pay.

### Features
- Employee class with properties for Name, Number, Rate, Hours, and Gross.
- Sorting options:
  - Sort by Employee Name (ascending)
  - Sort by Employee Number (ascending)
  - Sort by Employee Pay Rate (descending)
  - Sort by Employee Hours Worked (descending)
  - Sort by Employee Gross Pay (descending)
- Data is read from a `employees.txt` file containing employee information.
- The program uses Insertion Sort to sort the employee data.
- Interactive user interface to select sorting options.

### How to Run
1. Ensure `.NET` is installed on your system.
2. Clone the repository and navigate to the project directory.
3. Change the test data if necessary. Or use the one provided.
4. Open the solution in Visual Studio.
5. Build and run the project.

---

## Solution B: HTML Tag Validation

### Overview
The HTML Tag Checker is a simple Windows Forms application designed to load and check HTML files for balanced tags. It enables users to load an HTML file, view the content of the tags, and verify if the tags in the document are properly balanced. This project demonstrates the use of regular expressions for HTML tag extraction and handling basic file operations in a .NET environment.

### Features
- **Load HTML Files**: Allows users to load HTML files using a file dialog.
- **Tag Checking**: Identifies and checks whether HTML tags are balanced in the loaded document.
- **Tag Type Identification**: Categorizes tags as opening, closing, or non-container tags (e.g., `<br>`, `<hr>`, `<img>`).
- **User Interface**: Displays the loaded file’s status and tag information in a list box.

### How to Run
1. Ensure `.NET` is installed on your system.
2. Clone the repository and navigate to the project directory.
3. Open the solution in Visual Studio.
4. The test data is provided in the project's folder.
5. Build and run the project.
6. Use the form to load an HTML file and validate the tags.

---
## Sample Output
### Solution A:
![image](https://github.com/user-attachments/assets/c21addd4-4e8f-46ab-9b16-b304dd926a2b)

### Solution B:
![image](https://github.com/user-attachments/assets/ebdc9421-c3b0-4f83-9e8a-1e5e47d08137)

![image](https://github.com/user-attachments/assets/1873a02e-2017-4fd8-92b8-544f540e6288)

## License
This project is for educational purposes.
