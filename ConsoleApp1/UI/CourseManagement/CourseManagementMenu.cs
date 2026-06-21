using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.UI.CourseManagement
{
    internal class CourseManagementMenu : IPage
    {
        UI_Controller uI_Controller;

        private List<string> optionList = new List<string>()
        {
            "View all Courses",
            "Add Course",
            "Return to Main menu"
        };

        public CourseManagementMenu(UI_Controller uI_Controller)
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
                    uI_Controller.ChangeUiState(8);
                    break;
                case 1: // View all student
                    uI_Controller.ChangeUiState(9);
                    break;
                case 2: // Return to Main menu
                    uI_Controller.ChangeUiState(0);
                    break;
            }
        }
    }
}
