# ArmyManagementSystem

The ArmyManagementSystem is a comprehensive solution designed for the Hellenic Army. It offers a centralized platform for personnel management and efficient handling of leave requests. It provides statistical analysis and data visualization features to facilitate effective workforce planning and resource allocation.

## Table of Contents

- [Project Overview](#project-overview)
- [Features](#features)
- [Usage](#usage)
- [Technologies Used](#technologies-used)

## Project Overview

The ArmyManagementSystem is a comprehensive solution designed for the Hellenic Army that encompasses personnel management and leave request operations. It provides statistical analysis and visualization of leave requests, allowing effective leave allocation management.

The system includes features such as personnel management, CRUD operations for personnel data, and leave request management. It enables users to track and manage personnel details, including personal information, roles, and leave entitlements.

Key Features:

- Personnel Management: Maintain a centralized database of personnel information, including personal details, roles, and leave entitlements.
- CRUD Operations: Create, retrieve, update, and delete personnel records and leave requests, providing full control and flexibility over data management.
- Statistical Analysis: Gain insights into leave utilization and patterns through statistical analysis and data visualization.

The ArmyManagementSystem is developed using C#, ASP.NET Core, Entity Framework, and JavaScript libraries such as CanvasJS for data visualization. The system is designed in Greek to cater specifically to the needs and requirements of the Hellenic Army.

## Features

### Personnel Management

- Maintain a centralized database of personnel information, including personal details, roles, and leave entitlements.
- Perform CRUD (Create, Read, Update, Delete) operations for personnel records.
- Easily search and filter personnel based on various criteria such as name or rank.
- View comprehensive personnel profiles with detailed information and leave history.

### Leave Request Management

- Log and track all leave requests submitted by personnel.
- Capture essential details such as the requested dates, leave type, and personnel information.
- Maintain a comprehensive and searchable log of all approved leave requests.
- Keep a record of historical leave data for reference and reporting purposes.

### Statistical Analysis and Reporting

- Gain valuable insights into leave utilization and patterns through comprehensive statistical analysis.
- Generate monthly, weekly, and daily leave request counts to identify trends and patterns.
- Visualize leave request data using charts and graphs for easy interpretation.
- Analyze leave type distribution to understand the proportion of different leave categories.
- Explore maximum, minimum, and average leave durations for effective leave planning.

### Greek Language Support

- The system is designed in Greek to cater specifically to the needs and requirements of the Hellenic Army.
- Personnel can interact with the system using Greek language interfaces.
- All system messages, labels, and notifications are displayed in Greek for enhanced usability.


## Usage

![](../screenshots/ams_home.png)

1. Managing Personnel

	- Navigate to the "Personnel" ("Προσωπικό") section to manage personnel records.
	
		![](../screenshots/ams_staff_index.png)
	- Click the appropriate icons to view the details of a personnel record, edit their details or delete it.
   - Create a new personnel profile by clicking on the "Create" ("Δημιουργία") button.
   - Fill in the required details such as name, rank, and contact info.
		
		![](../screenshots/ams_staff_create.png)
   - Click "Create" ("Δημιουργία") to add the personnel record to the system.   
	
2. Managing Leave Requests

   - Navigate to the "Personnel" ("Προσωπικό") section.
   - Search for a personnel record and click on their "Details" ("Λεπτομέρειες") icon (light blue button). 
   - Click the "View" ("Προβολή") button next to the "Leave Requests" ("Άδειες") text.
		
		![](../screenshots/ams_staff_details.png)
	- At the top of the page you can see the total number of the current year's leave requests by leave type for a particular personnel record. At the bottom you can see the personnel record's leave request history with information on each leave request.
		
		![](../screenshots/ams_leave_index.png)	
	- Click the "Delete" ("Διαγραφή") icon to delete a leave request from the personnel record's leave request history.
	- Click "Insert" ("Εισαγωγή") to insert a new leave request to the personnel record's history.
	- Fill in the required leave request details.
	
		![](../screenshots/ams_leave_create.png)
	- Click "Insert" ("Εισαγωγή") to add the leave request record to the system. 

3. Statistical Analysis

   - Navigate to the "Statistics" ("Στατιστικά") section to access various statistical reports and charts about leave requests for the current year.
			
		![](../screenshots/ams_stats_index.png)
   - Use the selector to view monthly ("Ανά μήνα"), weekly ("Ανά εβδομάδα"), and daily ("Ανά ημέρα") leave request counts in graphical form.
	
		![](../screenshots/ams_by_month.png)
		![](../screenshots/ams_by_week.png)
		![](../screenshots/ams_by_day.png)
   - Analyze the distribution of leave types using the pie chart.
   - View the minimum, maximum and average leave days requested for the year in the corresponding cards.

## Technologies Used

- **ASP.NET Core**: The web application framework used to develop the system, providing a robust and scalable foundation for building web-based applications.

- **C#**: The programming language used in conjunction with ASP.NET Core to write the backend logic and handle server-side operations.

- **Entity Framework Core**: The object-relational mapping (ORM) framework used for data access and management, providing an intuitive and efficient way to interact with the database.

- **HTML/CSS**: The standard markup and styling languages used for structuring and presenting the user interface of the system, ensuring a visually appealing and user-friendly experience.

- **JavaScript**: The programming language used to enhance the interactivity and functionality of the system, enabling dynamic client-side behavior and AJAX requests.

- **Bootstrap**: The front-end CSS framework utilized to create responsive and mobile-friendly designs, facilitating consistent and visually appealing layouts across different devices.

- **SQL Server**: The relational database management system used to store and manage the system's data, ensuring data integrity and providing efficient querying capabilities.

- **CanvasJS**: The JavaScript charting library employed to create interactive and visually appealing charts and graphs for displaying statistical data in the system.

- **Git**: The version control system utilized to track changes in the source code, enabling collaboration, version management, and easy deployment of the system.

- **GitHub**: The web-based hosting service used for version control and code repository, facilitating project management, collaboration, and easy deployment to production environments.

- **Visual Studio**: The integrated development environment (IDE) used for coding, debugging, and testing the system, providing a comprehensive set of tools for ASP.NET Core development.