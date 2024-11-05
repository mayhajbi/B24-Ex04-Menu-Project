using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class ShowVersionAction : IMenuItemExecutable
    {
        public void Execute()
        {
            EventsTest.ShowVersion();
        }
    }
}
