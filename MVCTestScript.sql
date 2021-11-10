Create Database OfficeManagment

Use OfficeManagment

Create Table Department_tb
(
Id Int primary key Identity(1,1),
Name nvarchar(50)
)


Insert into Department_tb (Name) Values ('HR')
Insert into Department_tb (Name) Values ('Finance')
Insert into Department_tb (Name) Values ('IT')


Create table Employee_tb
(
Id Int primary key Identity(1,1),
Name nvarchar(50) NOT NULL,
HireDate datetime NOT NULL,
Email nvarchar(50) NOT NULL,
DepartmentId INT NOT NULL
)

Alter Table Employee_tb
Add FOREIGN KEY (DepartmentId) REFERENCES Department_tb(Id)

Insert into Employee_tb (Name,HireDate,Email,DepartmentId) Values ('Aslam',GETDATE(),'aslma@gmail.com',1)
Insert into Employee_tb (Name,HireDate,Email,DepartmentId) Values ('Nijju',GETDATE(),'nijju@gmail.com',2)
Insert into Employee_tb (Name,HireDate,Email,DepartmentId) Values ('Shahdil',GETDATE(),'shahdil@gmail.com',2)
Insert into Employee_tb (Name,HireDate,Email,DepartmentId) Values ('Hina',GETDATE(),'hina@gmail.com',3)


Create proc sp_GetEmployeeByDepartment
(
@deptName nvarchar(50) = 'Finance' -- 'in replace of test'

)

AS 
BEGIN
Select E.* from Employee_tb E 
Inner join Department_tb D on E.DepartmentId = D.Id
Where D.Name = @deptName
END




