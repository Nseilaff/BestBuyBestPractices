using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MySql.Data.MySqlClient;
namespace BestBuyBestPractices
{
    public class DapperDepartmentsReopsitory
    {
        private readonly IDbConnection _connection;
        //Constructor
        public DapperDepartmentsReopsitory(IDbConnection connection)
        {
            _connection = connection;
        }

        public void AddDepartment(string newDep)
        {
            _connection.Execute("INSERT INTO DEPARTMENTS (Name) VALUES (@departmentName);",
         new { departmentName = newDep });
        }

        public IEnumerable<Departments> GetAllDepartments()
        {
            return _connection.Query<Departments>("SELECT * FROM Departments;");
        }
    }
}
