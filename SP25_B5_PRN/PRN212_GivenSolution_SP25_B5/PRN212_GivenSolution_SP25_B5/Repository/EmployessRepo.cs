using Q2_DataAcess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    
public class EmployessRepo
    {
        PePrn21225sprB5Context _context;

        public EmployessRepo()
        {
            _context = new();
        }

        public void Create(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public List<Employee> GetAll()
        {
            return _context.Employees.ToList();
        }

        public void Update(Employee employee)
        {
            var existingEmployee = _context.Employees.FirstOrDefault(e => e.Id == employee.Id);
            if (existingEmployee != null)
            {
                existingEmployee.Name = employee.Name;
                existingEmployee.Sex = employee.Sex;
                existingEmployee.Dob = DateOnly.FromDateTime(employee.Dob.ToDateTime(new TimeOnly(0, 0))); // Convert DateTime back to DateOnly
                existingEmployee.Position = employee.Position;

                _context.SaveChanges();
            }
        }
    }
}
