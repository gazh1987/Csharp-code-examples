using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace employeeLab
{
    class Person
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int age;
        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        private float salary;
        public float Salary
        {
            get { return salary; }
            set { salary = value; }
        }

        public Person(string name, int age, float salary)
        {
            this.name = name;
            this.age = age;
            this.salary = salary;
        }

        public void raiseSalary(Person person, float rate)
        {
            if (person.age > 18)
            {
                person.salary *= (1 + rate);
                Console.WriteLine(person.Name + " new salary is " + person.salary);
            }
            else
            {
                Console.WriteLine(person.name + " is not allowed have a raise as s/he is not over 18");
            }
        }
    }
}
