using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using DapperExercise1;
//^^^^MUST HAVE USING DIRECTIVES^^^^

var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
string connString = config.GetConnectionString("DefaultConnection");
IDbConnection conn = new MySqlConnection(connString);

var newConn = new DapperDepartmentsRepository(conn);

var department = newConn.GetAllDepartments();

foreach (var item in department)
{
    Console.WriteLine($"DepartmentID {item.DepartmentID} ");
    Console.WriteLine($"Department Name {item.Name}");
    Console.WriteLine();
}

Console.WriteLine("Create a new department:");
var userIn = Console.ReadLine();
newConn.AddDepartment(userIn);

