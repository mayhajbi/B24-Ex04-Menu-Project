using System;

namespace Ex04.Menus.Events
{
    public class MainMenu : MenuItem
    {
        private MenuItem m_MainMenuRoot;
        private bool m_IsExitRequestedStatus = false;

        public MainMenu(string i_MainMenuHeadline) : base(i_MainMenuHeadline,null, 0)
        {
            SetExitMenuItemForMainMenu(new MenuItem("Exit", ExitRequested, 0));
        }

        public void AddMenuItemToMainMenu(MenuItem i_MenuItem)
        {
            base.AddMenuItem(i_MenuItem);
        }

        public void Show()
        {
            while (!m_IsExitRequestedStatus)
            {
                base.DisplayMenuItems();
            }

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        public void ExitRequested()
        {
            m_IsExitRequestedStatus = true;
        }
    }
}
