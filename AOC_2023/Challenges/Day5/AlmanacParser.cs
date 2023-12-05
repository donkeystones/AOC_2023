using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Challenges.Day5 {
    public class AlmanacParser {
        public static BigInteger GetLowestPart1(string data) {
            BigInteger loc = -1;
            data = data.Replace("\r", "");
            string[] data_arr = data.Split("\n");

            BigInteger[] seeds = data_arr[0].Split(": ")[1].Split(" ")
                                        .Where(x => int.TryParse(x, out _))
                                        .Select(BigInteger.Parse)
                                        .ToArray();

            RangeType[] ranges = GetRanges(data_arr);

            foreach (BigInteger seed in seeds) {
                BigInteger new_loc = GetLoc(seed, ranges);
                if (loc == -1) loc = new_loc;
                else if (loc > new_loc) loc = new_loc;
            }

            return loc;
        }

        public static BigInteger GetLowestPart2(string data) {
            BigInteger loc = -1;
            data = data.Replace("\r", "");
            string[] data_arr = data.Split("\n");

            BigInteger[] seeds = data_arr[0].Split(": ")[1].Split(" ")
                                        .Where(x => int.TryParse(x, out _))
                                        .Select(BigInteger.Parse)
                                        .ToArray();

            RangeType[] ranges = GetRanges(data_arr);
            for (int i = 0; i < seeds.Length; i += 2) {
                BigInteger min, max;
                min = seeds[i];
                max = seeds[i] + seeds[i + 1];
                Console.WriteLine("Checking: " + min + " - " + max);
                for (BigInteger j = min; j <= max; j++) {
                    BigInteger new_loc = GetLoc(j, ranges);
                    if (loc == -1) loc = new_loc;
                    else if (loc > new_loc) loc = new_loc;
                }
            }
            return loc;
        }

        public static BigInteger GetLowestPart2version2(string data) {
            BigInteger loc = -1;
            data = data.Replace("\r", "");
            string[] data_arr = data.Split("\n");

            BigInteger[] seeds = data_arr[0].Split(": ")[1].Split(" ")
                                        .Where(x => int.TryParse(x, out _))
                                        .Select(BigInteger.Parse)
                                        .ToArray();

            RangeType[] ranges = GetRanges(data_arr);
            for (int i = 0; i < seeds.Length; i += 2) {
                BigInteger min, max;
                min = seeds[i];
                max = seeds[i] + seeds[i + 1];
                Console.WriteLine("Checking: " + min + " - " + max);
                for (BigInteger j = min; j <= max; j++) {
                    BigInteger new_loc = GetLoc(j, ranges);
                    if (loc == -1) loc = new_loc;
                    else if (loc > new_loc) loc = new_loc;
                }
            }
            return loc;
        }
        //(Destination - Source) + seed = soil location
        private static BigInteger GetLoc(BigInteger seed, RangeType[] ranges) {
            for(int range = 0; range < ranges.Length; range++) {
                foreach(Map map in ranges[range].maps) {
                    if(seed >= map.source_id && seed < map.source_id + map.range_length) { //If sourcerange is within current seed
                        seed = (map.destination_id - map.source_id) + seed;
                        break;
                    }
                }
            }
            return seed;
        }

        public static RangeType[] GetRanges(string[] data_arr) {
            List<RangeType> ranges = new List<RangeType>();
            int ranges_pointer = 0;
            for(int i = 2; i < data_arr.Length; i++) {
                if (data_arr[i] == "seed-to-soil map:" ||
                    data_arr[i] == "soil-to-fertilizer map:" ||
                    data_arr[i] == "fertilizer-to-water map:" ||
                    data_arr[i] == "water-to-light map:" ||
                    data_arr[i] == "light-to-temperature map:" ||
                    data_arr[i] == "temperature-to-humidity map:" ||
                    data_arr[i] == "humidity-to-location map:") {
                    ranges.Add(new RangeType());
                    int j;
                    for(j = i+1; j < data_arr.Length; j++) {
                        if (data_arr[j] != "")
                            ranges[ranges_pointer].maps.Add(GetMap(data_arr[j]));
                        else break;
                    }
                    ranges_pointer++;
                    i = j;
                }
            }

            return ranges.ToArray();
        }
        //Destination Source Range_Length
        //50          98     2
         
        public static Map GetMap(string map) {
            string[] map_arr = map.Split(" ");
            return new Map() {
                source_id = BigInteger.Parse(map_arr[1]),
                destination_id = BigInteger.Parse(map_arr[0]),
                range_length = BigInteger.Parse((map_arr[2]))
            };
        }

    }

    public class RangeType {
        public List<Map> maps;
        public RangeType() { maps = new List<Map>(); }
    }

    public class Map {
        public BigInteger source_id;
        public BigInteger destination_id;
        public BigInteger range_length;
    }

}
