
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question1
{
    public class Course
    {
        public int CourseID { get; set; }
        public String CourseTitle { get; set; }

        private Dictionary<Student, double> Students = new Dictionary<Student, double>();

        public Course()
        {
        }

        public Course(int courseID, String courseTitle)
        {
            CourseID = courseID;
            CourseTitle = courseTitle;
        }

        public delegate void CourseHandle(int oldNumber, int newNumber);
        public event CourseHandle OnNumberOfStudentChange;


        public void AddStudent(Student student, double g)
        {
            bool flag = false;
            // check xem student đã tồn tại hay chưa
            // nếu ở đây ko check sẽ không adđ được vì key là giá trị duy nhát không được phếp trùng lặp
            foreach (var item in Students)
            {
                if (item.Key.Equals(student))
                {
                    flag = true;
                    break;
                }
            }

            if(!flag)
            {
                int oldNumber = Students.Count;
                Students.Add(student, g);
                OnNumberOfStudentChange?.Invoke(oldNumber, Students.Count);
            }
        }


        public void RemoveStudent(int StudentId)
        {
            foreach(var item in Students)
            {
                if(item.Key.StudentID == StudentId)
                {
                    int oldNumber = Students.Count;
                    Students.Remove(item.Key);
                    OnNumberOfStudentChange?.Invoke(oldNumber, Students.Count);
                    break;
                }
            }
        }

        public override string? ToString()
        {
            string str = $"Course: {CourseID} - {CourseTitle} \n";
            foreach (var item in Students)
            {
                str += item.Key.ToString() + $" Mark: {item.Value} \n";
            }
            return str;
        }
    }
}
