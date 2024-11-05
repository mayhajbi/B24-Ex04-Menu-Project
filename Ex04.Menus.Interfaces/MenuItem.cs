using System;
using System.Collections.Generic;
using System.Threading;

namespace Ex04.Menus.Interfaces
{
    public class MenuItem : IMenuItemExecutable 
    {
        private readonly string r_MenuItemHeadline;
        private readonly int r_MenuItemIndex;
        private readonly List<MenuItem> r_MenuItems = new List<MenuItem>();
        private IMenuItemExecutable r_MenuItemAction;
        
        public MenuItem(string i_MenuItemHeadline, int i_MenuItemIndex)
        {
            r_MenuItemHeadline = i_MenuItemHeadline;
            r_MenuItemIndex = i_MenuItemIndex;
            r_MenuItems.Add(null);      //a dummy head for 'Back'/'Exit'   
        }

        public string Headline
        {
            get { return r_MenuItemHeadline; }
        }

        public int Index
        {
            get { return r_MenuItemIndex; }
        }

        public bool Executable
        {
            get { return r_MenuItemAction != null; }
        }

        public void AddMenuItemExecute(IMenuItemExecutable i_Execute)
        {
            r_MenuItemAction = i_Execute as IMenuItemExecutable; 
        }

        public void Execute()
        {
            if (this.Executable)
            {
                r_MenuItemAction.Execute();
            }
            else
            {
                throw new ArgumentNullException(nameof(r_MenuItemAction), "Can't execute a null MenuItem.");
            }
        }

        public void AddMenuItem(MenuItem i_MenuItem)
        {
            if (i_MenuItem == null)
            {
                throw new ArgumentNullException(nameof(i_MenuItem), "Can't add a null MenuItem.");
            }
            else
            {
                r_MenuItems.Add(i_MenuItem);
            }
        }

        public void MenuItemAction() 
        {
            if (this.Executable)
            {
                Execute();
            }
            else
            {
                OnMenuDisplay();
            }
        }

        public bool OnMenuDisplay()
        {
            bool isExitRequested = false;

            while (!isExitRequested)
            {
                try
                {
                    displayMenuItemsList();

                    int inputChoise = getUserMenuItemChoise();

                    if (inputChoise == 0)
                    {
                        isExitRequested = true;
                    }
                    else
                    {
                        r_MenuItems[inputChoise]?.MenuItemAction();
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine($"Error: {exception.Message}");
                    Thread.Sleep(2000);
                }
            }

            return isExitRequested;
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

            Console.WriteLine($"Please enter your choice (1-{r_MenuItems.Count - 1} or 0 to exit):");

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
            if (i_Input < 0 || i_Input > r_MenuItems.Count)
            {
                throw new Exception($"Input should be a number between 0 to {r_MenuItems.Count - 1}");
            }
        }
    }
}
