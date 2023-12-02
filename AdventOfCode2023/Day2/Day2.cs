using System;
namespace AdventOfCode2023.Day2
{
	public static class Day2
	{
        private static string path = "/Users/ihorpodpriadok/Projects/AdventOfCode2023/AdventOfCode2023/Day2/input.txt";
        private static string[] input = File.ReadAllLines(path);

        public static void PartOne()
        {
            int sumPartOne = 0;
            var gameNumber = 1;

            foreach (var ip in input)
            {
                var isGameValid = true;
                var colonIndex = ip.IndexOf(":");
                var gameInput = ip.Remove(0, colonIndex + 1);
                var sets = gameInput.Split(";");

                foreach (var set in sets)
                {
                    var cubesSets = set.Split(",");

                    foreach (var cubesSet in cubesSets)
                    {
                        if (cubesSet.Contains("red"))
                        {
                            var stringNumber = cubesSet.Trim().Replace("red", "");
                            var number = 0;
                            Int32.TryParse(stringNumber, out number);

                            if (number > 12)
                            {
                                isGameValid = false;
                            }
                        }

                        if (cubesSet.Contains("green"))
                        {
                            var stringNumber = cubesSet.Trim().Replace("green", "");
                            var number = 0;
                            Int32.TryParse(stringNumber, out number);

                            if (number > 13)
                            {
                                isGameValid = false;
                            }
                        }

                        if (cubesSet.Contains("blue"))
                        {
                            var stringNumber = cubesSet.Trim().Replace("blue", "");
                            var number = 0;
                            Int32.TryParse(stringNumber, out number);

                            if (number > 14)
                            {
                                isGameValid = false;
                            }
                        }
                    }
                }

                if (isGameValid)
                {
                    sumPartOne += gameNumber;
                }

                gameNumber++;
            }

            Console.WriteLine(sumPartOne);
        }

        public static void PartTwo()
        {
            var sumPartTwo = 0;

            foreach(var ip in input)
            {
                var redMax = 0;
                var greenMax = 0;
                var blueMax = 0;

                var colonIndex = ip.IndexOf(":");
                var gameInput = ip.Remove(0, colonIndex + 1);
                var sets = gameInput.Split(";");

                foreach(var set in sets)
                {
                    var cubesSets = set.Split(",");

                    foreach(var cubesSet in cubesSets)
                    {
                        if (cubesSet.Contains("red"))
                        {
                            var stringNumber = cubesSet.Trim().Replace("red", "");
                            var number = 0;
                            Int32.TryParse(stringNumber, out number);

                            if (number > redMax)
                            {
                                redMax = number;
                            }
                        }

                        if (cubesSet.Contains("green"))
                        {
                            var stringNumber = cubesSet.Trim().Replace("green", "");
                            var number = 0;
                            Int32.TryParse(stringNumber, out number);

                            if (number > greenMax)
                            {
                                greenMax = number;
                            }
                        }

                        if (cubesSet.Contains("blue"))
                        {
                            var stringNumber = cubesSet.Trim().Replace("blue", "");
                            var number = 0;
                            Int32.TryParse(stringNumber, out number);

                            if (number > blueMax)
                            {
                                blueMax = number;
                            }
                        }
                    }
                }

                var multipliedSum = redMax * greenMax * blueMax;
                sumPartTwo += multipliedSum;
            }

            Console.WriteLine(sumPartTwo);
        }
	}
}

