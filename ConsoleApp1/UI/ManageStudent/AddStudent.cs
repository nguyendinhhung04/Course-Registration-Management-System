using ConsoleApp1.BussinessLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.UI.ManageStudent
{
    class AddStudent : IPage
    {
        UI_Controller uI_Controller;
        StudentController studentController;

        public AddStudent(UI_Controller uI_Controller, StudentController studentController)
        {
            this.uI_Controller = uI_Controller;
            this.studentController = studentController;
        }

        public void RenderPage()
        {
            Console.WriteLine("-----------Add Student---------------");
            Console.Write("Student ID (Please leave blank if Auto generating ID): ");
            string idInput = Console.ReadLine();
            Console.Write("Student Name: ");
            string nameInput = Console.ReadLine();
            Console.Write("Student Date-Of_Birth(yyyy-mm-dd): ");
            string dobInput = Console.ReadLine();

            bool isValid = true;
            if(! DateOnly.TryParse( dobInput, out DateOnly dob ))
            {
                Console.WriteLine("Invalid Date-Of_Birth");
                isValid = false;
            }
            if (String.IsNullOrEmpty(nameInput))
            {
                Console.WriteLine("Invalid Name");
                isValid = false;
            }

            if (isValid)
            {
                try
                {
                    var result = studentController.AddStudent(idInput, nameInput, dob);
                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
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
