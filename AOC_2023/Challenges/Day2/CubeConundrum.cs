using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Challenges.Day2 {
    public class CubeConundrum {
        public static int SolveGame(string data, bool part_two) {
            if(data == "") return 0;
            string[] data_arr = data.Split(": ");
            if (part_two) {
                return PowerOfSmallest(data_arr[1]);
            } else {
                bool isValidGame = IsValidGame(data_arr[1]);
                int roundNum = ParseGameNumber(data_arr[0]);
                if (!isValidGame) Console.WriteLine("invalid game data: " + data);
                return isValidGame ? roundNum : 0;
            }
        }

        

        private static int ParseGameNumber(string raw_game_round_data) {
            return int.Parse(raw_game_round_data.Split(" ")[1]);
        }

        //Game rules: 12 red, 13 green, 14 blue
        private static bool IsValidGame(string game_data) {

            string[] rounds = game_data.Split("; ");
            foreach (string round in rounds) {
                string[] cubes = round.Split(", ");
                foreach (string cube in cubes) {
                    string[] cube_values = cube.Split(" ");
                   if ((cube_values[1] == "blue" && int.Parse(cube_values[0]) > 14) ||
                        (cube_values[1] == "green" && int.Parse(cube_values[0]) > 13) ||
                        (cube_values[1] == "red" && int.Parse(cube_values[0]) > 12))
                            return false;
                }
            }


            return true;
        }

        private static int PowerOfSmallest(string game_data) {
            IDictionary<string, int> game_summary = new Dictionary<string, int>();

            string[] rounds = game_data.Split("; ");
            foreach (string round in rounds) {
                string[] cubes = round.Split(", ");
                foreach (string cube in cubes) {
                    string[] cube_values = cube.Split(" ");
                    if (game_summary.ContainsKey(cube_values[1]) && game_summary[cube_values[1]] < int.Parse(cube_values[0])) {
                        Console.WriteLine("Adding smallest to " + cube_values[1] + " previous val: " + game_summary[cube_values[1]]);
                        game_summary[cube_values[1]] = int.Parse(cube_values[0]);
                    } else game_summary[cube_values[1]] = int.Parse(cube_values[0]);
                }
            }


            return game_summary["blue"] * game_summary["green"] * game_summary["red"];
        }


        public static int SolvePossibleGamesCubeValue(string game_data, bool part_two) {
            string[] games = game_data.Split("\n");
            int sum = 0;
            foreach (string game in games) {

                sum += SolveGame(game, part_two);
            }
            return sum;
        }
        
    }
}
