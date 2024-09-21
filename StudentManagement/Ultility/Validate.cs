using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Ultility
{
    public static class Validate
    {
        public static void CheckName(string name)
        {
            if (string.IsNullOrEmpty(name) || name.Length > Constants.NAME_LENGTH_MAX) 
            { 
                throw new ArgumentNullException($"Person name must be between 1 and {Constants.NAME_LENGTH_MAX} characters."); 
            }
        }

        public static void CheckDOB(DateTime DOB)
        {
            if (DOB.Year < Constants.YEAR_MIN)
            {
                throw new ArgumentNullException($"Minimum Date of birth from year {Constants.NAME_LENGTH_MAX}.");
            }
        }

        public static void CheckAddress(string address)
        {
            if (string.IsNullOrEmpty(address) || address.Length > Constants.ADDRESS_LENGTH_MAX)
            {
                throw new ArgumentNullException($"Person name must be between 1 and {Constants.ADDRESS_LENGTH_MAX} characters.");
            }
        }

        public static void CheckHeight(float height)
        {
            if (height < Constants.HEIGHT_MIN || height > Constants.HEIGHT_MAX)
            {
                throw new ArgumentNullException($"Minimum height must be between {Constants.HEIGHT_MIN} and {Constants.HEIGHT_MAX}.");
            }
        }

        public static void CheckWeight(float weight)
        {
            if (weight < Constants.WEIGHT_MIN || weight > Constants.WEIGHT_MAX)
            {
                throw new ArgumentNullException($"Minimum weight must be between {Constants.WEIGHT_MIN} and {Constants.WEIGHT_MAX}.");
            }
        }

        public static void CheckStudentId(string id)
        {
            if (string.IsNullOrWhiteSpace(id) || id.Length != Constants.STUDENT_ID_LENGTH)
                throw new ArgumentException($"Student ID must be {Constants.STUDENT_ID_LENGTH} characters.");
        }

        public static void CheckSchoolName(string schoolName)
        {
            if (string.IsNullOrEmpty(schoolName) || schoolName.Length >= Constants.SCHOOL_NAME_LENGTH_MAX)
                throw new ArgumentException($"Current school must be less than {Constants.SCHOOL_NAME_LENGTH_MAX} characters.");
        }

        public static void CheckYearStarted(int year)
        {
            if (year <= Constants.YEAR_SCHOOL_STARTED) throw new ArgumentException($"Year of university started must be after {Constants.YEAR_SCHOOL_STARTED}.");
        }

        public static void CheckGpa(double gpa)
        {
            if (gpa < Constants.GPA_MIN || gpa > Constants.GPA_MAX)
                throw new ArgumentException($"GPA must be between {Constants.GPA_MIN} and {Constants.GPA_MAX}.");
        }
    }
}
