using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class Program
    {
        static void Main(string[] args)
        {
            Random rng = new Random();                                                              // random number generator
            int currentRng = 0;

            string cardDrawn;
            int totalCardValue = 0;                                                                 // player total card value

            int totalDealerValue = 0;                                                               // dealer total card value

            bool Play = true;                                                                       // bool to stop game if set to false
            string option1 = "y";

            bool Offer = true;                                                                      // bool that allows player and dealer to choose another card
            string option2 = "";

            while (Play == true)                                                                    // while play is true the game will loop
            {
                currentRng = rng.Next(13);                                                          // getting random value between 1 and 13
                cardDrawn = calculations.drawCard(currentRng);                                      // using method from another class
                if (calculations.cardValue(currentRng) == 1 && (totalCardValue + 11) <= 21)         // checking value of ace
                {
                    totalCardValue = totalCardValue + 11;                                           // applying max ace value
                }
                else
                {
                    totalCardValue = totalCardValue + calculations.cardValue(currentRng);           // adding return value to total card value
                }
                Console.WriteLine("Your card is " + cardDrawn);                                     // displaying card details

                currentRng = rng.Next(13);                                                          // repeat
                cardDrawn = calculations.drawCard(currentRng);
                if (calculations.cardValue(currentRng) == 1 && (totalCardValue + 11) <= 21)
                {
                    totalCardValue = totalCardValue + 11;
                }
                else
                {
                    totalCardValue = totalCardValue + calculations.cardValue(currentRng);
                }
                Console.WriteLine("Your card is " + cardDrawn);
                Console.WriteLine();

                Console.WriteLine("Your total is " + totalCardValue);                               // display total card value
                Console.WriteLine();

                Console.WriteLine("would you like to stick or twist ? s/t");                        // prompt player for option 2

                if (totalCardValue < 21)                                                            // only give player offer if they have not reached 21+
                {
                    Offer = true;
                }
                else
                {
                    Offer = false;
                }

                while (Offer == true)                                                               // while the player has the offer this will loop
                {
                    option2 = Console.ReadLine();                                                   // read input and store it in option 2

                    if (option2 == "t")                                                             // if user inputs t then the player will draw another card
                    {
                        currentRng = rng.Next(13);
                        cardDrawn = calculations.drawCard(currentRng);
                        if (calculations.cardValue(currentRng) == 1 && (totalCardValue + 11) <= 21)
                        {
                            totalCardValue = totalCardValue + 11;
                        }
                        else
                        {
                            totalCardValue = totalCardValue + calculations.cardValue(currentRng);
                        }
                        Console.WriteLine("Your card is " + cardDrawn);
                        Console.WriteLine();

                        Console.WriteLine("Your total is " + totalCardValue);
                    }                                                                               // if the user  inputs s then it will set offer to false moving on to dealer
                    else if (option2 == "s")
                    {
                        Offer = false;
                    }

                    if (totalCardValue < 21 && Offer == true)
                    {
                        Offer = true;
                        Console.WriteLine("would you like to stick or twist ? s/t");
                    }
                }

                Console.WriteLine("Your total is " + totalCardValue);
                Console.WriteLine();

                currentRng = rng.Next(13);
                cardDrawn = calculations.drawCard(currentRng);
                if (calculations.cardValue(currentRng) == 1 && (totalDealerValue + 11) <= 21)
                {
                    totalDealerValue = totalDealerValue + 11;
                }
                else
                {
                    totalDealerValue = totalDealerValue + calculations.cardValue(currentRng);
                }
                Console.WriteLine("Dealer card is " + cardDrawn);

                currentRng = rng.Next(13);
                cardDrawn = calculations.drawCard(currentRng);
                if (calculations.cardValue(currentRng) == 1 && (totalDealerValue + 11) <= 21)
                {
                    totalDealerValue = totalDealerValue + 11;
                }
                else
                {
                    totalDealerValue = totalDealerValue + calculations.cardValue(currentRng);
                }
                Console.WriteLine("Dealer card is " + cardDrawn);

                Console.WriteLine("Dealer total is " + totalDealerValue);
                Console.WriteLine();
                Offer = true;
                while (Offer == true)
                {
                    if (totalCardValue > totalDealerValue && totalDealerValue != 21 && totalCardValue < 21)
                    {
                        currentRng = rng.Next(13);
                        cardDrawn = calculations.drawCard(currentRng);
                        if (calculations.cardValue(currentRng) == 1 && (totalDealerValue + 11) <= 21)
                        {
                            totalDealerValue = totalDealerValue + 11;
                        }
                        else
                        {
                            totalDealerValue = totalDealerValue + calculations.cardValue(currentRng);
                        }
                        Console.WriteLine("Dealer card is " + cardDrawn);

                        Console.WriteLine("Dealer total is " + totalDealerValue);
                        Console.WriteLine();
                    }
                    else
                    {
                        Offer = false;
                    }
                }
                if (totalCardValue == totalDealerValue)
                {
                    Console.WriteLine("DRAW!");
                }
                else if ((totalCardValue > totalDealerValue && totalCardValue <= 21) || (totalCardValue == 21) || (totalDealerValue > 21))
                {
                    Console.WriteLine("Player Wins!");
                }
                else if ((totalDealerValue > totalCardValue && totalDealerValue <= 21) || (totalDealerValue == 21) || (totalCardValue > 21))
                {
                    Console.WriteLine("Dealer Wins!");
                }
                else
                {
                    Console.WriteLine("ERROR");
                }
                Console.WriteLine();

                Console.WriteLine("Do you wish to play again ? y/n");
                option1 = Console.ReadLine();
                
            if (option1 == "n")
            {
                Play = false;
            }
            else
            {
                totalCardValue = 0;
                totalDealerValue = 0;
                Play = true;
            }
            }
        }
    }
}
