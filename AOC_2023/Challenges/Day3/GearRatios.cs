using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges.Day3 {
    public class GearRatios {
        public static int FindSumOfSchematicNumbers(char[,] schematic) {
            int sum = 0;

            for(int y = 0; y < GetSchematicHeight(schematic); y++) {
                for( int x = 0; x < GetSchematicWidth(schematic);x++) {
                    if (Char.IsDigit(schematic[y, x])) {
                        int size = GetDigitSize(schematic, y, x);
                        if (SymbolIsAdjacent(schematic, y, x, size)) {
                            Console.WriteLine(GetWholeDigit(schematic, y, x, size));
                            sum += GetWholeDigit(schematic, y, x, size);
                            x += size;
                            continue;
                        }
                    }
                }
            }

            return sum;
        }

        private static int GetWholeDigit(char [,] schematic, int y, int x, int size) {
            string sum = "";
            for(int pointer = x; pointer < x+size; pointer++) {
                sum += schematic[y, pointer];
            }
            return int.Parse(sum);
        }

        public static int GetDigitSize(char[,] schematic, int y, int x) {
            for(int pointer = x; pointer < GetSchematicWidth(schematic);) {
                pointer++;
                if (pointer == GetSchematicWidth(schematic) || !Char.IsDigit(schematic[y, pointer])) return pointer - x;
            }
            return 0;
        }

        private static bool SymbolIsAdjacent(char[,] schematic, int y, int x, int size) {
            for(int pointer = x-1; pointer <= x+size; pointer++) {
                if (pointer >= 0 && pointer < GetSchematicWidth(schematic)) { //Check if pointer is in bounds

                    if (pointer == x - 1 || pointer == x + size)
                        if (CheckMiddle(schematic,y,pointer)) return true;
                    if(CheckBottom(schematic, y, pointer) || CheckTop(schematic,y, pointer)) return true;
                }
                
            }

            return false;
        }

        private static bool CheckTop(char[,] schematic, int y, int pointer) {
            if (y - 1 < 0) return false;
            return (schematic[y-1, pointer] != '.' && !Char.IsDigit(schematic[y-1, pointer]));
        }

        private static bool CheckBottom(char[,] schematic, int y, int pointer) {
            if (y+1 >= GetSchematicHeight(schematic) ) return false;
            return (schematic[y + 1, pointer] != '.' && !Char.IsDigit(schematic[y + 1, pointer]));
        }

        private static bool CheckMiddle(char[,] schematic, int y, int pointer) {
            return (schematic[y, pointer] != '.' && !Char.IsDigit(schematic[y, pointer]));
        }

        public static char[ , ] ParseInputSchematic(string data) {
            string[] data_arr = data.Split("\n");
            char[,] res = new char[data_arr.Length, data_arr[0].Length]; // new char[height, width]

            for(int y = 0; y < data_arr.Length; y++) {
                for(int x = 0;  x < data_arr[y].Length; x++) {
                    res[y,x] = data_arr[y][x];
                }
            }

            return res;
        }

        //So I don't have to remember how to get width and height from 2d arr.
        public static int GetSchematicWidth(char[,] schematic) {
            return schematic.GetLength(1);
        }

        public static int GetSchematicHeight(char[,] schematic) {
            return schematic.GetLength(0);
        }

        public static int FindGearRatios(char[,] schematic) {
            int sum = 0;
            for(int y = 0; y < GetSchematicHeight(schematic); y++) {
                for(int x = 0; x < GetSchematicWidth(schematic); x++) {
                    if (schematic[y,x] == '*') {
                        int[] digits = CheckForDigits(schematic, y, x);
                        if (digits.Length == 2) sum += (digits[0] * digits[1]);
                    }
                }
            }

            return sum;
        }

        //This is a real lazy way of doing it,
        //but my mind is fried from part 1 so this is the best you'll get
        private static int[] CheckForDigits(char[,] schematic, int y, int x) {
            List<int> nums = new List<int>();

            if (Char.IsDigit(schematic[y - 1, x])) //CheckTop
                nums.Add(ParseDigitToGear(schematic, y - 1, x));

            if(Char.IsDigit(schematic[y - 1, x - 1])) // Check Top Left
                nums.Add(ParseDigitToGear(schematic, y - 1, x - 1));
            
            if (Char.IsDigit(schematic[y - 1, x + 1])) // Check Top Right
                nums.Add(ParseDigitToGear(schematic, y - 1, x + 1));
            
            if (Char.IsDigit(schematic[y + 1, x])) //CheckBottom
                nums.Add(ParseDigitToGear(schematic, y + 1, x));
            
            if (Char.IsDigit(schematic[y + 1, x - 1])) // Check Bottom Left
                nums.Add(ParseDigitToGear(schematic, y + 1, x - 1));
            
            if (Char.IsDigit(schematic[y + 1, x + 1])) // Check Bottom Right
                nums.Add(ParseDigitToGear(schematic, y + 1, x + 1));
            
            if (Char.IsDigit(schematic[y, x - 1])) // Left
                nums.Add(ParseDigitToGear(schematic, y, x - 1));
            
            if (Char.IsDigit(schematic[y, x + 1])) // Right
                nums.Add(ParseDigitToGear(schematic, y, x + 1));

            nums = nums.Distinct().ToList();// remove duplicates

            return nums.ToArray();
        }

        private static int ParseDigitToGear(char[,] schematic, int y, int x) {
            int beginning_x = GetBeginningXCoor(schematic, y, x);
            return GetWholeDigit(
                        schematic
                        , y
                        , beginning_x
                        , GetDigitSize(
                            schematic
                            , y
                            , beginning_x));
        }

        private static int GetBeginningXCoor(char[,] schematic, int y, int x) {
            for (int pointer = x-1; pointer >= 0; pointer--) {
                if (!Char.IsDigit(schematic[y, pointer])) return pointer + 1;
                if (pointer == 0) return 0;
            }

            return x;
        }

    }
}
