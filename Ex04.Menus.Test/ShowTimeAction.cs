using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class ShowTimeAction : IMenuItemExecutable
    {
        public void Execute()
        {
            EventsTest.ShowTime();
        }
    }
}
