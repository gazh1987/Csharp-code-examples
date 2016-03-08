using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace employeeLab
{
    class Program
    {
        static void Main(string[] args)
        {
            Company ibm = new Company("ibm", "dublin");
            Person jim = new Person("jim", 20, 12000);
            Person mandy = new Person("mandy", 15, 100);

            ibm.hire(mandy);
            mandy.raiseSalary(jim, 0.1f);
            ibm.fire(jim);
            
        }
    }
}
