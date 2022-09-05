using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace EmployeePayroll
{
    public class EmployeeRepository
    {
        public static string connectionString = @"Data Source=DESKTOP-EPUK1PJ;Initial Catalog=payrolls_service;
                  Integrated Security=True;";
        SqlConnection connection = new SqlConnection(connectionString);
    }
}
