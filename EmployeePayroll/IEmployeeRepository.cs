using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePayroll
{
    public interface IEmployeeRepository
    {
        EmployeeModel AddEmployee(EmployeeModel model);
        EmployeeModel FindEmployee(int id);
        EmployeeModel DeleteEmployee(int id);
        EmployeeModel UpdateEmployee(EmployeeModel model, int id);
        IEnumerable<EmployeeModel> GetAllEmployeeDetails();
    }
}

