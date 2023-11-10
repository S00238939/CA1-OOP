using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    internal class calculations
    {
        public static string drawCard(int Rng)
        {
      
            string[] cardType = { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };
            
            string Card = cardType[Rng];
            return Card;
        }
        public static int cardValue(int Rng)
        {
            int[] value = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10 };
            return value[Rng];
        }
    }
}
