using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeePayroll
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public readonly UserDbContext context;
        public EmployeeRepository(UserDbContext dbContext)
        {
            context = dbContext;
        }
        public EmployeeModel AddEmployee(EmployeeModel model)
        {
            EmployeeModel employeeModel = new EmployeeModel()
            {
                EmployeeName = model.EmployeeName,
                PhoneNumber = model.PhoneNumber,
                Address = model.Address,
                Department = model.Department,
                Gender = model.Gender,
                BasicPay = model.BasicPay,
                Deductions = model.Deductions,
                TaxablePay = model.TaxablePay,
                Tax = model.Tax,
                NetPay = model.NetPay,
                City = model.City,
                Country = model.Country
            };
            this.context.Employees.Add(employeeModel);
            this.context.SaveChangesAsync();
            return employeeModel;
        }
        public EmployeeModel FindEmployee(int id)
        {
            EmployeeModel employee = this.context.Employees.Where<EmployeeModel>(selectedEmployee => selectedEmployee.EmployeeID == id).FirstOrDefault();
            return employee;

        }
        public EmployeeModel DeleteEmployee(int id)
        {
            var employee = this.FindEmployee(id);
            if (employee != null)
            {
                this.context.Employees.Remove(employee);
                this.context.SaveChanges();
            }
            return employee;
        }
        public EmployeeModel UpdateEmployee(EmployeeModel model, int id)
        {
            EmployeeModel employee = this.context.Employees.Where<EmployeeModel>(selectedEmployee => selectedEmployee.EmployeeID == id).FirstOrDefault();
            if (employee != null)
            {
                employee.EmployeeName = model.EmployeeName;
                employee.PhoneNumber = model.PhoneNumber;
                employee.Address = model.Address;
                employee.Department = model.Department;
                employee.Gender = model.Gender;
                employee.BasicPay = model.BasicPay;
                employee.Deductions = model.Deductions;
                employee.TaxablePay = model.TaxablePay;
                employee.Tax = model.Tax;
                employee.NetPay = model.NetPay;
                employee.City = model.City;
                employee.Country = model.Country;
                this.context.Employees.Update(employee);
                this.context.SaveChangesAsync();
            }
            return model;
        }
        public IEnumerable<EmployeeModel> GetAllEmployeeDetails()
        {
            var employees = this.context.Employees.ToList<EmployeeModel>();
            return employees;
        }
    }
}
