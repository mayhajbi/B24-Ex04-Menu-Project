using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class InterfaceTest
    {
        private MainMenu m_MainMenuTest;

        public InterfaceTest(string i_MainMenuHeadline)
        {
            m_MainMenuTest = new MainMenu(i_MainMenuHeadline);
            //First level menu items
            MenuItem versionAndCapitalsItem = new MenuItem("Version and Capitals", 1);
            MenuItem showDateTimeItem = new MenuItem("Show Date/Time", 2);
            MenuItem showVersionItem = new MenuItem("Show Version", 1);
            MenuItem countCapitalsItem = new MenuItem("Count Capitals", 2);
            MenuItem showTimeItem = new MenuItem("Show Time", 1);
            MenuItem showDateItem = new MenuItem("Show Date", 2);

            //Define actions for menu items
            showVersionItem.AddMenuItemExecute(new ShowVersionAction());
            countCapitalsItem.AddMenuItemExecute(new CountCapitalsAction());
            showTimeItem.AddMenuItemExecute(new ShowTimeAction());
            showDateItem.AddMenuItemExecute(new ShowDateAction());
            //Add sub-menu items
            versionAndCapitalsItem.AddMenuItem(showVersionItem);
            versionAndCapitalsItem.AddMenuItem(countCapitalsItem);
            showDateTimeItem.AddMenuItem(showTimeItem);
            showDateTimeItem.AddMenuItem(showDateItem);
            // Add first level items to main menu
            m_MainMenuTest.AddMenuItem(versionAndCapitalsItem);
            m_MainMenuTest.AddMenuItem(showDateTimeItem);
        }
        
        public void Show()
        {
            m_MainMenuTest.Show();
        }
    }

}
