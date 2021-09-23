using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic
{
    public static class EmployeeProcessor
    {
        public static int CreateEmployee(int employeeID, string firstName, string lastName, string emailAddress)
        {
            EmployeeModel data = new EmployeeModel
            {
                EmployeeId = employeeID,
                FirstName = firstName,
                LastName = lastName,
                EmailAddress = emailAddress
            };

            string sql = @"insert into dbo.Employee (EmployeeID, FirstName, LastName, EmailAddress)
                            values (@EmployeeID, @FirstName, @LastName, @EmailAddress)";
            return SqlDataAccess.SaveData(sql, data);
        }
        public static List<EmployeeModel> LoadEmployees()
        {
            string sql = @"select Id, EmployeeID, FirstName, LastName, EmailAddress from dbo.Employee;";
            return SqlDataAccess.LoadData<EmployeeModel>(sql);
        }

        public static string DeleteEmployee(int id)
        {
            string sql = @"delete from dbo.Employee where EmployeeID = "+id;
            return SqlDataAccess.DeleteData(sql);
        }
        public static int UpdateEmployee(int employeeID, string firstName, string lastName, string emailAddress)
        {
            EmployeeModel data = new EmployeeModel
            {
                EmployeeId = employeeID,
                FirstName = firstName,
                LastName = lastName,
                EmailAddress = emailAddress
            };

            string sql = @"update dbo.Employee set EmployeeID = @EmployeeID, FirstName = @FirstName, LastName = @LastName, EmailAddress = @EmailAddress where EmployeeID = @EmployeeID;";

            return SqlDataAccess.SaveData(sql, data);
        }
        


    }
}
