using System;
using System.Collections.Generic;
using System.Threading;

namespace Ex04.Menus.Events
{
    public delegate void MenuItemInvoker();

    public class MenuItem
    {
        private readonly string r_MenuItemHeadline;
        private readonly int r_MenuItemIndex;
        private readonly List<MenuItem> r_MenuItems = new List<MenuItem>();
        public event MenuItemInvoker MenuItemChosen;

        public string Headline
        {
            get { return r_MenuItemHeadline; }
        }

        public int Index
        {
            get { return r_MenuItemIndex; }
        }

        public MenuItem(string i_MenuItemHeadline, MenuItemInvoker i_Invoker, int i_MenuItemIndex)
        {
            r_MenuItemHeadline = i_MenuItemHeadline;
            r_MenuItemIndex = i_MenuItemIndex;
            MenuItemChosen += i_Invoker;
            r_MenuItems.Add(null);                  //Add dummy head to list, as index 0 for Back menu Item
        }

        public void SetExitMenuItemForMainMenu(MenuItem menuItem) 
        {
            r_MenuItems[0] = menuItem;
        }

        public void AddMenuItem(MenuItem i_MenuItem)
        {
            if(i_MenuItem == null)
            {
                throw new ArgumentNullException(nameof(i_MenuItem), "Can't add a null MenuItem.");
            }
            else
            {
                r_MenuItems.Add(i_MenuItem);

                if(MenuItemChosen == null)
                {
                    MenuItemChosen += DisplayMenuItems;
                }
            }
        }

        public void DisplayMenuItems()
        {
            int inputChoise = -1;

            while(inputChoise != 0)
            {
                try
                {
                    displayMenuItemsList();

                    inputChoise = getUserMenuItemChoise();

                    if(!(this is MainMenu) && inputChoise == 0)
                    {
                        break;
                    }
                    else
                    {
                        r_MenuItems[inputChoise]?.OnMenuItemChosen();
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine($"Error: {exception.Message}");
                    Thread.Sleep(2000);
                }
            }
        }

        protected virtual void OnMenuItemChosen()
        {
            if (MenuItemChosen != null)
            {
                this.MenuItemChosen.Invoke();
            }
        }

        private void displayMenuItemsList()
        {
            string headline = (this is MainMenu) ? this.Headline : this.Index + ". " + this.Headline;

            Console.Clear();
            Console.WriteLine(headline);
            Console.WriteLine("============================");

            for (int i = 1; i < r_MenuItems.Count; i++)
            {
                Console.WriteLine($"{r_MenuItems[i].Index}. {r_MenuItems[i].Headline}");
            }

            Console.WriteLine((this is MainMenu) ? "0. Exit" : "0. Back");
        }

        private int getUserMenuItemChoise()
        {
            int convertChoise = -1;

            Console.WriteLine($"Please enter your choice (1-{r_MenuItems.Count-1} or 0 to exit):");

            string getChoise = Console.ReadLine();
                
            Console.Clear();
            checkIfEmptyOrNull(getChoise);
            checkIfInputContainsLetters(getChoise);
            int.TryParse(getChoise, out convertChoise);
            checkIfInputInMenuItemsOptionsRange(convertChoise);

            return convertChoise;
        }

        private void checkIfEmptyOrNull(string i_Input)
        {
            if (string.IsNullOrWhiteSpace(i_Input))
            {
                throw new Exception("Input is empty");
            }
        }

        private void checkIfInputContainsLetters(string i_Input)
        {
            foreach (char c in i_Input)
            {
                if (char.IsLetter(c))
                {
                    throw new Exception("Input should contain digits only");
                }
            }
        }

        private void checkIfInputInMenuItemsOptionsRange(int i_Input)
        {
            if (i_Input <0 || i_Input > r_MenuItems.Count)
            {
                throw new Exception($"Input should be a number between 0 to {r_MenuItems.Count - 1}");
            }
        }
    }
}
