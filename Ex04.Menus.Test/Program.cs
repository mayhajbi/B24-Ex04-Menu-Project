namespace Ex04.Menus.Test
{
    public class Program
    {
        public static void Main()
        {
            EventsTest menuEventsTest = new EventsTest("**Delegates Menu**");
            InterfaceTest interfaceTest = new InterfaceTest("**Interface Menu**");

            menuEventsTest.Show();
            interfaceTest.Show();
        }
    }
}
