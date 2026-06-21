using ConsoleApp1.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.UI
{
    class Menu : IPage
    {
        UI_Controller uI_Controller;

        private List<string> optionList = new List<string>()
        {
            "Manage Student",
            "Manage Course",
            "Manage Registration",
            "Exit"
        };

        public Menu(UI_Controller uI_Controller)
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
                Console.WriteLine("-------------Menu------------");

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
                case 0:
                    uI_Controller.ChangeUiState(1);
                    break;

                case 1:
                    uI_Controller.ChangeUiState(2);
                    break;

                case 2:
                    uI_Controller.ChangeUiState(3);
                    break;
                case 3:
                    uI_Controller.ChangeUiState(-1);
                    break;

            }
        }
    }
}