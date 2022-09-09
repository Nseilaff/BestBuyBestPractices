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
Console.WriteLine("Enter New Product: ");
var name = Console.ReadLine();
Console.WriteLine("Enter Price");
var price = double.Parse(Console.ReadLine());
Console.WriteLine("Enter Category ID");
var id = int.Parse(Console.ReadLine());
foreach (var item in product)
{
    Console.WriteLine($"Name: {item.Name}");
    Console.WriteLine($"Price: {item.Price}");
    Console.WriteLine($"Category: {item.CategoryID}");
    Console.WriteLine();
}