using ConsoleApp1.BussinessLayer;
using System;
using System.Collections.Generic;
using System.Text;
using ConsoleApp1.DataAccessLayer.Models;

namespace ConsoleApp1.UI.ManageStudent
{
    class StudentList : IPage
    {
        UI_Controller uI_Controller;
        StudentController studentController;

        public StudentList(UI_Controller uI_Controller, StudentController studentController)
        {
            this.uI_Controller = uI_Controller;
            this.studentController = studentController;
        }

        public void RenderPage()
        {

            foreach(Student i in studentController.GetStudents()) 
            {
                Console.WriteLine($"Student ID: {i.GetStudentID()}, Name: {i.GetStudentFullname()}, DOB: {i.GetStudentDOB()}");
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
