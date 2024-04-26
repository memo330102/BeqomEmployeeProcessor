using EmployeeProcessor;
using EmployeeProcessor.Abstracts;
using EmployeeProcessor.Interfaces;
using EmployeeProcessor.Services;

IReporter report = new Reporter();

Employee employeeT = new Trainee { Name = "Mehmet", Years = 1, Salary = 1000 };
Employee employeeJ = new Junior { Name = "Ricardo", Years = 1, Salary = 2000 };
Employee employeeS = new Senior { Name = "Dorota", Years = 1, Salary = 3000 };
Employee employeeM = new Manager { Name = "Piotr", Years = 1, Salary = 4000 };

var list = new List<Employee>()
{
    employeeT, employeeJ, employeeS, employeeM
};

/// <summary>
/// Trainee
/// </summary>
//var employeeTrainee = new Trainee();
decimal newSalaryT = employeeT.CalculateNewSalary(employeeT.Years, employeeT.Salary);
Console.WriteLine("Trainee Salary = " + newSalaryT);
Console.WriteLine("-----------------------");
Console.WriteLine(report.GenerateEmployeeReport(employeeT));
Console.WriteLine("-----------------------");

/// <summary>
/// Trainee
/// </summary>
//var employeeJunior = new Junior();
decimal newSalaryJ = employeeJ.CalculateNewSalary(employeeJ.Years, employeeJ.Salary);
Console.WriteLine("Junior Salary = " + newSalaryJ);
Console.WriteLine("-----------------------");
Console.WriteLine(report.GenerateEmployeeReport(employeeJ));
Console.WriteLine("-----------------------");

/// <summary>
/// Senior
/// </summary>
//var employeeSenior = new Senior();
decimal newSalaryS = employeeS.CalculateNewSalary(employeeS.Years, employeeS.Salary);
Console.WriteLine("Senior Salary = " + newSalaryS);
Console.WriteLine("-----------------------");
Console.WriteLine(report.GenerateEmployeeReport(employeeS));
Console.WriteLine("-----------------------");

/// <summary>
/// Senior
/// </summary>
//var employeeManager = new Manager();
decimal newSalaryM = employeeM.CalculateNewSalary(employeeM.Years, employeeM.Salary);
Console.WriteLine("Manager Salary = " + newSalaryM);
Console.WriteLine("-----------------------");
Console.WriteLine(report.GenerateEmployeeReport(employeeM));
Console.WriteLine("-----------------------");

/// <summary>
/// All Employees Report
/// </summary>
var reports = report.GenerateReport(list);
Console.WriteLine(reports);
