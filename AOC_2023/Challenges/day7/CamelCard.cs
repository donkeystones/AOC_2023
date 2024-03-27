using Microsoft.Win32.SafeHandles;
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
    public class Hand {
        public HandType type { get; set; }
        public string hand { get; set; }
        public int bid { get; set; }
    }
    public class CategorizedHandTypeList {
        public List<Hand> FiveOfKind { get; set; }
        public List<Hand> FourOfKind { get; set; }
        public List<Hand> FullHouse { get; set; }
        public List<Hand> ThreeOfKind { get; set; }
        public List<Hand> TwoPair { get; set; }
        public List<Hand> OnePair { get; set; }
        public List<Hand> HighCard { get; set; }

        public CategorizedHandTypeList()
        {
            FiveOfKind = new List<Hand>();
            FourOfKind = new List<Hand>();
            FullHouse = new List<Hand>();
            ThreeOfKind = new List<Hand>();
            TwoPair = new List<Hand>();
            OnePair = new List<Hand>();
            HighCard = new List<Hand>();
        }
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
            char last = hand[0];
            for(int i = 1; i < hand.Length; i++) {
                if (!(GetLabelValue(hand[i]) == GetLabelValue(last) + 1)) return false;
                last = hand[i];
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

        public static CategorizedHandTypeList CategorizeCards(string hands)
        {
            
            string[] hands_arr = hands.Split("\r\n");
            CategorizedHandTypeList catList = new CategorizedHandTypeList();
            foreach(string hand in hands_arr)
            {
                string[] hand_arr = hand.Split(" ");
                Hand curr = new Hand()
                {
                    hand = hand_arr[0],
                    bid = int.Parse(hand_arr[1]),
                    type = GetHandType(hand_arr[0])
                };
                catList = InsertToRightHandCategoryList(curr, catList);
            }

            return catList;
        }

        public static CategorizedHandTypeList InsertToRightHandCategoryList(Hand hand, CategorizedHandTypeList catList) {
            switch(hand.type)
            {
                case HandType.HighCard: 
                    catList.HighCard.Add(hand); 
                    break;
                case HandType.OnePair:
                    catList.OnePair.Add(hand);
                    break;
                case HandType.TwoPair:
                    catList.TwoPair.Add(hand);
                    break;
                case HandType.ThreeOfAKind:
                    catList.ThreeOfKind.Add(hand);
                    break;
                case HandType.FullHouse:
                    catList.FullHouse.Add(hand);
                    break;
                case HandType.FourOfAKind:
                    catList.FourOfKind.Add(hand);
                    break;
                case HandType.FiveOfAKind:
                    catList.FiveOfKind.Add(hand);
                    break;
            }
            return catList;
        }

        public static int GetGreaterValue(Hand a, Hand b)
        {
            char[] a_arr = a.hand.ToCharArray();
            char[] b_arr = b.hand.ToCharArray();
            for(int i = 0; i < a_arr.Length; i++)
            {
                if (a_arr[i] != b_arr[i])
                {
                    if (GetLabelValue(a_arr[i]) > GetLabelValue(b_arr[i])) return 1;
                    else return -1;
                }
            }
            return 0;
        }

        public static List<Hand> SortHandsStrongestToWeakest(List<Hand> handList) {
            List<Hand> temp = handList;
            temp.Sort(GetGreaterValue);
            return temp;
        }

        public static CategorizedHandTypeList SortCategorizedHandTypeLists(CategorizedHandTypeList catList)
        {
            catList.HighCard = SortHandsStrongestToWeakest(catList.HighCard);
            catList.OnePair = SortHandsStrongestToWeakest(catList.OnePair);
            catList.TwoPair = SortHandsStrongestToWeakest(catList.TwoPair);
            catList.ThreeOfKind = SortHandsStrongestToWeakest(catList.ThreeOfKind);
            catList.FullHouse = SortHandsStrongestToWeakest(catList.FullHouse);
            catList.FourOfKind = SortHandsStrongestToWeakest(catList.FourOfKind);
            catList.FiveOfKind = SortHandsStrongestToWeakest(catList.FiveOfKind);
            return catList;
        }

        public static int CalculateTotalWinnings(CategorizedHandTypeList catList)
        {
            int totalWinnings = 0;
            int currentRank = 1;
            if (catList.HighCard.Count > 0)
            {
                totalWinnings += GetWinningsFromList(catList.HighCard, currentRank);
                currentRank += catList.HighCard.Count;
            }
            if (catList.OnePair.Count > 0)
            {
                totalWinnings += GetWinningsFromList(catList.OnePair, currentRank);
                currentRank += catList.OnePair.Count;
            }
            if (catList.TwoPair.Count > 0)
            {
                totalWinnings += GetWinningsFromList(catList.TwoPair, currentRank);
                currentRank += catList.TwoPair.Count;
            }
            if (catList.ThreeOfKind.Count > 0)
            {
                totalWinnings += GetWinningsFromList(catList.ThreeOfKind, currentRank);
                currentRank += catList.ThreeOfKind.Count;
            }
            if (catList.FullHouse.Count > 0)
            {
                totalWinnings += GetWinningsFromList(catList.FullHouse, currentRank);
                currentRank += catList.FullHouse.Count;
            }
            if (catList.FourOfKind.Count > 0)
            {
                totalWinnings += GetWinningsFromList(catList.FourOfKind, currentRank);
                currentRank += catList.FourOfKind.Count;
            }
            if (catList.FiveOfKind.Count > 0)
            {
                totalWinnings += GetWinningsFromList(catList.FiveOfKind, currentRank);
            }

            return totalWinnings;
        }

        public static int GetWinningsFromList(List<Hand> hands, int currentRank)
        {
            int total = 0;
            for(int i = 0; i < hands.Count; i++)
            {
                Console.WriteLine("Check winnings for: " + hands[i].hand + " " + hands[i].bid + ", Type: " + hands[i].type.ToString());
                total += hands[i].bid * (i + currentRank);
            }
            return total;
        }
    }
}
