using ConsoleApp1.BussinessLayer;
using ConsoleApp1.BussinessLayer.Models;
using ConsoleApp1.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.UI.RegistrationManagement
{
    internal class StudentInCourse : IPage
    {
        UI_Controller uI_Controller;
        RegistrationController registerController;
        CourseController courseController;
        StudentController studentController;

        public StudentInCourse(UI_Controller uI_Controller, RegistrationController registerController, CourseController courseController, StudentController studentController)
        {
            this.uI_Controller = uI_Controller;
            this.registerController = registerController;
            this.courseController = courseController;
            this.studentController = studentController;
        }

        public void RenderPage()
        {
            var registrations = registerController.GetRegistrationInClass();
            var allCourses = courseController.GetCourses();

            foreach (var course in allCourses)
            {
                Console.WriteLine($"Course: {course.GetCourseName()} [{course.GetCourseCode()}]");

                // Find the course in the registrations dictionary keys
                Course matchedCourse = null;
                foreach (var key in registrations.Keys)
                {
                    if (key != null && key.GetCourseCode() == course.GetCourseCode())
                    {
                        matchedCourse = key;
                        break;
                    }
                }

                if (matchedCourse != null && registrations[matchedCourse] != null && registrations[matchedCourse].Count > 0)
                {
                    Console.WriteLine("Enrolled Students:");
                    foreach (var student in registrations[matchedCourse])
                    {
                        Console.WriteLine($"  - {student.GetStudentID()}: {student.GetStudentFullname()}");
                    }
                }
                else
                {
                    Console.WriteLine("No students enrolled.");
                }
                Console.WriteLine();
            }

            while (true)
            {
                Console.WriteLine("Back to Menu ?(Y/N)");
                string input = Console.ReadLine();

                if (input == "y" || input == "Y")
                {
                    uI_Controller.ChangeUiState(3);
                    break;
                }
                else if (input == "n" || input == "N")
                {
                    uI_Controller.ChangeUiState(-1);
                    break;
                }
            }
        }
    }
}
