using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    public class Hand
    {
        private List<Card> cards;
        public Hand()
        {
            cards = new List<Card>();
        }

 
        public void clear()
        {
            cards.Clear();
        }

        public void AddCard(Card c)
        {
            if (c != null)
            {
                cards.Add(c);
            }
        }

        public int getCardCount()
        {
            return cards.Count();
}

        public Card getCard(int position)
        {
            if (position >= 0 && position < cards.Count)
            {
                return cards[position];
            }
            return null;
        }


   

    }
}
