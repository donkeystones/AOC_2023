using Challenges.day6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Challenges_test.day6 {
    public class RaceTest {
        [Test]
        public void Part1TestData() {
            string data = File.ReadAllText("day6/testdata.txt");

            BigInteger res = race.Part1(data);

            Assert.IsTrue(new BigInteger(288).Equals(res));
        }

        [Test] public void Part1() {
            string data = File.ReadAllText("day6/input.txt");

            BigInteger res = race.Part1(data);

            Assert.IsTrue(new BigInteger(303600).Equals(res));
        }

        [Test] public void Part2() {
            string data = File.ReadAllText("day6/input.txt");

            BigInteger res = race.Part2(data);

            Assert.IsTrue(new BigInteger(23654842).Equals(res));
        }
    }
}
