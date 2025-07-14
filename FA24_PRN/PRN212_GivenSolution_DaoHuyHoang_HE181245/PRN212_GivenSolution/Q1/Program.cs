//using System;
//using System.Collections.Generic;

//namespace Q1
//{
//    public delegate void Notify();

//    public interface IItem
//    {
//        void Display();
//    }

//    public interface ICustomList
//    {
//        void Add(IItem item);
//        void DisplayList();
//    }

//    public class Student : IItem
//    {
//        public int Id { get; set; }
//        public string? Name { get; set; }
//        public DateOnly Dob { get; set; }

//        public Student() { }

//        public Student(int id, string? name, DateOnly dob)
//        {
//            Id = id;
//            Name = name;
//            Dob = dob;
//        }

//        public void Display()
//        {
//            Console.WriteLine($"Student: {Id} - {Name} - {Dob.ToString("M/d/yyyy")}");
//        }
//    }

//    public class Teacher : IItem
//    {
//        public int Id { get; set; }
//        public string? Name { get; set; }
//        public string? Skill { get; set; }

//        public Teacher() { }

//        public Teacher(int id, string? name, string? skill)
//        {
//            Id = id;
//            Name = name;
//            Skill = skill;
//        }

//        public void Display()
//        {
//            Console.WriteLine($"Teacher: {Id} - {Name} - {Skill}");
//        }
//    }

//    public class MemberList : ICustomList
//    {
//        private List<IItem> items = new List<IItem>();
//        public int MaximumNumberOfMember { get; set; }
//        public event Notify? OnFullOfMember;

//        public void Add(IItem item)
//        {
//            if (items.Count >= MaximumNumberOfMember)
//            {
//                OnFullOfMember?.Invoke();
//                return;
//            }

//            items.Add(item);
//            Console.WriteLine("Added successfully");
//        }

//        public void DisplayList()
//        {
//            foreach (var item in items)
//            {
//                item.Display();
//            }
//        }
//    }

//    internal class Program
//    {
//        private static void Main(string[] args)
//        {
//            Teacher teacher = new Teacher { Id = 1, Name = "Teacher 1", Skill = ".Net" };
//            Student student1 = new Student { Id = 2, Name = "Student A", Dob = new DateOnly(2000, 12, 23) };
//            Student student2 = new Student { Id = 3, Name = "Student B", Dob = new DateOnly(2000, 5, 16) };

//            MemberList memberList = new MemberList();
//            memberList.MaximumNumberOfMember = 3;
//            memberList.OnFullOfMember += OnFullOfMemberNotify;

//            memberList.Add(student1);
//            memberList.Add(student2);
//            memberList.Add(teacher);

//            Console.WriteLine("List of member:");
//            memberList.DisplayList();

//            Console.WriteLine();

//            MemberList customList = new MemberList();
//            customList.MaximumNumberOfMember = 3;
//            customList.OnFullOfMember += OnFullOfMemberNotify;

//            customList.Add(new Student { Id = 4, Name = "Student C", Dob = new DateOnly(2000, 12, 25) });
//            customList.Add(new Student { Id = 5, Name = "Student D", Dob = new DateOnly(2000, 12, 25) });

//            Console.WriteLine("List of member:");
//            customList.DisplayList();
//        }

//        private static void OnFullOfMemberNotify()
//        {
//            Console.WriteLine("The member list is full");
//        }
//    }
//}

namespace Q1;
internal class Program
{
    public  delegate void Notify();
 private static void Main(string[] args)
{
    // 🧑‍🏫 Khởi tạo giáo viên và học sinh
    Teacher teacher = new Teacher { Id = 1, Name = "Teacher 1", Skill = ".Net" };
    Student student1 = new Student { Id = 2, Name = "Student A", Dob = new DateOnly(2000, 12, 23) };
    Student student2 = new Student { Id = 3, Name = "Student B", Dob = new DateOnly(2000, 5, 16) };
        //Student student3 = new Student { Id = 4, Name = "Student C", Dob = new DateOnly(2000, 12, 25) };
        //Student student4 = new Student { Id = 5, Name = "Student D", Dob = new DateOnly(2000, 12, 25) };

        // 🧑‍🏫 MemberList 1
        MemberList memberList = new MemberList();
    memberList.MaximumNumberOfMember = 3;
    memberList.OnFullOfMember += OnFullOfMemberNotify;

    memberList.Add(student1); // ✅ Added successfully
    memberList.Add(student2);
    memberList.Add(teacher);  // ✅ đủ 3 thành viên

    Console.WriteLine();
    Console.WriteLine("List of member:");
    memberList.DisplayList();

    Console.WriteLine();

    // 👨‍🎓 MemberList 2
    MemberList customList = new MemberList();
    customList.MaximumNumberOfMember = 3;
    customList.OnFullOfMember += OnFullOfMemberNotify;

    customList.Add(new Student { Id = 4, Name = "Student C", Dob = new DateOnly(2000, 12, 25) });
    customList.Add(new Student { Id = 5, Name = "Student D", Dob = new DateOnly(2000, 12, 25) });
    //customList.Add(new Student { Id = 6, Name = "Student E", Dob = new DateOnly(2000, 12, 26) }); // ✅ Sẽ trigger event full

    Console.WriteLine("List of member:");
    customList.DisplayList();
}


    private static void OnFullOfMemberNotify()
    {
        Console.WriteLine("The member list is full");
    }
}
