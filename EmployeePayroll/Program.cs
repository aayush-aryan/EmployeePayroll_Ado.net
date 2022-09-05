using System;

namespace EmployeePayroll
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to EmployeePayroll Ado.net!");
            EmployeeRepository employeeRepository = new EmployeeRepository();
            //employeeRepository.GetAllEmployees();

            EmployeeModel employee = new EmployeeModel();
            employee.EmployeeName = "Aayush";
            employee.PhoneNumber = "9999999999";
            employee.Address = "Kota";
            employee.Department = "Physics";
            employee.Gender = "M";
            employee.BasicPay = 420000;
            employee.Deductions = 1300.50;
            employee.TaxablePay = 5000.00;
            employee.Tax = 200.00;
            employee.NetPay = 36660;
            employee.StartDate = Convert.ToDateTime("2020-11-03");
            employee.City = "Kota";
            employee.Country = "USA";
           employeeRepository.AddEmployee(employee);
            employeeRepository.GetAllEmployees();

        }
    }
}
