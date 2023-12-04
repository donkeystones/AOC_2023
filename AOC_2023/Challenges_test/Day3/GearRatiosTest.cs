using Challenges.Day3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges_test.Day3 {
    public class GearRatiosTest {

        //-----------------Load the schematic tests------------------------
        [Test]
        public void ParseInputMapFourByFour() {
            string data = "1...\n*...\n.2..\n...3";

            char[,] schematic = GearRatios.ParseInputSchematic(data);

            Assert.AreEqual(4, schematic.GetLength(0)); //GetLength(0) == Height
            Assert.AreEqual(4, schematic.GetLength(1)); //GetLength(0) == Width
        }

        [Test]
        public void ParseInputMapOneByOne() {
            string data = ".";

            char[,] schematic = GearRatios.ParseInputSchematic(data);

            Assert.AreEqual(1, schematic.GetLength(0)); //GetLength(0) == Height
            Assert.AreEqual(1, schematic.GetLength(1)); //GetLength(0) == Width
        }

        [Test]
        public void ParseInputMapTwoByTwo() {
            string data = "..\n..";

            char[,] schematic = GearRatios.ParseInputSchematic(data);

            Assert.AreEqual(2, schematic.GetLength(0)); //GetLength(0) == Height
            Assert.AreEqual(2, schematic.GetLength(1)); //GetLength(0) == Width
        }

        [Test]
        public void ParseInputMapThreeByOne() {
            string data = ".\n.\n.";

            char[,] schematic = GearRatios.ParseInputSchematic(data);

            Assert.AreEqual(3, schematic.GetLength(0)); //GetLength(0) == Height
            Assert.AreEqual(1, schematic.GetLength(1)); //GetLength(0) == Width
        }
        //-----------------Finding numbers tests------------------------

        [Test]
        public void FindSumOfSchematicNumbersNoNumberFound() {
            string data = "....\n" +
                          ".1..\n" +
                          "....\n" +
                          "....";

            char[,] schematic = GearRatios.ParseInputSchematic(data);

            int res = GearRatios.FindSumOfSchematicNumbers(schematic);

            Assert.AreEqual(0, res);
        }

        [Test]
        public void FindSumOfSchematicNumbersSymbolLeftOfSingleDigit() {
            string data = "....\n" +
                          "*1..\n" +
                          "....\n" +
                          "....";

            char[,] schematic = GearRatios.ParseInputSchematic(data);

            int res = GearRatios.FindSumOfSchematicNumbers(schematic);

            Assert.AreEqual(1, res);
        }

        [Test]
        public void FindSumOfSchematicNumbersSymbolRightOfSingleDigit() {
            string data = "....\n" +
                          ".2*.\n" +
                          "....\n" +
                          "....";

            char[,] schematic = GearRatios.ParseInputSchematic(data);

            int res = GearRatios.FindSumOfSchematicNumbers(schematic);

            Assert.AreEqual(2, res);
        }

        [Test]
        public void FindSumOfSchematicNumbersSymbolBottomOfSingleDigit() {
            string data = "....\n" +
                          ".3..\n" +
                          ".*..\n" +
                          "....";

            char[,] schematic = GearRatios.ParseInputSchematic(data);

            int res = GearRatios.FindSumOfSchematicNumbers(schematic);

            Assert.AreEqual(3, res);
        }

        [Test]
        public void FindSumOfSchematicNumbersSymbolTopLeftOfSingleDigit() {
            string data = "*...\n" +
                          ".4..\n" +
                          "....\n" +
                          "....";

            char[,] schematic = GearRatios.ParseInputSchematic(data);

            int res = GearRatios.FindSumOfSchematicNumbers(schematic);

            Assert.AreEqual(4, res);
        }

        [Test]
        public void FindSumOfSchematicNumbersSymbolTopRightOfSingleDigit() {
            string data = "..*.\n" +
                          ".5..\n" +
                          "....\n" +
                          "..1.";

            char[,] schematic = GearRatios.ParseInputSchematic(data);

            int res = GearRatios.FindSumOfSchematicNumbers(schematic);

            Assert.AreEqual(5, res);
        }

        [Test]
        public void FindSumOfSchematicNumbersSymbolBottomLeftOfSingleDigit() {
            string data = "....\n" +
                          ".6..\n" +
                          "*...\n" +
                          "....";

            char[,] schematic = GearRatios.ParseInputSchematic(data);

            int res = GearRatios.FindSumOfSchematicNumbers(schematic);

            Assert.AreEqual(6, res);
        }

        [Test]
        public void FindSumOfSchematicNumbersSymbolBottomRightOfSingleDigit() {
            string data = "....\n" +
                          ".7..\n" +
                          "..*.\n" +
                          "....";

            char[,] schematic = GearRatios.ParseInputSchematic(data);

            int res = GearRatios.FindSumOfSchematicNumbers(schematic);

            Assert.AreEqual(7, res);
        }

        [Test]
        public void GetDigitSizeOfOne() {
            string data = "....\n" +
                          ".7..\n" +
                          "..*.\n" +
                          "....";

            char[,] schematic = GearRatios.ParseInputSchematic(data);

            int res = GearRatios.GetDigitSize(schematic, 1, 1);

            Assert.AreEqual(1, res);
        }

        [Test]
        public void GetDigitSizeOfTwo() {
            string data = "....\n" +
                          ".77.\n" +
                          "..*.\n" +
                          "....";

            char[,] schematic = GearRatios.ParseInputSchematic(data);

            int res = GearRatios.GetDigitSize(schematic, 1, 1);

            Assert.AreEqual(2, res);
        }

        [Test]
        public void GetDigitSizeOfThree() {
            string data = "....\n" +
                          ".777\n" +
                          "..*.\n" +
                          "....";

            char[,] schematic = GearRatios.ParseInputSchematic(data);

            int res = GearRatios.GetDigitSize(schematic, 1, 1);

            Assert.AreEqual(3, res);
        }

        [Test]
        public void FindSumOfSchematicNumbersThirtyTwo() {
            string data = "....\n" +
                          ".32.\n" +
                          "..*.\n" +
                          "....";

            char[,] schematic = GearRatios.ParseInputSchematic(data);

            int res = GearRatios.FindSumOfSchematicNumbers(schematic);

            Assert.AreEqual(32, res);
        }

        [Test]
        public void FindSumOfSchematicNumbersThreehundredAndTwentyOne() {
            string data = "....\n" +
                          ".321\n" +
                          "..*.\n" +
                          "....";

            char[,] schematic = GearRatios.ParseInputSchematic(data);

            int res = GearRatios.FindSumOfSchematicNumbers(schematic);

            Assert.AreEqual(321, res);
        }

        [Test]
        public void FindSumOfSchematicNumbersFourhundred() {
            string data = "....\n" +
                          ".321\n" +
                          "..*.\n" +
                          ".79.";

            char[,] schematic = GearRatios.ParseInputSchematic(data);

            int res = GearRatios.FindSumOfSchematicNumbers(schematic);

            Assert.AreEqual(400, res);
        }

        [Test]
        public void FindSumOfSchematicNumbersTestData() {
            string data = "467..114..\n" +
                          "...*......\n" +
                          "..35..633.\n" +
                          "......#...\n" +
                          "617*......\n" +
                          ".....+.58.\n" +
                          "..592.....\n" +
                          "......755.\n" +
                          "...$.*....\n" +
                          ".664.598..";

            char[,] schematic = GearRatios.ParseInputSchematic(data);

            int res = GearRatios.FindSumOfSchematicNumbers(schematic);

            Assert.AreEqual(4361, res);
        }

        [Test]
        public void PartOneRun() {
            string data = File.ReadAllText("Day3/input.txt");

            char[,] schematic = GearRatios.ParseInputSchematic(data);

            int res = GearRatios.FindSumOfSchematicNumbers(schematic);
            Assert.AreEqual(527364, res);
        }

        [Test]
        public void FromInternet() {
            string data = "97..\n...*\n100.";

            char[,] schematic = GearRatios.ParseInputSchematic(data);

            int res = GearRatios.FindSumOfSchematicNumbers(schematic);
            Assert.AreEqual(100, res);
        }

        [Test]
        public void FindGearRatioOfHundredTen() {
            string data = ".11.\n" +
                          "..*.\n" +
                          "..10\n" +
                          "....\n";

            char[,] schematic = GearRatios.ParseInputSchematic(data);

            int res = GearRatios.FindGearRatios(schematic);

            Assert.AreEqual(110, res);
        }

        [Test]
        public void FindGearRatioOfHundredTwenty() {
            string data = "..12\n" +
                          "..*.\n" +
                          "10..\n" +
                          "....\n";

            char[,] schematic = GearRatios.ParseInputSchematic(data);

            int res = GearRatios.FindGearRatios(schematic);

            Assert.AreEqual(120, res);
        }

        [Test]
        public void TestDataPart2() {
            string data = "467..114..\r\n...*......\r\n..35..633.\r\n......#...\r\n617*......\r\n.....+.58.\r\n..592.....\r\n......755.\r\n...$.*....\r\n.664.598..";
            char[,] schematic = GearRatios.ParseInputSchematic(data);

            int res = GearRatios.FindGearRatios(schematic);

            Assert.AreEqual(467835, res);
        }

        [Test]
        public void Part2() {
            string data = File.ReadAllText("Day3/input.txt");

            char[,] schematic = GearRatios.ParseInputSchematic(data);

            int res = GearRatios.FindGearRatios(schematic);
            Assert.AreEqual(79026871, res);
        }

    }
}
