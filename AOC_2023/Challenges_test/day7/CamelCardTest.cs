using Challenges.day7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Challenges_test.day7 {
    public class CamelCardTest {
        [Test]
        public void GetLabelValueOfLabel2SHouldReturn0() {
            char label = '2';

            int res = CamelCard.GetLabelValue(label);

            Assert.AreEqual(0, res);
        }

        [Test]
        public void GetLabelValueOfLabelASHouldReturn12() {
            char label = 'A';

            int res = CamelCard.GetLabelValue(label);

            Assert.AreEqual(12, res);
        }

        [Test]
        public void GetLabelValueOfLabelKShouldReturn11() {
            char label = 'K';

            int res = CamelCard.GetLabelValue(label);

            Assert.AreEqual(11, res);
        }

        [Test]
        public void GetHandTypeAAAAAReturnsFiveOfAKind() {
            string hand = "AAAAA";

            HandType type = CamelCard.GetHandType(hand);

            Assert.AreEqual(HandType.FiveOfAKind, type);
        }

        [Test]
        public void GetHandTypeKKKKKReturnsFiveOfAKind() {
            string hand = "KKKKK";

            HandType type = CamelCard.GetHandType(hand);

            Assert.AreEqual(HandType.FiveOfAKind, type);
        }

        [Test]
        public void GetHandType22222ReturnsFiveOfAKind() {
            string hand = "22222";

            HandType type = CamelCard.GetHandType(hand);

            Assert.AreEqual(HandType.FiveOfAKind, type);
        }

        [Test]
        public void GetHandType2222AReturnsFourOfAKind() {
            string hand = "2222A";

            HandType type = CamelCard.GetHandType(hand);

            Assert.AreEqual(HandType.FourOfAKind, type);
        }

        [Test]
        public void GetHandType22A22ReturnsFourOfAKind() {
            string hand = "22A22";

            HandType type = CamelCard.GetHandType(hand);

            Assert.AreEqual(HandType.FourOfAKind, type);
        }

        [Test]
        public void GetHandTypeA2222ReturnsFourOfAKind() {
            string hand = "A2222";

            HandType type = CamelCard.GetHandType(hand);

            Assert.AreEqual(HandType.FourOfAKind, type);
        }

        [Test]
        public void GetHandTypeAA222ReturnsFullHouse() {
            string hand = "AA222";

            HandType type = CamelCard.GetHandType(hand);

            Assert.AreEqual(HandType.FullHouse, type);
        }

        [Test]
        public void GetHandType2AA22ReturnsFullHouse() {
            string hand = "2AA22";

            HandType type = CamelCard.GetHandType(hand);

            Assert.AreEqual(HandType.FullHouse, type);
        }

        [Test]
        public void GetHandType22AA2ReturnsFullHouse() {
            string hand = "22AA2";

            HandType type = CamelCard.GetHandType(hand);

            Assert.AreEqual(HandType.FullHouse, type);
        }

        [Test]
        public void GetHandType222AAReturnsFullHouse() {
            string hand = "222AA";

            HandType type = CamelCard.GetHandType(hand);

            Assert.AreEqual(HandType.FullHouse, type);
        }

        [Test]
        public void GetHandType22234ReturnsThreeOfKind() {
            string hand = "22234";

            HandType type = CamelCard.GetHandType(hand);

            Assert.AreEqual(HandType.ThreeOfAKind, type);
        }

        [Test]
        public void GetHandType32224ReturnsThreeOfKind() {
            string hand = "32224";

            HandType type = CamelCard.GetHandType(hand);

            Assert.AreEqual(HandType.ThreeOfAKind, type);
        }

        [Test]
        public void GetHandType34222ReturnsThreeOfKind() {
            string hand = "34222";

            HandType type = CamelCard.GetHandType(hand);

            Assert.AreEqual(HandType.ThreeOfAKind, type);
        }

        [Test]
        public void GetHandType22334ReturnsTwoPair() {
            string hand = "22334";

            HandType type = CamelCard.GetHandType(hand);

            Assert.AreEqual(HandType.TwoPair, type);
        }

        [Test]
        public void GetHandType22343ReturnsTwoPair() {
            string hand = "22343";

            HandType type = CamelCard.GetHandType(hand);

            Assert.AreEqual(HandType.TwoPair, type);
        }
        [Test]
        public void GetHandType23423ReturnsTwoPair() {
            string hand = "23423";

            HandType type = CamelCard.GetHandType(hand);

            Assert.AreEqual(HandType.TwoPair, type);
        }

        [Test]
        public void GetHandType23425ReturnsOnePair() {
            string hand = "23425";

            HandType type = CamelCard.GetHandType(hand);

            Assert.AreEqual(HandType.OnePair, type);
        }

        [Test]
        public void GetHandType23265ReturnsOnePair() {
            string hand = "23265";

            HandType type = CamelCard.GetHandType(hand);

            Assert.AreEqual(HandType.OnePair, type);
        }

        [Test]
        public void GetHandType23456ReturnsHighHouse() {
            string hand = "23265";

            HandType type = CamelCard.GetHandType(hand);

            Assert.AreEqual(HandType.OnePair, type);
        }

        [Test]
        public void CheckHighCardReturnsTrue() {
            string hand = "23456";

            Assert.IsTrue(CamelCard.CheckHighCard(hand));
        }

        [Test]
        public void CheckHighCardReturnsTrueOnlyLetters()
        {
            string hand = "TJQKA";

            Assert.IsTrue(CamelCard.CheckHighCard(hand));
        }

        [Test]
        public void CheckHighCardReturnsFalse() {
            string hand = "24569";

            Assert.IsFalse(CamelCard.CheckHighCard(hand));
        }

        [Test]
        public void CategorizeCards() {
            string hands = "32T3K 765\r\nT55J5 684\r\nKK677 28\r\nKTJJT 220\r\nQQQJA 483";

            CategorizedHandTypeList catList = CamelCard.CategorizeCards(hands);

            Assert.AreEqual(0, catList.HighCard.Count);
            Assert.AreEqual(1, catList.OnePair.Count);
            Assert.AreEqual(2, catList.TwoPair.Count);
            Assert.AreEqual(2, catList.ThreeOfKind.Count);
            Assert.AreEqual(0, catList.FullHouse.Count);
            Assert.AreEqual(0, catList.FourOfKind.Count);
            Assert.AreEqual(0, catList.FiveOfKind.Count);
        }

        [Test]
        public void SortCategorizedHandTypeLists() {
            string hands = "32T3K 765\r\nT55J5 684\r\nKK677 28\r\nKTJJT 220\r\nQQQJA 483";

            CategorizedHandTypeList catList = CamelCard.CategorizeCards(hands);
            catList = CamelCard.SortCategorizedHandTypeLists(catList);

            Assert.AreEqual("32T3K", catList.OnePair[0].hand);
            Assert.AreEqual("KTJJT", catList.TwoPair[0].hand);
            Assert.AreEqual("KK677", catList.TwoPair[1].hand);
            Assert.AreEqual("T55J5", catList.ThreeOfKind[0].hand);
            Assert.AreEqual("QQQJA", catList.ThreeOfKind[1].hand);
        }

        [Test]
        public void GetTotalWinnings()
        {
            string hands = "32T3K 765\r\nT55J5 684\r\nKK677 28\r\nKTJJT 220\r\nQQQJA 483";

            CategorizedHandTypeList catList = CamelCard.CategorizeCards(hands);
            catList = CamelCard.SortCategorizedHandTypeLists(catList);

            int total_winning = CamelCard.CalculateTotalWinnings(catList);

            Assert.AreEqual(6440, total_winning);
        }

        [Test]
        public void GetTotalWinningsPart1() {
            string data = File.ReadAllText("day7/input.txt");

            CategorizedHandTypeList catList = CamelCard.CategorizeCards(data);
            catList = CamelCard.SortCategorizedHandTypeLists(catList);

            int total_winning = CamelCard.CalculateTotalWinnings(catList);
            Assert.AreEqual(250370104, total_winning);
        }

    }
}
