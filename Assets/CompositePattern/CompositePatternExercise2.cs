using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NPS
{
    public class CompositePatternExercise2 : MonoBehaviour
    {
        private void Start()
        {
            Developer dev1 = new Developer("Lokesh Sharma");
            Developer dev2 = new Developer("Vinay Sharma");

            CompanyDirectory engDirectory = new CompanyDirectory();
            engDirectory.AddEmp(dev1);
            engDirectory.AddEmp(dev2);

            Manager man1 = new Manager("Kushagra Garg");
            Manager man2 = new Manager("Vikram Sharma ");

            CompanyDirectory accDirectory = new CompanyDirectory();
            accDirectory.AddEmp(man1);
            accDirectory.AddEmp(man2);

            CompanyDirectory directory = new CompanyDirectory();
            directory.AddEmp(engDirectory);
            directory.AddEmp(accDirectory);
            directory.Detail();
        }

        public interface IEmployee
        {
            public void Detail();
        }

        public class Developer : IEmployee
        {
            private string name;

            public Developer()
            {

            }

            public Developer(string name)
            {
                this.name = name;
            }

            public void Detail()
            {
                Debug.Log("Developer: " + name);
            }
        }

        public class Manager : IEmployee
        {
            private string name;

            public Manager()
            {

            }

            public Manager(string name)
            {
                this.name = name;
            }

            public void Detail()
            {
                Debug.Log("Manager: " + name);
            }
        }

        public class CompanyDirectory : IEmployee
        {
            private List<IEmployee> employee = new List<IEmployee>();

            public void Detail()
            {
                foreach (var emp in employee)
                {
                    emp.Detail();
                }
            }

            public void AddEmp(IEmployee emp)
            {
                employee.Add(emp);
            }

            public void RemoveEmp(IEmployee emp)
            {
                employee.Remove(emp);
            }
        }
    }
}