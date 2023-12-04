using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges.Day4 {
    public class ScratchCard {

        public static int GetPoints(string scratch_data) {
            int sum = 0;

            string[] scratch_data_arr = scratch_data.Split("\n");

            foreach (string s in scratch_data_arr) {
                if (s != "") {
                    string[] scratch_card_arr = s.Split(": ")[1].Split(" | ");
                    sum += GetScratchCardPoints(scratch_card_arr[0], scratch_card_arr[1]);
                }
            }

            return sum;
        }
        //2^(n-1)
        public static int GetScratchCardPoints(string win_nums, string your_nums) {
            int sum = 0;
            string[] win_nums_arr = win_nums.Split(" ", StringSplitOptions.RemoveEmptyEntries), your_nums_arr = your_nums.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (string win in win_nums_arr) {
                foreach (string your in your_nums_arr) {
                    if (win == your) sum++;
                }
            }

            return (int)(Math.Pow(2, sum - 1));
        }

        public static int GetScratchCards(string win_nums, string your_nums) {
            int sum = 0;
            string[] win_nums_arr = win_nums.Split(" ", StringSplitOptions.RemoveEmptyEntries), your_nums_arr = your_nums.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (string win in win_nums_arr) {
                foreach (string your in your_nums_arr) {
                    if (win == your) sum++;
                }
            }

            return sum;
        }

        public static int TotalScratchCards(string scratch_data) {
            int sum = 0;
            string[] scratch_data_arr = scratch_data.Split("\n");
            List<Card> scratch_cards = new List<Card>();
            foreach (string s in scratch_data_arr) {
                if (s != "") {
                    string[] scratch_card_arr = s.Split(": ")[1].Split(" | ");
                    scratch_cards.Add(new Card() { Win = scratch_card_arr[0], Your = scratch_card_arr[1] });
                }
            }

            for (int i = 0; i < scratch_cards.Count; i++) {
                int points = GetScratchCards(scratch_cards[i].Win, scratch_cards[i].Your);
                for (int j = i+1; j <= points + i; j++) {
                    scratch_cards[j].Instances += scratch_cards[i].Instances;
                }
                sum += scratch_cards[i].Instances;
            }

            return sum;
        }
    }

    public class Card {
        public int Instances { get; set; }

        public Card() {
            Instances = 1;
        }

        public string Win { get; set; }
        public string Your { get; set; }

    }
}
