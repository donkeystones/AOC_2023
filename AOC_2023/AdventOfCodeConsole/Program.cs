using Challenges.Day5;
using System.Numerics;


var watch = System.Diagnostics.Stopwatch.StartNew();

string data = File.ReadAllText("input.txt");
BigInteger res = AlmanacParser.GetLowestPart2version2(data);
Console.WriteLine(res);
watch.Stop();
TimeSpan t = TimeSpan.FromMilliseconds(watch.ElapsedMilliseconds);
string answer = string.Format("{0:D2}h:{1:D2}m:{2:D2}s:{3:D3}ms",
                        t.Hours,
                        t.Minutes,
                        t.Seconds,
                        t.Milliseconds);
Console.WriteLine("Time: " + answer);
Console.ReadKey();

