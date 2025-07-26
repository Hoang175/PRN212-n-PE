namespace Q1_Sp25
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StudentManager studentManager = new StudentManager();
            Console.WriteLine("Enter number of students:");
            int numberOfStudents = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfStudents; i++)
            {
                Student student = StudentManager.InputStudent();
                studentManager.AddStudent(student);
            }

            Console.WriteLine("\nList of students:");
            studentManager.DisplayStudents();

            // Kiểm tra điều kiện thăng hạng (Promotion)
            static bool CheckCondition(Student student)
            {
                return student.Age >= 18;
            }

            IsPromoable isPromoable = CheckCondition;
            Console.WriteLine("\nStudents eligible for promotion:");
            studentManager.PromoteStudents(isPromoable);
        }
    }
}
