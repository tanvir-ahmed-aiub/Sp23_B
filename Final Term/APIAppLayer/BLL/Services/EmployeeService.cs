using BLL.DTOs;
using DAL;
using DAL.Models;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class EmployeeService
    {
        public static List<EmployeeDTO> Get() {
            var data = DataAccessFactory.EmployeeData().Get();
            return Convert(data);
        }
        public static List<EmployeeDTO> Get10() {
            var emps = DataAccessFactory.EmployeeData().Get();
            var data = from e in emps
                       where e.Id < 11
                       select e;
            return Convert(data.ToList());
        }
        public static EmployeeDTO Get(int id) { 
            var data = DataAccessFactory.EmployeeData().Get(id);
            return Convert(data);
        }
        public static bool Insert(EmployeeDTO employee) {
            var data = Convert(employee);
            return DataAccessFactory.EmployeeData().Insert(data);
        }
        public static bool Update(Employee employee) { 
            return DataAccessFactory.EmployeeData().Update(employee);
        }
        public static bool Delete(int id) {
            return DataAccessFactory.EmployeeData().Delete(id);
        }
        static EmployeeDTO Convert(Employee employee) {
            return new EmployeeDTO() { 
                Id = employee.Id,
                Name = employee.Name
            };
        }
        static Employee Convert(EmployeeDTO employee)
        {
            return new Employee()
            {
                Id = employee.Id,
                Name = employee.Name
            };
        }
        static List<EmployeeDTO> Convert(List<Employee> employees) {
            var data = new List<EmployeeDTO>();
            foreach (var employee in employees) {
                data.Add(Convert(employee));
            }
            return data;
        }
    }
}
