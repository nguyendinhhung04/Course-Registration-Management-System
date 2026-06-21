using ConsoleApp1.BussinessLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.UI.CourseManagement
{
    internal class AddCourse : IPage
    {
        UI_Controller uI_Controller;
        CourseController courseController;

        public AddCourse(UI_Controller uI_Controller, CourseController courseController)
        {
            this.uI_Controller = uI_Controller;
            this.courseController = courseController;
        }

        private (string,string,int,float) GetInput()
        {
            Console.Write("Course Name: ");
            var inputName = Console.ReadLine();
            Console.Write("Course Code: ");
            var inputCode = Console.ReadLine();
            Console.Write("Course Capacity: ");
            var inputCapacity = Console.ReadLine();
            if (!int.TryParse(inputCapacity, out int capacity))
            {
                throw new ArgumentException("Invalid capacity");
            }
            Console.Write("Course Fee: ");
            var inputFee = Console.ReadLine();
            if (!int.TryParse(inputFee, out int fee))
            {
                throw new ArgumentException("Invalid fee");
            }

            return (inputName, inputCode, capacity, fee);
        }

        public void RenderPage()
        {
            Console.WriteLine("------------Add Course-----------");

            try
            {
                (string inputName, string inputCode, int capacity, float fee) = GetInput();

                string result = courseController.AddCourse(inputName, inputCode, capacity, fee);
                Console.WriteLine(result);
            }
            catch(Exception e) 
            {
                Console.WriteLine(e.Message);
            }

            while (true)
            {
                Console.WriteLine("");
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
