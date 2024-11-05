using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class ShowDateAction : IMenuItemExecutable
    {
        public void Execute()
        {
            EventsTest.ShowDate();
        }
    }
}
