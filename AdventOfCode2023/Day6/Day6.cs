using System;
namespace AdventOfCode2023.Day6
{
	public static class Day6
	{
        private static string path = "/Users/ihorpodpriadok/Projects/AdventOfCode2023/AdventOfCode2023/Day6/input.txt";
        private static string[] input = File.ReadAllLines(path);

        public static void PartOne()
		{
            long partOneSum = 0;

            var timeInput = input[0].Remove(0, (input[0].IndexOf(":") + 1)).Split(' ').Where(x => !string.IsNullOrEmpty(x)).ToArray();
            var distanceInput = input[1].Remove(0, (input[1].IndexOf(":") + 1)).Split(' ').Where(x => !string.IsNullOrEmpty(x)).ToArray();

            var gamesWinnigOptions = new long[timeInput.Length];

            /*
             * speed = wait
             * travelTime = time - wait
             * distance = speed * travelTime = wait * (time - wait)
             */
            for (var i = 0; i < timeInput.Length; i++)
            {
                var distance = Int32.Parse(distanceInput[i]);
                var travelTime = Int32.Parse(timeInput[i]);
                gamesWinnigOptions[i] += WinGamesCulculate(travelTime, distance);
            }

            partOneSum = gamesWinnigOptions[1] * gamesWinnigOptions[2] * gamesWinnigOptions[3] * gamesWinnigOptions[0];

            Console.WriteLine(partOneSum);
        }

        public static void PartTwo()
        {
            var timeInput = input[0].Remove(0, (input[0].IndexOf(":") + 1)).Replace(" ","");
            var distanceInput = input[1].Remove(0, (input[1].IndexOf(":") + 1)).Replace(" ", "");
            var distance = long.Parse(distanceInput);
            var travelTime = long.Parse(timeInput);

            var partTwoSum = WinGamesCulculate(travelTime, distance);

            Console.WriteLine(partTwoSum);
        }

        private static long WinGamesCulculate(long time, long distance)
        {
            long result = 0;

            for (long holdButton = 1; holdButton < time; holdButton++)
            {
                long resultDistance = holdButton * (time - holdButton);

                if (resultDistance > distance) result += 1;
            }

            return result;
        }
	}
}

