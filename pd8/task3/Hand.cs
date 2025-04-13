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

        public void RemoveCard(Card c)
        {
            if (c != null && cards.Contains(c))
            {
                cards.Remove(c);
            }
        }
        public void removeCard(int position) //removes from specific position
        {
            if (position > 0 && position < cards.Count())
            {
               cards.RemoveAt(position);
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

        public void sortBySuit()
        {
            for (int i = 0; i < cards.Count - 1; i++)
            {
                for (int j = i + 1; j < cards.Count; j++)
                {
                    Card c1 = cards[i];
                    Card c2 = cards[j];

                    if (c1.getSuit() > c2.getSuit())
                    {
                        Card temp = cards[i];
                        cards[i] = cards[j];
                        cards[j] = temp;
                    }
                    else if (c1.getSuit() == c2.getSuit())
                    {
                        if (c1.getValue() > c2.getValue())
                        {
                            Card temp = cards[i];
                            cards[i] = cards[j];
                            cards[j] = temp;
                        }
                    }
                }
            }
        }

        public void sortByValue()
        {
            for (int i = 0; i < cards.Count - 1; i++)
            {
                for (int j = i + 1; j < cards.Count; j++)
                {
                    Card c1 = cards[i];
                    Card c2 = cards[j];

                    if (c1.getValue() > c2.getValue())
                    {
                        Card temp = cards[i];
                        cards[i] = cards[j];
                        cards[j] = temp;
                    }
                    else if (c1.getValue() == c2.getValue())
                    {
                        if (c1.getSuit() > c2.getSuit())
                        {
                            Card temp = cards[i];
                            cards[i] = cards[j];
                            cards[j] = temp;
                        }
                    }
                }
            }
        }


    }
}
