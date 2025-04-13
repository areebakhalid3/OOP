using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2.BL
{
        internal class Deck
        {
            private int count;
            private Card[] deck = new Card[52];
            public Deck()
            {
            
            count = 0;
                for (int i = 1; i <= 4; i++)
                {
                    for (int j = 1; j <= 13; j++)
                    {
                        deck[count] = new Card(j, i);
                        count++;
                    }
                }
            }
            public void shuffle()
            {
                System.Random rand = new System.Random();
                Card temp;
                for (int i = 0; i < 52; i++)
                {
                    int num = rand.Next(0, 52);
                    temp = deck[num];
                    deck[num] = deck[i];
                    deck[i] = temp;
                }
                count = 52;
            }

            public Card dealCard()
            {
                if (count > 0)
                {
                    count--;
                    return deck[count];
                }
                else
                {
                    return null;
                }
            }

            public int cardsLeft()
            {
                return count;
            }
        }
    }

