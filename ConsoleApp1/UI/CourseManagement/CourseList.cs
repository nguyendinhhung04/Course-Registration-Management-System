using ConsoleApp1.BussinessLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.UI.CourseManagement
{
    class CourseList : IPage
    {
        UI_Controller uI_Controller;
        CourseController courseController;

        public CourseList(UI_Controller uI_Controller, CourseController courseController)
        {
            this.uI_Controller = uI_Controller;
            this.courseController = courseController;
        }

        public void RenderPage()
        {
            Console.WriteLine("----------Course List----------");

            Console.WriteLine("--------------------------------------------------------------------------------");
            Console.WriteLine($"{"Course Name",-20} {"Code",-10} {"Capacity",-10} {"Fee",-10}");
            Console.WriteLine("--------------------------------------------------------------------------------");

            foreach (var course in courseController.GetCourses())
            {
                Console.WriteLine(
                    $"{course.GetCourseName(),-20} " +
                    $"{course.GetCourseCode(),-10} " +
                    $"{course.GetCapacity(),-10} " +
                    $"{course.GetFee(),-10:F2}"
                );
            }

            Console.WriteLine("--------------------------------------------------------------------------------");

            while (true)
            {
                Console.WriteLine("Back to Menu ?(Y/N)");
                string input = Console.ReadLine();

                if (input == "y" || input == "Y")
                {

                    uI_Controller.ChangeUiState(2);
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
