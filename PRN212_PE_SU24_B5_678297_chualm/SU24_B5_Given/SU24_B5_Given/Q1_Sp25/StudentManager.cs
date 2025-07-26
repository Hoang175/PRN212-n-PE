namespace Q1_Sp25
{
    public delegate bool IsPromoable(Student student);  // Đặt delegate trong lớp StudentManager
    public class StudentManager
    {
        private List<Student> students;

        public StudentManager()
        {
            students = new List<Student>();
        }

        public void AddStudent(Student student)
        {
            students.Add(student);
        }

        public void DisplayStudents()
        {
            foreach (var student in students)
            {
                student.Display();
            }
        }

        // Phương thức này sẽ giúp nhập thông tin học sinh
        public static Student InputStudent()
        {
            try
            {
                Console.Write("Enter Student ID: ");
                int id = int.Parse(Console.ReadLine());
                Console.Write("Enter Student Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter Student Age: ");
                int age = int.Parse(Console.ReadLine());
                return new Student(id, name, age);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format. Please try again.");
                return InputStudent();
            }
        }

        // Phương thức này sẽ in danh sách các học sinh đủ điều kiện thăng hạng
        public void PromoteStudents(IsPromoable isPromoable)
        {
            foreach (var student in students)
            {
                if (isPromoable(student))  // Kiểm tra nếu học sinh đủ điều kiện thăng hạng
                {
                    student.Display();
                }
            }
        }
    }
}
