using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NPS
{
    public class CompositePatternExercise3 : MonoBehaviour
    {
        private void Start()
        {
            Employee CEO = new Employee("John");
            Employee headSales = new Employee("Robert");
            Employee headMarketing = new Employee("Michel");

            Employee clerk1 = new Employee("Laura");
            Employee clerk2 = new Employee("Bob");

            Employee salesExecutive1 = new Employee("Richard");
            Employee salesExecutive2 = new Employee("Rob");

            CEO.Add(headSales);
            CEO.Add(headMarketing);

            headSales.Add(salesExecutive1);
            headSales.Add(salesExecutive2);

            headMarketing.Add(clerk1);
            headMarketing.Add(clerk2);

            Debug.Log(CEO);

            foreach (Employee headEmployee in CEO.GetSubordinates())
            {
                Debug.Log(headEmployee);

                foreach (Employee employee in headEmployee.GetSubordinates())
                {
                    Debug.Log(employee);
                }
            }
        }

        public class Employee
        {
            private string name;
            private List<Employee> subordinates = new List<Employee>();

            public Employee()
            {

            }

            public Employee(string name)
            {
                this.name = name;
            }

            public List<Employee> GetSubordinates()
            {
                return subordinates;
            }

            public void Add(Employee employee)
            {
                subordinates.Add(employee);
            }

            public void Remove(Employee employee)
            {
                subordinates.Remove(employee);
            }

            public override string ToString()
            {
                return "Name: " + name;
            }
        }
    }
}
