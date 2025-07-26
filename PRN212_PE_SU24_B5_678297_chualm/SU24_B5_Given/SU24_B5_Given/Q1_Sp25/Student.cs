using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1_Sp25
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public Student(int id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }
        public Student()
        {
        }
        public void Display()
        {
            Console.WriteLine($"Student: ID: {Id} - Name: {Name} - Age: {Age}");
        }
    }
}
