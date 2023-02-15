using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    internal class Program
    {
        static void PrintList(List<Student> students) {
            foreach (var item in students)
            {
                item.Show();
            }
        }
        static void Main(string[] args)
        {
            int[] marks = new int[] { 34, 45, 67, 75, 90, 89, 96, 93 };
            int[] aplus = new int[marks.Length];
            int count = 0;
            foreach (var item in marks)
            {
                if (item >= 80)
                {
                    aplus[count++] = item;
                }
            }
            var aplus2 = (from item in marks where item >= 80 select item).ToArray();
            List<Student> students = new List<Student>();
            Random rand = new Random();
            for (int i = 1; i <= 100; i++)
            {
                students.Add(new Student()
                {
                    Roll = i,
                    Name = "Student " + i,
                    Marks = rand.Next(10, 100)
                }); ;
            }
            PrintList(students);
            Console.WriteLine("-----------------");
            var marks75 = (from s in students
                           where s.Marks >= 75
                           select s).ToList();
            Console.WriteLine("-------75("+marks75.Count+")---------");
            PrintList(marks75);
            Console.WriteLine("-----------------");
            var marks75110= (from s in students
                             where s.Marks >=75 && s.Roll <=10
                             select s).ToList();
            Console.WriteLine("-------75(" + marks75110.Count + ")---------");
            PrintList(marks75110);
            Console.WriteLine("-----------------");
        }
        
    }
}
