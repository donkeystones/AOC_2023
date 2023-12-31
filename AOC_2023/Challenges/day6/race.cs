﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Challenges.day6 {
    public class Race {
        public static BigInteger Part1(string data) {
            List<int[]> data_list = new List<int[]>();
            foreach(string s in data.Split("\n")) {
                data_list.Add(s.Split(':')[1]
                    .Split(' ')
                    .Select(p => p.Trim())
                    .Where(s => !string.IsNullOrWhiteSpace(s))
                    .Select(s => Convert.ToInt32(s))
                    .ToArray());
            }
            BigInteger sum = 1;
            for(int i = 0; i <  data_list[1].Length; i++) {
                sum *= CalculateNumberOfSuccessfulStrategies(data_list[0][i], data_list[1][i]);
            }
            return sum;
        }

        public static BigInteger Part2(string data) {
            string[] data_arr = data.Split("\n");
            BigInteger sum = CalculateNumberOfSuccessfulStrategies(GetSumOfNumbers(data_arr[0].Split(": ")[1]), GetSumOfNumbers(data_arr[1].Split(": ")[1]));
            return sum;
        }

        public static BigInteger GetSumOfNumbers(string nums) {
            return BigInteger.Parse(nums.Replace(" ", ""));
        }

        private static BigInteger CalculateWins(BigInteger ms, BigInteger record) {
            BigInteger sum = 0;
            for(int i = 0; i < ms; i++) {
                if ((ms - i) * i > record) sum++;
            }
            return sum;
        }

        private static BigInteger CalculateNumberOfSuccessfulStrategies(BigInteger ms, BigInteger record) {
            BigInteger start = new BigInteger(0);
            BigInteger end = ms;
            while (end - start > 1) {
                var mid = (start + end) / 2;
                if (mid * (ms - mid) > record)
                    end = mid;
                else
                    start = mid;
            }

            return ms - start - start - 1;
        }
    }
}
