using System.Collections.Generic;
using CreateUsingInvertedList;
using Moq;
using NUnit.Framework;

namespace CreateUsingInvertedListTests
{
    [TestFixture]
    public class CreateUIOptions
    {
        [Test]
        public void CreateOneItemListOfScreensForDrawing()
        {
            IList<Screen> screens = new List<Screen>();
            screens.Add(new YellowScreen());
            MenuBuilder menuBuilder = new MenuBuilder(screens);
            Assert.AreEqual("1. Build Yellow Screen\n", menuBuilder.DisplayScreenItemsForSelection());
        }

         [Test]
        public void CreateNumberedListOfScreensForDrawing()
         {
             IList<Screen> screens = new List<Screen>();
             screens.Add(new YellowScreen());
             screens.Add(new BlueScreen(new BlueScreenRepo()));
             screens.Add(new GreenScreen(new GreenScreenRepo()));
             MenuBuilder menuBuilder = new MenuBuilder(screens);
             Assert.AreEqual("1. Build Yellow Screen\n2. Build Blue Screen\n3. Build Green Screen\n", menuBuilder.DisplayScreenItemsForSelection());
         }

        [Test]
        public void ShowWelcomeMessage()
        {
            var screens = new List<Screen>();
            screens.Add(new YellowScreen());
            screens.Add(new BlueScreen(new BlueScreenRepo()));
            screens.Add(new GreenScreen(new GreenScreenRepo())); 
            MenuBuilder menuBuilder = new MenuBuilder(screens);
            Assert.AreEqual("Welcome to the colour screen picker. \n \nPlease enter you screen selection 1-3:\n", menuBuilder.DisplayWelcomeMessage());
        }

        [Test]
        public void GetBlueScreenMessage()
        {
            var screens = new List<Screen>();
            screens.Add(new YellowScreen());
            screens.Add(new BlueScreen(new BlueScreenRepo()));
            screens.Add(new GreenScreen(new GreenScreenRepo()));
            MenuBuilder menuBuilder = new MenuBuilder(screens);
            var screen = menuBuilder.GetScreen(2);
            Assert.AreEqual("Hello from the Blue Screen", screen.DisplayWelcomeMessage());

        }
    }
}