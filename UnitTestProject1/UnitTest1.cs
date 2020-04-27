using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary;


namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAce()
        {
            Cards.Card card = new Cards.Card();
            Cards.Deck deck = new Cards.Deck();
            Hand hand = new Hand();
            string name = "";
            int count = 0;
            card.face = Cards.Face.Ace;
            hand.Play(name, count);
            Assert.AreEqual(8, deck.DrawCard());
            Assert.AreEqual(1, deck.DrawCard());
            Assert.AreEqual(1, card.face);
            Assert.AreEqual(8, card.face);
            Assert.AreEqual(10, deck.DrawCard());
            
        }
       
    }
}
