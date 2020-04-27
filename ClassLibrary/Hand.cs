using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ClassLibrary
{
   public class Hand
    {
        public int Play(string name, int money)
        {
            Cards.Deck deck = new Cards.Deck();
            Cards cards = new Cards();
           Cards.Card card = new Cards.Card();
            Reads read = new Reads();
            List<Cards.Card> userHand;
            List<Cards.Card> dealerHand = new List<Cards.Card>();

            int betAmount = 0;
            string[] choice = { "1. For Hit: ", "2. for Stay: " };
            string[] repeat = { "1. Play again\n", "2. Quit\n" };

            string info = $"\n \n \n \n \n \n \n \n \n \nCards in the deck: {deck.RemainingCards()} \n{name}'s Money Count: {money} \nCurrent Bet: {betAmount}";
            bool loop = true;
            bool menu = true;
            bool test = true;
            int oot2;
            if (deck.RemainingCards() < 20)
            {
                deck.Initialize();
               deck.Shuffle();

            }


            while (menu == true)
            {
                Console.Write($"You have ${money}.\nHow much would you like to bet? ");
                string input = Console.ReadLine().Trim().Replace(" ", " ");
                if (money <= 0)
                {
                    string[] loser = { "You have no money to bet!", "Please press 2 to exit: " };
                    read.ReadChoice(ref loser, out oot2);
                    if (oot2 != 2)
                    {
                        Console.WriteLine("You are a loser, please leave.");
                    }
                    else if (oot2 == 2)
                    {
                        Environment.Exit(2);
                    }
                }

                Console.Clear();

                if (Int32.TryParse(input, out betAmount) || betAmount > 0 || betAmount < money)
                {

                }
                while (!Int32.TryParse(input, out betAmount) || betAmount < 1 || betAmount > money)
                {
                    Console.Write("That is not a correct response, try again. How much would you like to bet? ");
                    int bet = Convert.ToInt32(Console.ReadLine());

                    if (bet > 0 || bet < money)
                    {

                        Console.Clear();
                        break;
                    }


                }

                dealerHand = new List<Cards.Card>();
                userHand = new List<Cards.Card>();
                // user card 1
                userHand.Add(deck.DrawCard());
                //dealer card 1
                dealerHand.Add(deck.DrawCard());
                //user card 2
                userHand.Add(deck.DrawCard());
                //dealer card 2
                dealerHand.Add(deck.DrawCard());
                

                foreach (Cards.Card dealercard in dealerHand)
                {
                    if (dealercard.face == Cards.Face.Ace)
                    {
                        dealercard.value += 10;
                        break;
                    }
                }


                
                Console.WriteLine("Dealing...");
                Thread.Sleep(1500);
                Console.WriteLine("User Card 1: {0} of {1}", userHand[0].face, userHand[0].suits);
                Thread.Sleep(1500);
               
                Console.WriteLine("Dealer Card 1: {0} of {1}", dealerHand[0].face, dealerHand[0].suits);
                Thread.Sleep(1500);
                Console.WriteLine("User Card 2: {0} of {1}", userHand[1].face, userHand[1].suits);
                
                Console.WriteLine("\n" + $"{name}'s Hand");
                Console.WriteLine("Card 1: {0} of {1}", userHand[0].face, userHand[0].suits);
                
                Console.WriteLine("Card 2: {0} of {1}", userHand[1].face, userHand[1].suits);
                Console.WriteLine("Total: {0}\n", userHand[0].value + userHand[1].value);
                Console.WriteLine("Dealer's Hand");
               
                Console.WriteLine("Card 1: {0} of {1}", dealerHand[0].face, dealerHand[0].suits);
               

              

                







                Console.WriteLine($"\n \n \n \n \n \n \n \n \n \nCards in the deck: {deck.RemainingCards()} \n{name}'s Money Count: ${money} \nCurrent Bet: ${betAmount}" + "\n");


               
                while (loop == true)
                {
                     read.ReadChoice(ref choice, out oot2);


                    int count = userHand[0].value + userHand[1].value;
                   
                    foreach (Cards.Card usercard in userHand)
                    {
                        if (usercard.face == Cards.Face.Ace)
                        {
                            if (count > 10)
                            {
                                usercard.value = 1;
                                break;

                            }
                            else if (count < 10)
                            {
                                usercard.value = 11;
                                break;
                            }
                        }
                    }

                    if (oot2 == 1)
                    {
                        userHand.Add(deck.DrawCard());




                        //if (count > 21)
                        //{

                        //    break;
                        //}


                        while (oot2 == 1)
                        {
                            userHand.Add(deck.DrawCard());
                            foreach (Cards.Card card2 in userHand)
                            {
                               
                                count = count + card2.value;
                                Console.WriteLine($"{card2.face} of {card2.suits} card count: {count}");
                                loop = true;
                                break;

                            }

                            break;
                           

                        }
                        




                    }
                    else if (oot2 == 2)
                    {
                        Console.WriteLine("Dealer's turn....");
                        Thread.Sleep(1000);
                        Console.WriteLine("\n" + "Dealer Card 2: {0} of {1}", dealerHand[1].face, dealerHand[1].suits);

                        int dealerTotal = dealerHand[0].value + dealerHand[1].value;
                        Console.WriteLine($"Dealer card count: {dealerTotal}");
                        if (dealerTotal < 17)
                        {
                            while (dealerTotal < 17)
                            {
                                dealerHand.Add(deck.DrawCard());
                                Thread.Sleep(1000);
                                foreach (Cards.Card usercard in dealerHand)
                                {
                                    if (usercard.face == Cards.Face.Ace)
                                    {
                                        if (count > 10)
                                        {
                                            usercard.value = 1;
                                            break;

                                        }
                                        else if (count < 10)
                                        {
                                            usercard.value = 11;
                                            break;
                                        }
                                    }
                                }
                                foreach (Cards.Card card3 in dealerHand)
                                {
                                    dealerTotal = dealerTotal + card3.value;
                                    Thread.Sleep(1000);

                                    Console.WriteLine($"{card3.face} of {card3.suits}");
                                    Console.Write($"Dealer Total: {dealerTotal} ");

                                    if (dealerTotal == 17 && dealerTotal > count && dealerTotal < 21)
                                    {

                                        money = money - betAmount;
                                        break;
                                    }
                                    if (dealerTotal > 21)
                                    {
                                        Console.WriteLine("Dealer busted!");
                                        money = money + betAmount;

                                        break;

                                    }
                                    if (dealerTotal >= 17)
                                        break;

                                }

                                if (dealerTotal >= 17)
                                {

                                    break;
                                }




                            }
                        }


                        if (dealerTotal > 21)
                        {

                            break;
                        }

                        else if (count > dealerTotal)
                        {
                            
                            Console.WriteLine("\n" + $"{name} wins!!!!");
                            money = money + betAmount;
                            break;
                        }
                        else if (count < dealerTotal)
                        {

                           
                            Console.WriteLine("Dealer wins.");
                            money = money - betAmount;
                            break;
                        }
                        else if (dealerTotal == count)
                        {

                            Console.WriteLine("It's a push!");
                            break;
                        }


                    }
                    if (count > 21)
                    {
                        
                        Console.WriteLine("You busted!");
                        money = money - betAmount;
                        break;

                    }

                   


                }


                read.ReadChoice(ref repeat, out oot2);
                if (oot2 == 1)
                {
                    Console.Clear();
                }
                else if (oot2 == 2)
                {
                    Environment.Exit(2);
                }



            }
            return Count(info);
        }
        private int Count(string words)
        {
            int count = 0;
            bool loop = true;

            while (loop == true)
            {
                Console.WriteLine(words);
            }
            return count;
        }
    }
}
