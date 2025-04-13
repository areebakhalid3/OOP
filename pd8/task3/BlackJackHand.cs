using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    public class BlackjackHand:Hand
    {
        public int getBlackjackValue()
        {
            int total = 0;
            int aceCount = 0;

            for (int i = 0; i < getCardCount(); i++)
            {
                Card card = getCard(i);
                int value = card.getValue();

                if (value > 10)
                {
                    total += 10;
                }
                else if (value == 1)
                {
                    total += 1;
                    aceCount++;
                }
                else
                {
                    total += value;
                }
            }

            while (aceCount > 0 && total + 10 <= 21)
            {
                total += 10;
                aceCount--;
            }

            return total;
        }
        public bool isblackjack()
        {
            if (getCardCount() == 2)
            {
                int val = getBlackjackValue();
                if(val == 21)
                {
                    return true;
                }
            }
            return false;
        }

        public bool isBusted()
        {
            return getBlackjackValue() > 21;
        }
    }
}
