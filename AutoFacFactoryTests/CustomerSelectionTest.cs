using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoFacFactory;
using NUnit.Framework;

namespace AutoFacFactoryTests
{
    [TestFixture]
    public class CustomerSelectionTest
    {
        //Order is specific and there can be only one of each class selected
        [Test]
        public void CustomerSelection_CustomerHasChosenScreens_CollectionCorrectlyCreated()
        {
            CustomerSelection cs = new CustomerSelection();
            cs.Add(new YellowScreen());
            cs.Add(new BlueScreen());
            cs.Add(new GreenScreen());

            AllOfTheseTestAssertTheSameThingSoDoItOnce(cs);

        }

        [Test]
        public void CustomerSelection_CreateTheListToBeAddedUsingNumbersAsWeDontWantToKnowAboutTheObjects_CollectionCorrectlyCreated()
        {
            CustomerSelection cs = new CustomerSelection();
            
            cs.Add(new ScreenHandler<YellowScreen>().CreateScreen());
            cs.Add(new ScreenHandler<BlueScreen>().CreateScreen());
            cs.Add(new ScreenHandler<GreenScreen>().CreateScreen());
            AllOfTheseTestAssertTheSameThingSoDoItOnce(cs);
        }

        private void AllOfTheseTestAssertTheSameThingSoDoItOnce(CustomerSelection cs)
        {
            Assert.AreEqual("YellowScreen", cs[0].Draw());
            Assert.AreEqual("BlueScreen", cs[1].Draw());
            Assert.AreEqual("GreenScreen", cs[2].Draw());
        }
       
    }
}
