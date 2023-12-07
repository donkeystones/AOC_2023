using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges.day7 {
    public enum HandType
    {
        FiveOfAKind = 7,
        FourOfAKind = 6,
        FullHouse = 5,
        ThreeOfAKind = 4,
        TwoPair = 3,
        OnePair = 2,
        HighCard = 1,
        NoType
    }
    public class CamelCard {
        private static char[] labels = { '2', '3', '4', '5', '6', '7', '8', '9', 'T', 'J', 'Q', 'K', 'A' };

        public static HandType GetHandType(string hand) {

            //FiveOfKind
            if (hand[0] == hand[1] &&
                hand[0] == hand[2] &&
                hand[0] == hand[3] &&
                hand[0] == hand[4]) return HandType.FiveOfAKind;

            int[] label_occurance = CountLabelOccurence(hand);

            //FourOfKind
            if (label_occurance.Length == 2 &&
                 label_occurance[0] == 1 &&
                 label_occurance[1] == 4)
                return HandType.FourOfAKind;

            //FullHouse
            else if (label_occurance[0] == 2 &&
                     label_occurance[1] == 3) return HandType.FullHouse;

            //ThreeOfKind
            else if (label_occurance[0] == 1 &&
                     label_occurance[1] == 1 &&
                     label_occurance[2] == 3) return HandType.ThreeOfAKind;

            //TwoPair
            else if (label_occurance[0] == 1 &&
                     label_occurance[1] == 2 &&
                     label_occurance[2] == 2) return HandType.TwoPair;

            //OnePair
            else if (label_occurance[0] == 1 &&
                     label_occurance[1] == 1 &&
                     label_occurance[3] == 1 &&
                     label_occurance[4] == 2) return HandType.OnePair;

            else if(CheckHighCard(hand)) return HandType.HighCard; //OB TODO: If cards are not in order.

            return HandType.NoType;
        }

        public static bool CheckHighCard(string hand) {
            int last = int.Parse(hand[0].ToString());
            for(int i = 1; i < hand.Length; i++) {
                Console.WriteLine("last + i = " + (last + i) + " hand[i] = " + hand[i]);
                if (!hand[i].ToString().Equals((last+i).ToString())) return false;
            }

            return true;
        }

        public static int[] CountLabelOccurence(string hand) {
            Dictionary<char, int> label_occurance = new Dictionary<char, int>();
            foreach(char label in hand) {
                if (label_occurance.ContainsKey(label)) label_occurance[label]++;
                else label_occurance[label] = 1;
            }

            List<int> label_occurance_numbers = new List<int>();

            foreach(KeyValuePair<char, int> label in label_occurance) {
                label_occurance_numbers.Add(label.Value);
            }
            
            label_occurance_numbers.Sort();

            return label_occurance_numbers.ToArray();
        }

        public static int GetLabelValue(char label) {
            return Array.IndexOf(labels, label);
        }
    }
}
