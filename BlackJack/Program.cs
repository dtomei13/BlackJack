using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;
using UnitTestProject1;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            //instances
            Program program = new Program();
            Reads read = new ClassLibrary.Reads();
            Cards cards = new ClassLibrary.Cards();
            Cards.Deck deck = new Cards.Deck();
            Hand hand = new Hand();
            
          
            bool men = true;

            //variable
            int oot = 0;
            int money = 10000;

            //prompts
            Console.WriteLine("\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "Welcome to BLackJack!" + "\n");
            Console.Write("Please enter your name: ");
            string name = Console.ReadLine();
            Console.Clear();
            string[] menu = { $"{name}, would you like to: \n \n1. Play BlackJack", "\n" + "2. Shuffle Deck", "\n" + "3. Exit" + "\n" };

            while (men == true)
            {
                Console.Clear();
                Console.WriteLine("\t" + "\t" + "\t" + "\t" + "\t" + "\t" + "Welcome to BLackJack!" + "\n");

                read.ReadChoice(ref menu, out oot);
                if (oot == 1)
                {
                    Console.Clear();
                    

                        hand.Play(name, money);
      
                }
                if (oot == 2)
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.White;

                    deck.Shuffle();
                    deck.ShowDeck();
                    Console.WriteLine("\n");

                    Console.Write("Press enter to return to the main menu: ");
                    Console.ReadKey();
                    Console.ResetColor();

                }
                if(oot == 3)
                {
                    Environment.Exit(3);
                }

            }
        }
       
    }
}
