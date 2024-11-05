using System;

namespace Ex04.Menus.Interfaces
{
    public class MainMenu : MenuItem
    {
        public MainMenu(string i_MainMenuHeadline) : base(i_MainMenuHeadline, -1) {}

        public void Show()
        {
            bool isExitMenuRequested = false;

            while (!isExitMenuRequested)
            {
                isExitMenuRequested = OnMenuDisplay();
            }

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
