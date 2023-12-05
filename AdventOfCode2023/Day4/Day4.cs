using System;
namespace AdventOfCode2023.Day4
{
    public static class Day4
    {
        private static string path = "/Users/ihorpodpriadok/Projects/AdventOfCode2023/AdventOfCode2023/Day4/input.txt";
        private static string[] input = File.ReadAllLines(path);

        public static void PartOne()
        {
            int sumPartOne = 0;

            foreach (var inputLine in input)
            {
                var countWinningNumbers = 0;

                var colonIndex = inputLine.IndexOf(":");
                var gameInput = inputLine.Remove(0, colonIndex + 1);

                var separatorIndex = gameInput.IndexOf("|");
                var winningNumbers = gameInput.Remove(separatorIndex).Split(' ').Where(x => !string.IsNullOrEmpty(x)).ToArray();
                var gameNumbers = gameInput.Remove(0, separatorIndex + 1).Split(' ').Where(x => !string.IsNullOrEmpty(x)).ToArray();

                foreach (var winningNumber in winningNumbers)
                {
                    foreach (var gameNumber in gameNumbers)
                    {
                        if (gameNumber == winningNumber) countWinningNumbers++;
                    }
                }

                var gameResult = GetGameResult(countWinningNumbers);
                sumPartOne += gameResult;
            }

            Console.WriteLine(sumPartOne);
        }

        public static int GetGameResult(int length)
        {
            int result = 1;
            if (length == 0) return 0;

            for (int i = 1; i < length; i++)
            {
                result *= 2;
            }

            return result;
        }

        public static void PartTwo()
        {
            var sumPartTwo = 0;
            List<string> updatedInput = input.ToList();

            for(var i = 0; i < updatedInput.Count; i++)
            { 
                var countWinningNumbers = 0;

                var colonIndex = updatedInput[i].IndexOf(":");
                var gameInput = updatedInput[i].Remove(0, colonIndex + 1);

                countWinningNumbers = CheckCardRecursive(1, gameInput);
                //var separatorIndex = gameInput.IndexOf("|");
                //var winningNumbers = gameInput.Remove(separatorIndex).Split(' ').Where(x => !string.IsNullOrEmpty(x)).ToArray();
                //var gameNumbers = gameInput.Remove(0, separatorIndex + 1).Split(' ').Where(x => !string.IsNullOrEmpty(x)).ToArray();

                //foreach (var winningNumber in winningNumbers)
                //{
                //    foreach (var gameNumber in gameNumbers)
                //    {
                //        if (gameNumber == winningNumber) countWinningNumbers++;
                //    }
                //}

                var curdNumber = Int32.Parse(updatedInput[i].Remove(colonIndex).Replace("Card", "").Trim());
                List<int> winCardsNumbers = new List<int>();

                for (var j = 1; j < countWinningNumbers; ++j)
                {
                    winCardsNumbers.Add(curdNumber + j);
                }

                foreach (var winCardNumber in winCardsNumbers)
                {
                    var card = input.First(x => x.Contains($"{winCardNumber}:"));
                    var index = updatedInput.IndexOf(card);
                    updatedInput.Insert(index, card);
                }
            }

            sumPartTwo = updatedInput.Count;

            Console.WriteLine(sumPartTwo);
        }

        public static int CheckCardRecursive(int length, string card, int counter = 0)
        {
            if (length == 0) return counter;

            var separatorIndex = card.IndexOf("|");
            var winningNumbers = card.Remove(separatorIndex).Split(' ').Where(x => !string.IsNullOrEmpty(x)).ToArray();
            var gameNumbers = card.Remove(0, separatorIndex + 1).Split(' ').Where(x => !string.IsNullOrEmpty(x)).ToArray();

            foreach (var winningNumber in winningNumbers)
            {
                foreach (var gameNumber in gameNumbers)
                {
                    if (gameNumber == winningNumber) counter++;
                }
            }

            return CheckCardRecursive(length - 1, card, counter);
        }
    }
}

