using ConsoleApp1.BussinessLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.UI.ManageStudent
{
    class SearhcStudentsById : IPage
    {
        StudentController studentController;
        UI_Controller uI_Controller;
        public SearhcStudentsById(UI_Controller uI_Controller, StudentController studentController)
        {
            this.studentController = studentController;
            this.uI_Controller = uI_Controller;
        }

        public void RenderPage()
        {

            while(true) 
            {
                Console.Write("Student ID: ");
                string input = Console.ReadLine().Trim();

                if (input == null) continue;

                try
                {
                    var student = studentController.GetStudentsById(input);
                    if(student == null) 
                    {
                        Console.WriteLine("No Student found");
                    }
                    else Console.WriteLine($"Student ID: {student.GetStudentID()}, Name: {student.GetStudentFullname()}, DOB: {student.GetStudentDOB()}");
                }
                catch (Exception ex) 
                {
                    Console.WriteLine(ex.Message);

                }

                break;
            }

            while (true)
            {
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
