namespace CreateUsingInvertedList
{
    public class BlueScreen : Screen
    {
        private string _name;
        public BlueScreen(BlueScreenRepo blueScreenRepo):this ("Blue Screen")
        {
        }

        public BlueScreen(string name) : base(name)
        {
            _name = name;
        }

        public override string DisplayWelcomeMessage()
        {
            return "Hello from the " + _name;
        }
    }
}