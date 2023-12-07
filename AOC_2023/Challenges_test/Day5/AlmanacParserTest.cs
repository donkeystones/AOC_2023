using Challenges.Day5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Challenges_test.Day5 {
    public class AlmanacParserTest {
        [Test]
        public void Part1TestData() {
            string data = File.ReadAllText("Day5/testdata.txt");

            BigInteger res = AlmanacParser.GetLowestPart1(data);

            Assert.IsTrue(new BigInteger(35).Equals(res));
        }

        [Test] public void Part1() {
            string data = File.ReadAllText("Day5/input.txt");

            BigInteger res = AlmanacParser.GetLowestPart1(data);

            Console.WriteLine(res.ToString());
            Assert.IsTrue(new BigInteger(910845529).Equals(res));
        }

        [Test] public void Part2testdata() {
            string data = File.ReadAllText("Day5/testdata.txt");

            BigInteger res = AlmanacParser.GetLowestPart2version2(data);
            Console.WriteLine(res);
            Assert.IsTrue(new BigInteger(46).Equals(res));
        }
    }
}
