using Ex04.Menus.Events;
using System;
using System.Threading;

namespace Ex04.Menus.Test
{
    public class EventsTest
    {
        private MainMenu m_MainMenuTest;

        public EventsTest(string i_MenuHeadline) 
        {
            m_MainMenuTest = new MainMenu(i_MenuHeadline);
 
            //First Item Menu: "Version and Capitals" 
            MenuItem m11 = new MenuItem("Show Version", ShowVersion, 1);
            MenuItem m12 = new MenuItem("Count Capitals", CountCapitals, 2);
            //Second Item Menu: "Show Data/Time" 
            MenuItem m21 = new MenuItem("Show Time", ShowTime, 1);
            MenuItem m22 = new MenuItem("Show Date", ShowDate, 2);
            //Create first and second sub-menues
            MenuItem m1 = new MenuItem("Version and Capitals", null, 1);
            MenuItem m2 = new MenuItem("Show Data / Time", null, 2);
            //Adding items for each sum-menu
            m1.AddMenuItem(m11);
            m1.AddMenuItem(m12);
            m2.AddMenuItem(m21);
            m2.AddMenuItem(m22);
            //Adding to main menu
            m_MainMenuTest.AddMenuItemToMainMenu(m1);
            m_MainMenuTest.AddMenuItemToMainMenu(m2);
        }
        
        public void Show()
        {
            m_MainMenuTest.Show();
        }

        public static void ShowVersion()
        {
            Console.WriteLine("App Version: 24.2.4.9540");
            Thread.Sleep(2000);     
        }

        public static void CountCapitals()
        {
            Console.WriteLine("Please enter your sentence: ");

            string getInput = Console.ReadLine();
            int count = 0;

            foreach (char c in getInput)
            {
                if (char.IsUpper(c))
                {
                    count++;
                }
            }

            Console.WriteLine($"There are {count} capitals in your sentence");
            Thread.Sleep(2000);
        }

        public static void ShowTime()
        {
            DateTime currentTime = DateTime.Now;

            Console.WriteLine($"The current time is {currentTime.ToString("HH:mm:ss")}");
            Thread.Sleep(2000);
        }

        public static void ShowDate()
        {
            DateTime currentTime = DateTime.Now;

            Console.WriteLine($"The current date is {currentTime.ToString("dd-MM-yyyy")}");
            Thread.Sleep(2000);
        }
    }
}
