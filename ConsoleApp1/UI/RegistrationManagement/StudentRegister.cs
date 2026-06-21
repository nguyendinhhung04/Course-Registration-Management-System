using ConsoleApp1.BussinessLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.UI.RegistrationManagement
{
    internal class StudentRegister : IPage
    {

        UI_Controller uI_Controller;
        RegistrationController registerController;

        public StudentRegister(UI_Controller uI_Controller, RegistrationController registerController)
        {
            this.uI_Controller = uI_Controller;
            this.registerController = registerController;
        }

        public void RenderPage()
        {
            Console.WriteLine("-------------Student Register-------------");
            Console.Write("Student ID: ");
            string inputStudentId = Console.ReadLine();
            Console.Write("Course Code: ");
            string inputCourseCode = Console.ReadLine();

            if((!String.IsNullOrEmpty(inputStudentId)) && (!String.IsNullOrEmpty(inputCourseCode)) )
            {
                try
                {
                    string result = registerController.NewRegistration(inputStudentId, inputCourseCode);
                    Console.WriteLine(result);
                }
                catch (Exception ex) 
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Don't leave student id and course code blank");
            }


            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine("Back to Menu ?(Y/N)");
                string input = Console.ReadLine();

                if (input == "y" || input == "Y")
                {

                    uI_Controller.ChangeUiState(1);
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
