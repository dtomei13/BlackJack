using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
   public class Reads
    {
        Cards.Deck deck = new Cards.Deck();
        public void ReadChoice(ref string[] Array, out int Out)
        {

            for (int i = 0; i < Array.Length; i++)
            {
                Console.Write($"{Array[i]}");
                
            }

            Out = CheckINT(" ");
           

        }

        public int CheckINT(string check)
        {
            Console.Write(check);
            string input = Console.ReadLine();
            bool test = int.TryParse(input, out int intcheck);

            while (test == false || intcheck < 1 || intcheck > 3)
            {
                Console.WriteLine("That is not a choice");
                input = Console.ReadLine();
                test = int.TryParse(input, out intcheck);
            }

            return intcheck;
        }
    }
}
