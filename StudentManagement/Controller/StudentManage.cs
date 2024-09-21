using StudentManagement.Models;
using StudentManagement.Ultility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Controller
{
    public class StudentManage
    {
        private List<Student> _listStudents;

        private Input input;

        public StudentManage()
        {
            _listStudents = new List<Student>();
            input = new Input();
        }

        public void CreateStudent()
        {
            string name = input.GetName();
            DateTime dOB = input.GetDate();
            string address = input.GetAddress();
            float height = input.GetHeight();
            float weight = input.GetWeight();
            string studentId;
            while (true)
            {
                studentId = input.GetStudentId();
                //check dupplicate student id
                if (_listStudents.Any(s => s.studentId.Equals(studentId, StringComparison.OrdinalIgnoreCase)))
                {
                    Console.WriteLine("Student ID already exists. Please enter a different Student ID.");
                }
                else
                {
                    break;
                }
            }
            string schoolName = input.GetSchoolName();
            int yearStrarted = input.GetYearStarted();
            double gPA = input.GetGpa();

            Student student = new Student(name, dOB, address,  height, weight, studentId, schoolName, yearStrarted, gPA);
            _listStudents.Add(student);
            Console.WriteLine("Student added successfully!");
        }

        public Student GetStudentById()
        {
            string studentId = input.GetStudentId();
            Student student = _listStudents.SingleOrDefault(s => s.studentId == studentId);
            if (student == null)
            {
                Console.WriteLine($"Student with Id {studentId} not found!");
                return new Student();
            }
            else
            {
                Console.WriteLine(student.ToString());
                return student;
            }
        }

        public void UpdateStudentById()
        {
            Student student = GetStudentById();
            if (student != null)
            {
                while (true)
                {
                    Console.WriteLine("\nSelect the field you want to update: ");
                    Console.WriteLine("1. Name");
                    Console.WriteLine("2. Date of Birth");
                    Console.WriteLine("3. Address");
                    Console.WriteLine("4. Height");
                    Console.WriteLine("5. Weight");
                    Console.WriteLine("6. Current School");
                    Console.WriteLine("7. Year of University Entry");
                    Console.WriteLine("8. GPA");
                    Console.WriteLine("0. Exit update");
                    Console.Write("Enter your choice: ");
                    string choice = Console.ReadLine();
                    try
                    {
                        switch (choice)
                        {
                            case "1":
                                student.name = input.GetName();
                                break;
                            case "2":
                                student.dateOfBirth = input.GetDate();
                                break;
                            case "3":
                                student.address = input.GetAddress();
                                break;
                            case "4":
                                student.height = input.GetHeight();
                                break;
                            case "5":
                                student.weight = input.GetWeight();
                                break;
                            case "6":
                                student.school = input.GetSchoolName();
                                break;
                            case "7":
                                student.startingTime = input.GetYearStarted();
                                break;
                            case "8":
                                student.AverangeScore = input.GetGpa();
                                break;
                            case "0":
                                Console.WriteLine("Update finished.");
                                return;
                            default:
                                Console.WriteLine("Invalid choice. Please try again.");
                                break;
                        }

                        Console.WriteLine("Student details updated successfully:");
                        Console.WriteLine(student.ToString());
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}. Update failed.");
                    }
                }
            }
        }

        public void DeleteStudentById()
        {
            Student student = GetStudentById();
            if (student != null)
            {
                _listStudents.Remove(student);
                Console.WriteLine("Student deleted successfully");

                //update ID of remaining student
                for (int i = 0; i < _listStudents.Count; i++)
                {
                    _listStudents[i].personId = i + 1;
                }
            }
        }

        public void ShowAllStudent()
        {
            if (!_listStudents.Any())
            {
                Console.WriteLine("No student in the list");
                return;
            }
            foreach (Student student in _listStudents)
            {
                Console.WriteLine(student.ToString());
            }
        }

        public void ShowPercentAcademicPerformance()
        {
            if (!_listStudents.Any())
            {
                Console.WriteLine("No students in the list");
                return;
            }

            var academicPerformaceGroups = _listStudents.GroupBy(s => s.APR)
                                            .Select(group => new
                                            {
                                                TypeAcademicPerformance = group.Key,
                                                Percent = (double)group.Count() / _listStudents.Count * 100
                                            })
                                            .OrderByDescending(g => g.Percent)
                                            .ToList();
            foreach (var group in academicPerformaceGroups)
            {
                Console.WriteLine($"{group.TypeAcademicPerformance}: {group.Percent:F1}%");
            }
        }

        public void ShowPercentGpa()
        {
            if (!_listStudents.Any())
            {
                Console.WriteLine("No students in the list");
                return;
            }
            Dictionary<double, int> frequencyGpa = new Dictionary<double, int>();

            foreach (Student student in _listStudents)
            {
                if (frequencyGpa.ContainsKey(student.AverangeScore))
                {
                    frequencyGpa[student.AverangeScore]++;
                }
                else
                {
                    frequencyGpa[student.AverangeScore] = 1;
                }
            }

            foreach (var entry in frequencyGpa)
            {
                double percent = (double)entry.Value / _listStudents.Count * 100;
                Console.WriteLine($"GPA: {entry.Key} - {percent:F1}%");
            }
        }
        public void ShowListStudentByAcademicPerformance()
        {
            while (true)
            {
                Console.WriteLine("1. Poor");
                Console.WriteLine("2. Weak");
                Console.WriteLine("3. Average");
                Console.WriteLine("4. Well");
                Console.WriteLine("5. Good");
                Console.WriteLine("6. Excellent");
                Console.WriteLine("0. Back to menu");
                Console.WriteLine("Choose option to show list student by academic performance: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        ListStudentByAcademicPerformane(AcademicPerformanceRatingEnum.POOR);
                        break;
                    case "2":
                        ListStudentByAcademicPerformane(AcademicPerformanceRatingEnum.WEAK);
                        break;
                    case "3":
                        ListStudentByAcademicPerformane(AcademicPerformanceRatingEnum.AVERAGE);
                        break;
                    case "4":
                        ListStudentByAcademicPerformane(AcademicPerformanceRatingEnum.WELL);
                        break;
                    case "5":
                        ListStudentByAcademicPerformane(AcademicPerformanceRatingEnum.GOOD);
                        break;
                    case "6":
                        ListStudentByAcademicPerformane(AcademicPerformanceRatingEnum.EXCELLENT);
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private void ListStudentByAcademicPerformane(AcademicPerformanceRatingEnum name)
        {
            var list = _listStudents.Where(s => s.APR == name).ToList();
            if (!list.Any())
            {
                Console.WriteLine($"No students found with {name} performance.");
            }
            else
            {
                foreach (var student in list)
                {
                    Console.WriteLine(student.ToString());
                }
            }
        }

        public void SaveToFile()
        {
            string folderPath = @"D:\FPT POLYTECHNIC\C#\StudentManagement\Database";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath); // Tạo thư mục nếu chưa tồn tại
            }
            string filePath = Path.Combine(folderPath, "listStudents.txt");
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine("Name,Dob,Address,Height,Weight,StudentId,School,YearStarted,Gpa,Apr");
                    foreach (var student in _listStudents)
                    {
                        writer.WriteLine($"{student.name}, {student.dateOfBirth.ToShortDateString()}, {student.address}," +
                            $" {student.height}, {student.weight}, {student.studentId}, {student.school}," +
                            $" {student.startingTime}, {student.AverangeScore}, {student.APR}");
                    }
                }
                Console.WriteLine("Data saved to file successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving to file: {ex.Message}");
            }
        }

        public void ReadFromFile()
        {
            string folderPath = @"D:\FPT POLYTECHNIC\C#\StudentManagement\StudentManagement";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath); // Tạo thư mục nếu chưa tồn tại
            }

            string filePath = Path.Combine(folderPath, "listStudents.txt");
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    _listStudents.Clear();

                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');

                        if (parts.Length == 10)
                        {
                            string name = parts[0].Trim();
                            DateTime dob = DateTime.Parse(parts[1]);
                            string address = parts[2].Trim();
                            float height = float.Parse(parts[3].Trim());
                            float weight = float.Parse(parts[4].Trim());
                            string studentId = parts[5].Trim();
                            string school = parts[6].Trim();
                            int yearStarted = int.Parse(parts[7].Trim());
                            double gpa = double.Parse(parts[8].Trim());

                            Student student = new Student(name, dob, address, height, weight, studentId, school, yearStarted, gpa);
                            _listStudents.Add(student);
                        }
                    }
                }
                Console.WriteLine("Data read from file successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading from file: {ex.Message}");
            }
        }
    }
}
