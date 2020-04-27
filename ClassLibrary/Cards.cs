using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ClassLibrary
{
    public class Cards
    {
        public enum Suits
        {

            Heart,
            Diamond,
            Spade,
            Club
        }

        public enum Face
        {
            Ace,  
            Two,
            Three,
            Four,
            Five,
            Six,
            Seven,
            Eight,
            Nine,
            Ten,
            Jack,
            King ,
            Queen 
        }

        public class Card
        {
            public Suits suits { get; set; }
            public Face face { get; set; }
            public int value { get; set; }
        }
        public class Deck
        {
            private List<Card> cards;

            public Deck()
            {
                this.Initialize();
            }

            public void Initialize()
            {
                cards = new List<Card>();
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 13; j++)
                    {
                        cards.Add(new Card() { suits = (Suits)i, face = (Face)j });
                        if (j <= 9)
                            cards[cards.Count - 1].value = j +1;
                       
                        else
                            cards[cards.Count - 1].value = 10;
                        

                    }

                }
            }

            public void Shuffle()
            {
                Random rand = new Random();
                int count = cards.Count();
                while (count > 1)
                {
                    count--;
                    int next = rand.Next(count + 1);
                    Card card = cards[next];
                    cards[next] = cards[count];
                    cards[count] = card;
                }
            }

            public Card DrawCard()
            {
                if (cards.Count <= 0)
                {
                    this.Initialize();
                    this.Shuffle();
                }

                Card cardReturn = cards[cards.Count - 1];
                cards.RemoveAt(cards.Count - 1);
                
                
                return cardReturn;
            }
            public void ShowDeck()
            {
                int i = 1;
                foreach (Card card in cards)
                {
                    Console.WriteLine("Card {0}: {1} of {2}. Value {3}", i, card.face, card.suits, card.value);
                    i++;
                }
            }
            public int RemainingCards()
            {
                return cards.Count;
            }

            //public int Hand(string name, int money)
            //{
            //    Card card = new Card();
            //    Reads read = new Reads();
            //    List<Card> userHand;
            //    List<Card> dealerHand = new List<Card>();

            //    int betAmount = 0;
            //    string[] choice = { "1. For Hit: ", "2. for Stay: " };
            //    string[] repeat = { "1. Play again\n", "2. Quit\n" };

            //    string info = $"\n \n \n \n \n \n \n \n \n \nCards in the deck: {RemainingCards()} \n{name}'s Money Count: {money} \nCurrent Bet: {betAmount}";
            //    bool loop = true;
            //    bool menu = true;
            //    int oot2;
            //    if (RemainingCards() < 20)
            //    {
            //        Initialize();
            //        Shuffle();

            //    }


            //    while (menu == true)
            //    {
            //        Console.Write($"You have ${money}.\nHow much would you like to bet? ");
            //        string input = Console.ReadLine().Trim().Replace(" ", " ");
            //        if(money <= 0)
            //        {
            //            string[] loser = { "You have no money to bet!", "Please press 2 to exit: "};
            //            read.ReadChoice(ref loser, out oot2);
            //            if(oot2 != 2)
            //            {
            //                Console.WriteLine("You are a loser, please leave.");
            //            }else if(oot2 == 2)
            //            {
            //                Environment.Exit(2);
            //            }
            //        }

            //        Console.Clear();

            //        if (Int32.TryParse(input, out betAmount) || betAmount > 0 || betAmount < money)
            //        {

            //        }
            //        while (!Int32.TryParse(input, out betAmount) || betAmount < 1 || betAmount > money)
            //        {
            //            Console.Write("That is not a correct response, try again. How much would you like to bet? ");
            //            int bet = Convert.ToInt32(Console.ReadLine());

            //            if (bet > 0 || bet < money)
            //            {

            //                Console.Clear();
            //                break;
            //            }


            //        }


              


            //        while (loop == true)
            //        {
            //            userHand = new List<Card>();
            //            userHand.Add(DrawCard());
            //            userHand.Add(DrawCard());


            //            Console.WriteLine($"{name}'s Hand");
            //            Console.WriteLine("Dealing...");
            //            Thread.Sleep(1500);
            //            Console.WriteLine("Card 1: {0} of {1}", userHand[0].face, userHand[0].suits);
            //            Thread.Sleep(1500);
            //            Console.WriteLine("Card 2: {0} of {1}", userHand[1].face, userHand[1].suits);
            //            Console.WriteLine("Total: {0}\n", userHand[0].value + userHand[1].value);

            //            dealerHand = new List<Card>();
            //            dealerHand.Add(DrawCard());
            //            dealerHand.Add(DrawCard());

            //            foreach (Card dealercard in dealerHand)
            //            {
            //                if (dealercard.face == Face.Ace)
            //                {
            //                    dealercard.value += 10;
            //                    break;
            //                }
            //            }

            //            Console.WriteLine("Dealer's Hand");
            //            Thread.Sleep(1500);
            //            Console.WriteLine("Card 1: {0} of {1}", dealerHand[0].face, dealerHand[0].suits);
                       






            //            Console.WriteLine($"\n \n \n \n \n \n \n \n \n \nCards in the deck: {RemainingCards()} \n{name}'s Money Count: ${money} \nCurrent Bet: ${betAmount}" + "\n");

                       

            //            int count = userHand[0].value + userHand[1].value;
            //            read.ReadChoice(ref choice, out oot2);
            //            foreach (Card usercard in userHand)
            //            {
            //                if (usercard.face == Face.Ace)
            //                {
            //                    if (count > 10)
            //                    {
            //                        usercard.value = 1;
            //                        break;

            //                    }
            //                    else if (count < 10)
            //                    {
            //                        usercard.value = 11;
            //                        break;
            //                    }
            //                }
            //            }

            //            if (oot2 == 1)
            //            {
            //                userHand.Add(DrawCard());

            //                while (oot2 == 1)
            //                {

            //                    userHand.Add(DrawCard());
            //                    foreach (Card card2 in userHand)
            //                    {
            //                        userHand.Add(DrawCard());
            //                        count = count + card2.value;
            //                        Console.WriteLine($"{card2.face} of {card2.suits}");

            //                        break;
            //                    }
            //                    if (count > 21)
            //                    {

            //                        break;
            //                    }




            //                    Console.WriteLine($"Card Count: {count}" + "\n");


            //                    read.ReadChoice(ref choice, out oot2);
            //                    if (oot2 == 2)
            //                        break;




            //                }



            //            }
            //            else if (oot2 == 2)
            //            {
            //                Thread.Sleep(1000);
            //                Console.WriteLine("\n" + "Dealer Card 2: {0} of {1}", dealerHand[1].face, dealerHand[1].suits);
                            
            //                int dealerTotal = dealerHand[0].value + dealerHand[1].value;
            //                Console.WriteLine($"Dealer card count: {dealerTotal}");
            //                if (dealerTotal < 17)
            //                {
            //                    while (dealerTotal < 17)
            //                    {
            //                        dealerHand.Add(DrawCard());
            //                        Thread.Sleep(1000);
            //                        foreach (Card usercard in dealerHand)
            //                        {
            //                            if (usercard.face == Face.Ace)
            //                            {
            //                                if (count > 10)
            //                                {
            //                                    usercard.value = 1;
            //                                    break;

            //                                }
            //                                else if (count < 10)
            //                                {
            //                                    usercard.value = 11;
            //                                    break;
            //                                }
            //                            }
            //                        }
            //                        foreach (Card card3 in dealerHand)
            //                        {
            //                            dealerTotal = dealerTotal + card3.value;
            //                            Thread.Sleep(1000);

            //                            Console.WriteLine($"{card3.face} of {card3.suits}");
            //                            Console.Write($"Dealer Total: {dealerTotal} ");

            //                            if (dealerTotal == 17 && dealerTotal > count && dealerTotal < 21)
            //                            {

            //                                money = money - betAmount;
            //                                break;
            //                            }
            //                            if (dealerTotal > 21)
            //                            {
            //                                Console.WriteLine("Dealer busted!");
            //                                money = money + betAmount;

            //                                break;

            //                            }

            //                        }

            //                        if (dealerTotal >= 17)
            //                        {

            //                            break;
            //                        }




            //                    }
            //                }


            //                if (dealerTotal > 21)
            //                {

            //                    break;
            //                }

            //                else if (count > dealerTotal)
            //                {
            //                    Console.WriteLine($"Card Count: {count}" + "\n");
            //                    Console.WriteLine("\n" + $"{name} wins!!!!");
            //                    money = money + betAmount;
            //                    break;
            //                }
            //                else if (count < dealerTotal)
            //                {

            //                    Console.WriteLine($"Card Count: {count}" + "\n");
            //                    Console.WriteLine("Dealer wins.");

            //                    break;
            //                }
            //                else if (dealerTotal == count)
            //                {

            //                    Console.WriteLine("It's a push!");
            //                    break;
            //                }


            //            }
            //            if (count > 21)
            //            {
            //                Console.WriteLine($"Card Count: {count}" + "\n");
            //                Console.WriteLine("You busted!");
            //                money = money - betAmount;
            //                break;

            //            }

                      


            //        }

            //        read.ReadChoice(ref repeat, out oot2);
            //        if (oot2 == 1)
            //        {
            //            Console.Clear();
            //        }
            //        else if (oot2 == 2)
            //        {
            //            Environment.Exit(2);
            //        }



            //    }
            //    return Count(info);
            //}
            //private int Count(string words)
            //{
            //    int count = 0;
            //    bool loop = true;

            //    while (loop == true)
            //    {
            //        Console.WriteLine(words);
            //    }
            //    return count;
            //}
          

        }
    }
}
