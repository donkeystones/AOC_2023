using Challenges.Day2;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Challenges_test.Day2 {
    public class CubeConundrumTest {

        [SetUp] 
        public void SetUp() { 
        
        }

        [Test]
        public void ValidateSuccessfullGame() {
            string test_data = "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green";
            int res = CubeConundrum.SolveGame(test_data, false);
            Assert.AreEqual(1, res);
        }

        [Test]
        public void ValidateUnsuccessfullGame() {
            string test_data = "Game 1: 3 blue, 34 red; 1 red, 2 green, 6 blue; 2 green";
            int res = CubeConundrum.SolveGame(test_data, false);
            Assert.AreEqual(0, res);
        }

        [Test]
        public void ValidateGameWithMaxValue() {
            string test_data = "Game 1: 1 blue, 1 red, 1 green; 12 red, 13 green, 14 blue";
            int res = CubeConundrum.SolveGame(test_data, false);
            Assert.AreEqual(1, res);
        }

        [Test]
        public void SolveCubeValueWithTestData() {
            string data = "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green\nGame 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue\nGame 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red\nGame 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red\nGame 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green";
            int res = CubeConundrum.SolvePossibleGamesCubeValue(data, false);
            Assert.AreEqual(8, res);
        }

        [Test]
        public void SolveCubeValueTest() {
            string data = File.ReadAllText("Day2/input.txt");

            int res = CubeConundrum.SolvePossibleGamesCubeValue(data, false);

            Assert.AreEqual(1931, res);
        }

        [Test]
        public void SolvePowerOfSmallestCubeWithTestData() {
            string data = "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green\nGame 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue\nGame 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red\nGame 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red\nGame 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green";
            int res = CubeConundrum.SolvePossibleGamesCubeValue(data, true);
            Assert.AreEqual(2286, res);
        }

        [Test]
        public void SolvePowerOfSmallestCubeWithRealData() {
            string data = File.ReadAllText("Day2/input.txt");

            int res = CubeConundrum.SolvePossibleGamesCubeValue(data, true);

            Console.WriteLine(res);
        }
    }
}
