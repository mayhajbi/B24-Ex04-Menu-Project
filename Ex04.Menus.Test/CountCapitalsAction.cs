using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class CountCapitalsAction : IMenuItemExecutable
    {
        public void Execute()
        {
            EventsTest.CountCapitals();
        }
    }
}
