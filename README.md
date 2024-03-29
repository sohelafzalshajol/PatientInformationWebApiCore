# PatientInformationWebApiCore
Patient Information Collection Project using ASP.NET WebAPI Core 7 for API and ASP.NET MVC Core 7 for Front-End with Bootstrap 5 and JQuery 3.6

# Architecture Used
- Back end: ASP.NET CORE Web API 7 using C# (PatientInformationPortalWebApi)
- Front-end: ASP.NET CORE MVC 7 using Bootstrap 5 and JQuery 3.6 (PatientInformationPortalView)
- Data Managed: Entity Framework Core to insert, update, delete and display data.
- Code First Approch with Repository Pattern.
- Server: Microsoft SQL Server 2022 (RTM) - 16.0.1000.6 (X64)
  
# How to run
- At first make sure you have the right development environment to run the project.
- Modify the default connection string as per yours at Web API project.
- Run Update Migration Command at Web API project. (Update-Database)
- Build and Run the two projects at a time.
 
# How to use
Here I have given some images to understand the functionality of the project I have developed.
- I have designed a form where I'm taking Patient Name, Disease Name as select dropdown, Epilepsy check as select dropdown, Other NCDs as Multi-Select dropdown with searchable and unique selection checked, Allergies as Multi-Select dropdown with searchable and unique selection checked.
![image](https://github.com/sohelafzalshajol/PatientInformationWebApiCore/assets/70692930/98cfbbef-d11f-4f06-8b1d-3c05be5aae1c)
- For View Details, Update Data and Delete data I have used a table grid to load the list and given actions to every rows.
![image](https://github.com/sohelafzalshajol/PatientInformationWebApiCore/assets/70692930/6ccaa0c7-e227-43e3-9247-ea3b98afc8a3)
- Here is the Database Diagram.
![image](https://github.com/sohelafzalshajol/PatientInformationWebApiCore/assets/70692930/d08e19b2-5064-4f82-a561-7ce2a6f19aa7)
