using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using BestBuyBestPractices;
using System.Collections.Generic;
//^^^^MUST HAVE USING DIRECTIVES^^^^

var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
string connString = config.GetConnectionString("DefaultConnection");
IDbConnection conn = new MySqlConnection(connString);

var newConn = new DapperDepartmentsReopsitory(conn);

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

var newPro = new DapperProductRepository(conn);

var product = newPro.GetAllProducts();

foreach (var item in product)
{
    Console.WriteLine($"{item.Name}");
    Console.WriteLine($"{item.Price}");
    Console.WriteLine($"{item.CategoryID}");
    Console.WriteLine();
}