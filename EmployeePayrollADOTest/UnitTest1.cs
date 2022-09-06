using EmployeePayroll;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EmployeePayrollADOTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GivenEmployeeDetailsShouldBeAddedInDatabases()
        {
            EmployeeRepository employeeRepository = new EmployeeRepository();
            EmployeeModel employee = new EmployeeModel();
            employee.EmployeeName = "Aryan";
            employee.PhoneNumber = "88888888888";
            employee.Address = "Delhi";
            employee.Department = "Physics";
            employee.Gender = "M";
            employee.BasicPay = 1420000;
            employee.Deductions = 13000.50;
            employee.TaxablePay = 6000.00;
            employee.Tax = 4200.00;
            employee.NetPay = 86660;
            employee.StartDate = Convert.ToDateTime("2020-11-03");
            employee.City = "New Delhi";
            employee.Country = "India";
            var result = employeeRepository.AddEmployee(employee);
            Assert.IsTrue(result);
        }
    }
}

