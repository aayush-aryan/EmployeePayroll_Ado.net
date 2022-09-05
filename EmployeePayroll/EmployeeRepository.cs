using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace EmployeePayroll
{
    public class EmployeeRepository
    {
        /// <summary>
        /// UC1
        /// creating database Connections;
        /// </summary>
        public static string connectionString = @"Data Source=DESKTOP-EPUK1PJ;Initial Catalog=payrolls_service;
                                                    Integrated Security=True;";
        SqlConnection connection = new SqlConnection(connectionString);
        /// <summary>
        /// UC2
        /// </summary>
        public void GetAllEmployees()
        {
            EmployeeModel model = new EmployeeModel();
            try
            {
                using (connection)
                {
                    string query = @"select * from dbo.employee_payrollN";
                    SqlCommand command = new SqlCommand(query, connection);
                    this.connection.Open();
                    SqlDataReader sqlDataReader = command.ExecuteReader();
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            model.EmployeeID = sqlDataReader.GetInt32(0); //ToInt32(sqlDataReader["EmployeeID"]);
                            model.EmployeeName = sqlDataReader.GetString(1);//Convert.ToString(sqlDataReader["EmployeeName"]
                            model.PhoneNumber = sqlDataReader.GetString(2);
                            model.Address = sqlDataReader.GetString(3);
                            model.Department = sqlDataReader.GetString(4);
                            model.Gender = sqlDataReader.GetString(5);
                            model.BasicPay = Convert.ToDouble(sqlDataReader.GetString(6));
                            model.Deductions = Convert.ToDouble(sqlDataReader.GetString(7));
                            model.TaxablePay = Convert.ToDouble(sqlDataReader.GetString(8)); ;
                            model.Income_Tax = Convert.ToDouble(sqlDataReader.GetString(9)); ;//Tax as column name
                            model.NetPay = Convert.ToDouble(sqlDataReader.GetString(10)); ;
                            model.StartDate = sqlDataReader.GetDateTime(11);
                            model.City = sqlDataReader.GetString(12);
                            model.Country = sqlDataReader.GetString(13);
                            Console.WriteLine("EmpId:{0}\nEmpName:{1}\nPhoneNumber:{2}\nAddress:{3}\nDepartment:{4}\nGender-:{5}\nBasicPay:{6}" +
                                "\nDeductions:{7}\nTaxablePay:{8}\nIncomeTax:{9}\nNetPay:{10},\nStartDate:{11}\nCity:{12}\nCountry:{13}",
                                 model.EmployeeID, model.EmployeeName, model.PhoneNumber, model.Address, model.Department, model.Gender,
                                 model.BasicPay, model.Deductions, model.TaxablePay, model.Income_Tax, model.NetPay,
                                 model.StartDate, model.City, model.Country);
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }
                    sqlDataReader.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                this.connection.Close();
            }
        }
    }
}
