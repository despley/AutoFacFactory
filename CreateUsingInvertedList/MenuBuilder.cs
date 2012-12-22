using System.Collections.Generic;
using System.Text;

namespace CreateUsingInvertedList
{
    public class MenuBuilder : Screen
    {
        private readonly IList<Screen> _screens; 

        public MenuBuilder(string name): base(name)
        {
        }

        //Takes the screen list created in the Container at startup
        public MenuBuilder(IList<Screen> screens) : this ("Main Menu")
        {
            _screens = screens;
        }

        public string DisplayScreenItemsForSelection()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Screen screen in _screens)
            {
                sb.Append(_screens.IndexOf(screen) + 1);
                sb.Append(". Build ");
                sb.Append(screen.Name);
                sb.Append("\n");
            }
            return sb.ToString();
        }

        public override string DisplayWelcomeMessage()
        {
            return string.Format("Welcome to the colour screen picker. \n \nPlease enter you screen selection 1-{0}:\n", _screens.Count);
        }
        public Screen GetScreen(int index)
        {
            return _screens[index - 1];
        }
    }
}
