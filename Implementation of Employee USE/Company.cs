using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace employeeLab
{
    class Company
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string location;
        public string Location
        {
            get { return location; }
            set { location = value; }
        }

        private IList<Person> employeeList;
        internal IList<Person> EmployeeList
        {
            get { return employeeList; }
            set { employeeList = value; }
        }

        public Company(string name, string location)
        {
            this.name = name;
            this.location = location;
            this.employeeList = new List<Person>();
        }

        public void hire(Person person)
        {
            bool found = false;
            foreach (Person p in employeeList)
            {
                if (p == person)
                {
                    Console.WriteLine(p.Name + " is already an employee");
                    found = true;
                    break;
                }
            }
            if (found == false)
            {
                employeeList.Add(person);
                Console.WriteLine(person.Name + " is now an employee");
            }
        }

        public void fire(Person person)
        {
            bool found = false;
            foreach (Person p in employeeList)
            {
                if (p == person)
                {
                    found = true;
                    break;
                }
            }
            if (found == true)
            {
                employeeList.Remove(person);
                Console.WriteLine(person.Name + " has been deleted from the database");
            }
            else
            {
                Console.WriteLine(person + "is not a member of the company");
            }
        }


    }
}
