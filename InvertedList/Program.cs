using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using CreateUsingInvertedList;

namespace InvertedList
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create the builder
            var builder = new ContainerBuilder();
            //Register the repositories. You would not implement concrete classes like this but this code shows two different repoitories and a blank constructor
            builder.RegisterType<BlueScreenRepo>();
            builder.RegisterType<GreenScreenRepo>();
            //register the actual screens
            builder.RegisterType<YellowScreen>().As<Screen>();
            builder.RegisterType<BlueScreen>().As<Screen>();
            builder.RegisterType<GreenScreen>().As<Screen>();
            //build the container
            var container = builder.Build();
            //menu builder is the conductor here
            var menu = new MenuBuilder(container.Resolve<IEnumerable<Screen>>().ToList());
            
            //ALL OF THE BELOW SHOULD LIVE IN ANOTHER CLASS [CONSOLEMANAGER] AND NOT JUST BE LEFT HERE UNTESTED AND MESSY - BUT THIS ISN'T PRODUCTION CODE
            Console.WriteLine(menu.DisplayWelcomeMessage());
            var key = Console.ReadLine();
            do
            {
                if (key == "x")
                    break;
                try
                {
                    Console.Clear();
                    var screen = menu.GetScreen(Convert.ToInt32(key));
                    Console.WriteLine(screen.DisplayWelcomeMessage());
                    Console.WriteLine("press any key to continue");
                    Console.ReadKey();

                }
                catch
                {
                }
                Console.Clear();
                Console.WriteLine(menu.DisplayWelcomeMessage());
                Console.WriteLine(menu.DisplayScreenItemsForSelection());
                key = Console.ReadLine();
                Console.Clear();

            } while (true);
        }
    }
}
