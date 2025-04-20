using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();
            deck.shuffle();

            var player = new BlackjackHand();
            player.AddCard(deck.dealCard());
            player.AddCard(deck.dealCard());

            Console.WriteLine("Your cards:");
            PrintHand(player);
            Console.WriteLine("Total: " + player.getBlackjackValue());

            if (player.isblackjack())
            {
                Console.WriteLine("Blackjack! You win.");
                return;
            }

            bool playerBusted = false;
            while (true)
            {
                Console.Write("Hit or Stand? (H/S): ");
                var input = Console.ReadLine().ToUpper();

                if (input == "H")
                {
                    var newCard = deck.dealCard();
                    player.AddCard(newCard);
                    Console.WriteLine("You drew: " + newCard.toString());
                    Console.WriteLine("Total: " + player.getBlackjackValue());

                    if (player.isBusted())
                    {
                        Console.WriteLine("You are busted.");
                        playerBusted = true;
                        break;
                    }
                }
                else if (input == "S")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Enter H or S only.");
                }
            }

            if (playerBusted)
                return;

            var dealer = new BlackjackHand();
            dealer.AddCard(deck.dealCard());
            dealer.AddCard(deck.dealCard());

            Console.WriteLine("\nDealer's turn:");
            PrintHand(dealer);
            Console.WriteLine("Dealer total: " + dealer.getBlackjackValue());

            while (dealer.getBlackjackValue() < 17)
            {
                dealer.AddCard(deck.dealCard());
                Console.WriteLine("Dealer draws a card.");
                PrintHand(dealer);
                Console.WriteLine("Dealer total: " + dealer.getBlackjackValue());
            }

            int playerTotal = player.getBlackjackValue();
            int dealerTotal = dealer.getBlackjackValue();

            Console.WriteLine("\nFinal Results:");
            Console.WriteLine("Your total: " + playerTotal);
            Console.WriteLine("Dealer total: " + dealerTotal);

            if (dealer.isBusted())
            {
                Console.WriteLine("Dealer busted. You win.");
            }
            else if (playerTotal > dealerTotal)
            {
                Console.WriteLine("You win.");
            }
            else if (playerTotal < dealerTotal)
            {
                Console.WriteLine("Dealer wins.");
            }
            else
            {
                Console.WriteLine("It's a tie.");
            }

            Console.ReadLine();
        }

        static void PrintHand(BlackjackHand hand)
        {
            for (int i = 0; i < hand.getCardCount(); i++)
            {
                Console.WriteLine(hand.getCard(i).toString());
            }
        }
    }
}



