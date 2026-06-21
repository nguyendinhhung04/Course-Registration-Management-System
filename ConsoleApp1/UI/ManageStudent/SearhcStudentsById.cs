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
                var studentList = studentController.GetStudentsById(input);
                if (studentList.Count() == 0)
                {
                    Console.WriteLine("No Student found");
                    break;
                }
                
                foreach( var i in studentList )
                {
                    Console.WriteLine($"Student ID: {i.GetStudentID()}, Name: {i.GetStudentFullname()}, DOB: {i.GetStudentDOB()}");
                    
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
