namespace CreateUsingInvertedList
{
    public abstract class Screen
    {
        protected Screen(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
        public virtual string DisplayWelcomeMessage()
        {
            return  "Hello from the " + Name;
        }
    }
}