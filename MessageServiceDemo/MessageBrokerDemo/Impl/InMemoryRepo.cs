using MessageBrokerDemo.Interfaces;
using MessageBrokerDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageBrokerDemo.Impl
{
    public  class InMemoryRepo :IRepo
    {
        private Dictionary<int, Employee> EmployeeData;
        private static IRepo INSTANCE = null;

        public static IRepo getInstance()
        {
            if (INSTANCE == null)
                INSTANCE = new InMemoryRepo();
            return INSTANCE;
        }
        public Employee CreateEmp(Employee employee)
        {
            var keyList = EmployeeData.Keys.ToList();
            int nextEmpID = keyList.Count + 1;
            if (EmployeeData.ContainsKey(nextEmpID))
            {
                Employee temp = EmployeeData[nextEmpID];
                temp.EmpName = employee.EmpName;
                temp.PhoneNumber = employee.PhoneNumber;

            }
            else
            {
                employee.EmployeeID = nextEmpID;
                EmployeeData.Add(nextEmpID, employee);
            }
            return employee;

        }

        public Employee Read(int id)
        {
            var keyList = EmployeeData.Keys.ToList();
            int nextEmpID = keyList.Count + 1;
            if (EmployeeData.ContainsKey(id))
            {
                return EmployeeData[id];
            }
            else
            {
                return EmployeeData[EmployeeData.Keys.ToList()[0]];
            }
        }

        public Employee DeleteEmp(int id)
        {
            var keyList = EmployeeData.Keys.ToList();
            int nextEmpID = keyList.Count + 1;
            Employee emp = null;
            if (EmployeeData.ContainsKey(id))
            {
                emp = EmployeeData[id];
                EmployeeData.Remove(id);
            }
            return emp;
            
        }
        public int EmpCount
        {
            get
            {
                return EmployeeData.Keys.Count();
            }
        }
        private InMemoryRepo()
        {
            EmployeeData = new Dictionary<int, Employee>();
        }
    }
}
