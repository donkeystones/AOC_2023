using Challenges.Day1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges_test.Day1 {
    public class CalibratorParserTest {
        [SetUp]
        public void Setup() {

        }

        [Test]
        public void ParseTwelveFromString() {
            string test_string = "1a1bc2";

            int res = CalibratorParser.ParseLine(test_string);

            Assert.AreEqual(12, res);
        }

        [Test]
        public void ParseTwoLinesAndReturnSumOfThirtyFour() {
            string test_string = "1a1bc2\nabc2aj6dlk2";

            int res = CalibratorParser.ReturnSumOfCalibratorData(test_string);

            Assert.AreEqual(34, res);
        }

        [Test]
        public void ParseFiveLinesReturnSumOfFiftyFive() {
            string test_string = "1abc1\nsdfsdf1abc1\n1abc1fdsfsd\n1afdsbc1\na1abc1\n";

            int res = CalibratorParser.ReturnSumOfCalibratorData(test_string);
            
            Assert.AreEqual(55, res);
        }

        [Test]
        public void RunDayOneWithMainDataPartOne() {
            string data = File.ReadAllText("Day1/input.txt");
            int res = CalibratorParser.ReturnSumOfCalibratorData(data);
            Assert.AreEqual(54990, res);
        }

        //--------------------- PART 2 -----------------------
        [Test]
        public void ParseLineUpgradedTwelveFromString() {
            string test_string = "one1two";

            int res = CalibratorParser.ParseLineUpgrade(test_string);

            Assert.AreEqual(12, res);
        }

        [Test]
        public void ParseLineUpgradedThirteenFromString() {
            string test_string = "one1twothree";

            int res = CalibratorParser.ParseLineUpgrade(test_string);

            Assert.AreEqual(13, res);
        }

        [Test]
        public void ParseLineUpgradedFourteenFromString() {
            string test_string = "one1two4";

            int res = CalibratorParser.ParseLineUpgrade(test_string);

            Assert.AreEqual(14, res);
        }

        [Test]
        public void ParseTwoLinesUpgradedReturnSumOfFiftyFive() {
            string test_string = "";
        }

    }
}
