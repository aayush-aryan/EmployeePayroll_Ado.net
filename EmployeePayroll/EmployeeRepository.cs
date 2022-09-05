using System;
using System.Collections.Generic;
using System.Data;
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
        
        /// <summary>
        /// UC2
        /// </summary>
        public void GetAllEmployees()
        {
            EmployeeModel model = new EmployeeModel();
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    string query = @"select * from dbo.employee_payrollN";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
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
                            model.TaxablePay = Convert.ToDouble(sqlDataReader.GetString(8));
                            model.Tax= Convert.ToDouble(sqlDataReader.GetString(9));
                            model.NetPay = Convert.ToDouble(sqlDataReader.GetString(10)); ;
                            model.StartDate = sqlDataReader.GetDateTime(11);
                            model.City = sqlDataReader.GetString(12);
                            model.Country = sqlDataReader.GetString(13);
                            Console.WriteLine("EmpId:{0}\nEmpName:{1}\nPhoneNumber:{2}\nAddress:{3}\nDepartment:{4}\nGender-:{5}\nBasicPay:{6}" +
                                "\nDeductions:{7}\nTaxablePay:{8}\nTax:{9}\nNetPay:{10},\nStartDate:{11}\nCity:{12}\nCountry:{13}",
                                 model.EmployeeID, model.EmployeeName, model.PhoneNumber, model.Address, model.Department, model.Gender,
                                 model.BasicPay, model.Deductions, model.TaxablePay,model.Tax, model.NetPay,
                                 model.StartDate.ToString(), model.City, model.Country);
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
                connection.Close();
            }
        }

        /// <summary>
        /// Adds the employee.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        /// @EmployeeName,@PhoneNumber,@Address,@Department,@Gender,@BasicPay,
        /// @Deductions,@TaxablePay,@Tax,@NetPay,@StartDate,@City,@Country
        /// Adds the employee.
        public bool AddEmployee(EmployeeModel model)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                using (connection)
                {
                    SqlCommand command = new SqlCommand("dbo.SpAddEmployeeDetails", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmployeeName", model.EmployeeName);
                    command.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
                    command.Parameters.AddWithValue("@Address", model.Address);
                    command.Parameters.AddWithValue("@Department", model.Department);
                    command.Parameters.AddWithValue("@Gender", model.Gender);
                    command.Parameters.AddWithValue("@BasicPay", model.BasicPay);
                    command.Parameters.AddWithValue("@Deductions", model.Deductions);
                    command.Parameters.AddWithValue("@TaxablePay", model.TaxablePay);
                    command.Parameters.AddWithValue("@Tax", model.Tax);
                    command.Parameters.AddWithValue("@NetPay", model.NetPay);
                    command.Parameters.AddWithValue("@StartDate", model.StartDate);
                    command.Parameters.AddWithValue("@City", model.City);
                    command.Parameters.AddWithValue("@Country", model.Country);
                    connection.Open();
                    var result = command.ExecuteNonQuery();
                    connection.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
