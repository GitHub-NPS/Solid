using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NPS
{
    public class AdapterPatternExercise2 : MonoBehaviour
    {
        public interface IUser
        {
            void setName(string name);
            string getName();
        }

        public class User : IUser
        {
            string name;

            public string getName()
            {
                return name;
            }

            public void setName(string name)
            {
                this.name = name;
            }
        }

        public interface ICustomer
        {
            void setFirstName(string firstName);
            string getFistName();
            void setLastName(string lastName);
            string getLastName();
        }

        public class Customer : ICustomer
        {
            protected string firstName;
            protected string lastName;

            public string getFistName()
            {
                return firstName;
            }

            public string getLastName()
            {
                return lastName;
            }

            public void setFirstName(string firstName)
            {
                this.firstName = firstName;
            }

            public void setLastName(string lastName)
            {
                this.lastName = lastName;
            }
        }

        public class UserToCustomer : Customer 
        {
            private User user;

            public UserToCustomer()
            {

            }

            public UserToCustomer(User user)
            {
                this.user = user;

                var names = user.getName().Split(' ');
                this.firstName = names[0];
                this.lastName = names[1];
            }
        }

        private void Start()
        {
            User user = new User();
            user.setName("Shiba Inu");

            Customer customer = new UserToCustomer(user);
            Debug.Log(customer.getFistName());
            Debug.Log(customer.getLastName());
        }
    }
}