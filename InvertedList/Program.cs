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
            var builder = new ContainerBuilder();
            builder.RegisterType<YellowScreen>().As<Screen>();
            builder.RegisterType<BlueScreen>().As<Screen>();
            builder.RegisterType<GreenScreen>().As<Screen>();
            var container = builder.Build();
            var menu = new MenuBuilder(container.Resolve<IEnumerable<Screen>>().ToList());
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
