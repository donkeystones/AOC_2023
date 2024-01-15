using Challenges.Day3;
using Challenges.Day4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges_test.Day4 {
    public class ScratchCardTest {

        [Test]
        public void ScratchCardWithZeroPoints() {
            string data = "Card 1: 1 2 3 4 5 | 6 7 8 9 10";

            int res = ScratchCard.GetPoints(data);

            Assert.AreEqual(0, res);
        }

        [Test]
        public void ScratchCardWithOnePoints() {
            string data = "Card 1: 1 2 3 4 5 | 5 6 7 8 9 10";

            int res = ScratchCard.GetPoints(data);

            Assert.AreEqual(1, res);
        }

        [Test]
        public void ScratchCardWithTwoPoints() {
            string data = "Card 1: 1 2 3 4 5 6 | 5 6 7 8 9 10";

            int res = ScratchCard.GetPoints(data);

            Assert.AreEqual(2, res);
        }

        [Test]
        public void ScratchCardWithFourPoints() {
            string data = "Card 1: 1 2 3 4 5 6 | 4 5 6 7 8 9 10";

            int res = ScratchCard.GetPoints(data);

            Assert.AreEqual(4, res);
        }

        [Test]
        public void ScratchCardWithEightPoints() {
            string data = "Card 1: 1 2 3 4 5 6 | 3 4 5 6 7 8 9 10";

            int res = ScratchCard.GetPoints(data);

            Assert.AreEqual(8, res);
        }

        [Test]
        public void Part1TestData() {
            string data = "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53\nCard 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19\nCard 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1\nCard 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83\nCard 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36\nCard 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11";

            int res = ScratchCard.GetPoints(data);

            Assert.AreEqual(13, res);
        }

        public void Part1() {
            string data = File.ReadAllText("Day4/input.txt");

            int res = ScratchCard.GetPoints(data);

            Assert.AreEqual(20407, res);
        }

        [Test]
        public void Part2TestData() {
            string data = "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53\nCard 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19\nCard 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1\nCard 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83\nCard 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36\nCard 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11";

            int res = ScratchCard.TotalScratchCards(data);

            Assert.AreEqual(30, res);
        }

        [Test]
        public void Part2() {
            string data = File.ReadAllText("Day4/input.txt");

            int res = ScratchCard.TotalScratchCards(data);

            Console.WriteLine(res);
        }
    }
}
