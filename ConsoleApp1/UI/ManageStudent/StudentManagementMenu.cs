using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.UI.ManageStudent
{
    internal class StudentManagementMenu : IPage
    {
        UI_Controller uI_Controller;

        private List<string> optionList = new List<string>()
        {
            "View all student",
            "Search student By Id",
            "Add new student",
            "Return to Main menu"
        };

        public StudentManagementMenu(UI_Controller uI_Controller)
        {
            this.uI_Controller = uI_Controller;
        }

        public void RenderPage()
        {
            int selected = 0;
            ConsoleKey key;

            do
            {
                Console.Clear();
                Console.WriteLine("-------------Manage Student------------");

                for (int i = 0; i < optionList.Count; i++)
                {
                    if (i == selected)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;

                        Console.WriteLine($"> {optionList[i]}");

                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine($"  {optionList[i]}");
                    }
                }

                key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        selected--;
                        if (selected < 0)
                            selected = optionList.Count - 1;
                        break;

                    case ConsoleKey.DownArrow:
                        selected++;
                        if (selected >= optionList.Count)
                            selected = 0;
                        break;
                }

            } while (key != ConsoleKey.Enter);

            switch (selected)
            {
                case 0: // View all student
                    uI_Controller.ChangeUiState(5);
                    break;

                case 1: // Search student By Id
                    uI_Controller.ChangeUiState(6);
                    break;

                case 2: // Add new student
                    uI_Controller.ChangeUiState(7);
                    break;

                case 3: // Return to Main menu
                    uI_Controller.ChangeUiState(0);
                    break;
            }
        }
    }
}