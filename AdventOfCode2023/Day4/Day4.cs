using System;
using System.Diagnostics.Metrics;

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
            long sumPartTwo = 0;
            List<string> updatedInput = input.ToList();
            var colonIndex = input[0].IndexOf(":");
            long[] extraCards = new long[input.Count()];

            for (var i = 0; i < input.Length; i++)
            {
                var countWinningNumbers = 0;

                var cardNumber = Int32.Parse(input[i].Remove(colonIndex).Replace("Card", "").Trim());

                if (extraCards[i] == 0)
                {
                    extraCards[i] = 1;
                }
                long allCards = extraCards[i];

                var gameInput = input[i].Remove(0, colonIndex + 1);

                var separatorIndex = gameInput.IndexOf("|");
                var winningNumbers = gameInput.Remove(separatorIndex).Split(' ').Where(x => !string.IsNullOrEmpty(x)).ToArray();
                var gameNumbers = gameInput.Remove(0, separatorIndex + 1).Split(' ').Where(x => !string.IsNullOrEmpty(x)).ToArray();

                //var counter = 0;
                //countWinningNumbers = CheckCardRecursive(allCards.Count(), winningNumbers, gameNumbers);
                foreach (var winningNumber in winningNumbers)
                {
                    foreach (var gameNumber in gameNumbers)
                    {
                        if (gameNumber == winningNumber)
                        {
                            countWinningNumbers++;
                            break;
                        }
                    }
                }

                List<int> winCardsNumbers = new List<int>();

                for (var j = 1; j <= countWinningNumbers; j++)
                {
                    winCardsNumbers.Add(cardNumber + j);
                }

                foreach (var winCardNumber in winCardsNumbers)
                {
                    var counter = allCards;
                    var card = input.FirstOrDefault(x => x.Contains($"{winCardNumber}:"));
                    while (counter > 0)
                    {
                        if (card == null)
                        {
                            break;
                            //extraCards += 1;
                            //continue;
                        }
                        //var index = updatedInput.IndexOf(card);
                        //updatedInput.Insert(index, card);
                        extraCards[winCardNumber - 1] += 1;
                        counter--;
                    }
                }
            }

            sumPartTwo = extraCards.Sum();

            Console.WriteLine(sumPartTwo);
        }

        public static int CheckCardRecursive(int length, string[] winningNumbers, string[] gameNumbers, int counter = 0)
        {
            if (length == 0) return counter;

            foreach (var winningNumber in winningNumbers)
            {
                foreach (var gameNumber in gameNumbers)
                {
                    if (gameNumber == winningNumber)
                    {
                        counter++;
                        break;
                    }
                }
            }

            return CheckCardRecursive(length - 1, winningNumbers, gameNumbers, counter);
        }
    }
}

