using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Challenges.Day1 {
    public class CalibratorParser {
        public static int ParseLine(string line) {
            string first = "-1", last = "-1";

            char[] line_arr = line.ToCharArray();

            foreach(char c in line_arr) {
                if(char.IsDigit(c)) {
                    if (first == "-1") first = c.ToString();
                    else last = c.ToString();
                }
            }

            if(last == "-1") last = first;
            return int.Parse(first + last);
        }

        public static int ParseLineUpgrade(string test_string) {
            string first = "-1", last = "-1";

            for (int pointer = 0; pointer < test_string.Length;) {
                if (char.IsDigit(test_string[pointer])) { //If char is digit
                    if (first == "-1") first = test_string[pointer].ToString();
                    else last = test_string[pointer].ToString();
                    pointer++;
                }else { //If char is a char
                    for (int i = 0; i < numbers.Length; i++) {
                        if (numbers[i].Length <= (test_string.Length-pointer)) {
                            if (StringIsEqual(numbers[i], test_string.Substring(pointer, numbers[i].Length))) {
                                if (first == "-1") first = (i + 1).ToString();
                                else last = (i + 1).ToString();
                                pointer++;
                                break;
                            }
                        }
                    }
                    pointer++;
                }
            }
            if (last == "-1") last = first;
            return int.Parse(first + last);
        }

        private static bool StringIsEqual(string a, string b) {
            return a.Equals(b);
        }

        private static readonly string[] numbers = new string[] { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

        public static int ReturnSumOfCalibratorData(string data, bool part_two) {
            string[] data_arr = data.Split("\n");

            int sum = 0;

            foreach(string line in data_arr) {
                if (line != "") {
                    sum +=  part_two ? ParseLineUpgrade(line) : ParseLine(line);
                }
            }

            return sum;
        }

    }
}
