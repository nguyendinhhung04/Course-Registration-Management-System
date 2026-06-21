using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.UI.RegistrationManagement
{
    internal class RegistrationManagementMenu : IPage
    {
        UI_Controller uI_Controller;

        private List<string> optionList = new List<string>()
        {
            "Student register",
            "View Student in classes",
            "Return to Main menu"
        };

        public RegistrationManagementMenu(UI_Controller uI_Controller)
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
                Console.WriteLine("-------------Manage Registration------------");

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
                    uI_Controller.ChangeUiState(10);
                    break;
                case 1: // Return to Main menu
                    uI_Controller.ChangeUiState(0);
                    break;
            }
        }
    }
}
