using ConsoleApp1.BussinessLayer.Models;
using ConsoleApp1.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.BussinessLayer
{
    internal class Data
    {
        internal Dictionary<string, Student> studentList = new Dictionary<string, Student>
        {
            { "S1", new Student("S1", "Nguyen Van An", new DateOnly(2004, 01, 15)) },
            { "S2", new Student("S2", "Tran Thi Binh", new DateOnly(2004, 03, 22)) },
            { "S3", new Student("S3", "Le Quang Cuong", new DateOnly(2003, 11, 08)) },
            { "S4", new Student("S4", "Pham Minh Duc", new DateOnly(2004, 07, 19)) },
            { "S5", new Student("S5", "Hoang Thu Ha", new DateOnly(2005, 02, 28)) }
        };

        internal List<Course> courseList = new List<Course>()
        {
            new Course("C# Programming", "CS101", 30, 150.0f),
            new Course("Java Fundamentals", "JA101", 25, 180.0f),
            new Course("Web Development", "WD201", 40, 200.0f),
            new Course("Database Systems", "DB301", 35, 170.0f),
            new Course("Data Structures", "DS202", 20, 220.0f)
        };

        internal List<Registration> registrationList = new List<Registration>()
        {
            // S1 đăng ký 3 khóa
            new Registration("S1", "CS101", new DateTime(2026, 1, 10)),
            new Registration("S1", "WD201", new DateTime(2026, 1, 11)),
            new Registration("S1", "DS202", new DateTime(2026, 1, 12)),

            // S2 đăng ký 2 khóa
            new Registration("S2", "CS101", new DateTime(2026, 1, 13)),
            new Registration("S2", "JA101", new DateTime(2026, 1, 14)),

            // S3 đăng ký 4 khóa
            new Registration("S3", "JA101", new DateTime(2026, 1, 15)),
            new Registration("S3", "WD201", new DateTime(2026, 1, 16)),
            new Registration("S3", "DB301", new DateTime(2026, 1, 17)),
            new Registration("S3", "DS202", new DateTime(2026, 1, 18)),

            // S4 đăng ký 1 khóa
            new Registration("S4", "DB301", new DateTime(2026, 1, 19))

            // S5 không có registration
        };
    }
} 
