using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoFacFactory
{
    public class CustomerSelection
    {
        private IList<Screen> screens; 
        public Screen this [int index]
        {
            get { return screens[index]; }
        }
        
        public void Add(Screen screen)
        {
            if(screens == null)
                screens = new List<Screen>();
            screens.Add(screen);
        }
    }
}
