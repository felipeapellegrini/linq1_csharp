using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using exercise_linq.Entities;
using System.IO;
using System.Globalization;


namespace exercise_linq
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the full file path: ");
            string path = Console.ReadLine();
            Console.WriteLine();

            List<Employee> list = new List<Employee>();

            using (StreamReader sr = File.OpenText(path))
            {
                while (!sr.EndOfStream)
                {
                    string[] fields = sr.ReadLine().Split(',');
                    string name = fields[0];
                    string email = fields[1];
                    double salary = double.Parse(fields[2], CultureInfo.InvariantCulture);
                    list.Add(new Employee(name, email, salary));
                }
            }

            Console.Write("Enter the salary: ");
            double cutSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.WriteLine();

            var r1 = list.Where(e => e.Salary > cutSalary).OrderBy(e => e.Name).Select(e => e.Email);
            Console.WriteLine($"E-mail of people whose salary is greater than {cutSalary}:");
            foreach (string r in r1)
            {
                Console.WriteLine(r);
            }
            Console.WriteLine();

            var r2 = list.Where(e => e.Name[0] == 'M').Sum(e => e.Salary);
            Console.Write("Sum of salary of people whose name starts with 'M': " + r2.ToString("F2", CultureInfo.InvariantCulture));
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
