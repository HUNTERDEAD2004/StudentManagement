using StudentManagement.Controller;

namespace StudentManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            StudentManage manager = new StudentManage();
            while (true)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Add a new student");
                Console.WriteLine("2. Search for a student by ID");
                Console.WriteLine("3. Update student by ID");
                Console.WriteLine("4. Delete student by ID");
                Console.WriteLine("5. Show percent academic performance");
                Console.WriteLine("6. Show percent average score");
                Console.WriteLine("7. Show list student by academic performance");
                Console.WriteLine("8. Save from file");
                Console.WriteLine("9. Read from file");
                Console.WriteLine("10. Show all students");
                Console.WriteLine("0. Exit program");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        manager.CreateStudent();
                        break;
                    case "2":
                        manager.GetStudentById();
                        break;
                    case "3":
                        manager.UpdateStudentById();
                        break;
                    case "4":
                        manager.DeleteStudentById();
                        break;
                    case "5":
                        manager.ShowPercentAcademicPerformance();
                        break;
                    case "6":
                        manager.ShowPercentGpa();
                        break;
                    case "7":
                        manager.ShowListStudentByAcademicPerformance();
                        break;
                    case "8":
                        manager.SaveToFile();
                        break;
                    case "9":
                        manager.ReadFromFile();
                        break;
                    case "10":
                        manager.ShowAllStudent();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}
