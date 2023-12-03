using System;
using System.Collections.Generic;
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
    }
}
