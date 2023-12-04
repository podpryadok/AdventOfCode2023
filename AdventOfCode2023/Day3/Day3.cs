using System;
namespace AdventOfCode2023.Day3
{
    public static class Day3
    {
        private static string path = "/Users/ihorpodpriadok/Projects/AdventOfCode2023/AdventOfCode2023/Day3/input.txt";
        private static string[] input = File.ReadAllLines(path);
        private static char[] symbols = { '!', '@', '#', '$', '%', '^', '&', '*', '-', '+', '=', '/' };
        public static void PartOne()
        {
            var partOneSum = 0;
            List<int> previousLineSymbolsIndexes = new List<int>();
            List<int> currentLineSymbolsIndexes = new List<int>();
            List<int> nextLineSymbolsIndexes = new List<int>();
            var previousLine = String.Empty;
            var currentLine = String.Empty;
            var nextLine = String.Empty;

            for (var i = 0; i < input.Length; i++)
            {
                if (String.IsNullOrEmpty(currentLine))
                {
                    currentLine = input[i];
                    nextLine = input[i + 1];

                    currentLineSymbolsIndexes = GetSymbolsIndexes(input[i]);
                    nextLineSymbolsIndexes = GetSymbolsIndexes(input[i + 1]);
                }
                else
                {
                    previousLineSymbolsIndexes = currentLineSymbolsIndexes;
                    currentLineSymbolsIndexes = nextLineSymbolsIndexes;
                    previousLine = currentLine;
                    currentLine = nextLine;
                    if (i >= (input.Length - 1))
                    {
                        nextLine = String.Empty;
                        nextLineSymbolsIndexes = new List<int>();
                    }
                    else
                    {
                        nextLine = input[i + 1];
                        nextLineSymbolsIndexes = GetSymbolsIndexes(input[i + 1]);
                    }
                }

                foreach (var symbol in symbols)
                {
                    currentLine = currentLine.Replace(symbol, '.');
                }

                //Check all numbers that connect symbols in the current line
                foreach (var index in currentLineSymbolsIndexes)
                {
                    var previousChar = currentLine[index - 1];
                    var nextChar = currentLine[index + 1];

                    if (Char.IsDigit(previousChar))
                    {
                        var updatedInputLine = currentLine.Remove(index);
                        var numbersInput = updatedInputLine.Split('.');
                        var number = Int32.Parse(numbersInput.Last());
                        partOneSum += number;
                    }

                    if (Char.IsDigit(nextChar))
                    {
                        var updatedInputLine = currentLine.Remove(0, index + 1);
                        var numbersInput = updatedInputLine.Split('.');
                        var number = Int32.Parse(numbersInput.First());
                        partOneSum += number;
                    }
                }

                //Check all numbers that connect symbols from previous line
                foreach (var index in previousLineSymbolsIndexes)
                {
                    var previousChar = currentLine[index - 1];
                    var currentChar = currentLine[index];
                    var nextChar = currentLine[index + 1];

                    if (Char.IsDigit(previousChar) && !Char.IsDigit(currentChar))
                    {
                        var updatedInputLine = currentLine.Remove(index);
                        var numbersInput = updatedInputLine.Split('.');
                        var number = Int32.Parse(numbersInput.Last());
                        partOneSum += number;
                    }

                    if (!Char.IsDigit(currentChar) && Char.IsDigit(nextChar))
                    {
                        var updatedInputLine = currentLine.Remove(0, index + 1);
                        var numbersInput = updatedInputLine.Split('.');
                        var number = Int32.Parse(numbersInput.First());
                        partOneSum += number;
                    }

                    if (Char.IsDigit(previousChar) && Char.IsDigit(currentChar) && !Char.IsDigit(nextChar))
                    {
                        var updatedInputLine = currentLine.Remove(index + 1);
                        var numbersInput = updatedInputLine.Split('.');
                        var number = Int32.Parse(numbersInput.Last());
                        partOneSum += number;
                    }

                    if (Char.IsDigit(previousChar) && Char.IsDigit(currentChar) && Char.IsDigit(nextChar))
                    {
                        var updatedInputLine = currentLine.Remove(index + 2);
                        var numbersInput = updatedInputLine.Split('.');
                        var number = Int32.Parse(numbersInput.Last());
                        partOneSum += number;
                    }

                    if (!Char.IsDigit(previousChar) && Char.IsDigit(currentChar) && Char.IsDigit(nextChar))
                    {
                        var updatedInputLine = currentLine.Remove(0, index);
                        var numbersInput = updatedInputLine.Split('.');
                        var number = Int32.Parse(numbersInput.First());
                        partOneSum += number;
                    }

                    if (!Char.IsDigit(previousChar) && Char.IsDigit(currentChar) && !Char.IsDigit(nextChar))
                    {
                        var updatedInputLine = currentLine.Remove(0, index);
                        var numbersInput = updatedInputLine.Split('.');
                        var number = Int32.Parse(numbersInput.First());
                        partOneSum += number;
                    }
                }

                //Check All numbers that connect to the next line symbols
                foreach (var index in nextLineSymbolsIndexes)
                {
                    var previousChar = currentLine[index - 1];
                    var currentChar = currentLine[index];
                    var nextChar = currentLine[index + 1];

                    if (Char.IsDigit(previousChar) && !Char.IsDigit(currentChar))
                    {
                        var updatedInputLine = currentLine.Remove(index);
                        var numbersInput = updatedInputLine.Split('.');
                        var number = Int32.Parse(numbersInput.Last());
                        partOneSum += number;
                    }

                    if (Char.IsDigit(nextChar) && !Char.IsDigit(currentChar))
                    {
                        var updatedInputLine = currentLine.Remove(0, index + 1);
                        var numbersInput = updatedInputLine.Split('.');
                        var number = Int32.Parse(numbersInput.First());
                        partOneSum += number;
                    }

                    if (Char.IsDigit(previousChar) && Char.IsDigit(currentChar) && !Char.IsDigit(nextChar))
                    {
                        var updatedInputLine = currentLine.Remove(index + 1);
                        var numbersInput = updatedInputLine.Split('.');
                        var number = Int32.Parse(numbersInput.Last());
                        partOneSum += number;
                    }

                    if (Char.IsDigit(previousChar) && Char.IsDigit(currentChar) && Char.IsDigit(nextChar))
                    {
                        var updatedInputLine = currentLine.Remove(index + 2);
                        var numbersInput = updatedInputLine.Split('.');
                        var number = Int32.Parse(numbersInput.Last());
                        partOneSum += number;
                    }

                    if (!Char.IsDigit(previousChar) && Char.IsDigit(currentChar) && Char.IsDigit(nextChar))
                    {
                        var updatedInputLine = currentLine.Remove(0, index);
                        var numbersInput = updatedInputLine.Split('.');
                        var number = Int32.Parse(numbersInput.First());
                        partOneSum += number;
                    }

                    if (!Char.IsDigit(previousChar) && Char.IsDigit(currentChar) && !Char.IsDigit(nextChar))
                    {
                        var updatedInputLine = currentLine.Remove(0, index);
                        var numbersInput = updatedInputLine.Split('.');
                        var number = Int32.Parse(numbersInput.First());
                        partOneSum += number;
                    }
                }
            }

            Console.WriteLine(partOneSum);
        }

        public static List<int> GetSymbolsIndexes(string inputLine)
        {
            var result = new List<int>();

            foreach (var symbol in symbols)
            {
                var count = 0;
                var symbolIndex = 0;
                var start = 0;
                var end = inputLine.Length;
                while ((start <= end) && (symbolIndex > -1))
                {
                    count = end - start;
                    symbolIndex = inputLine.IndexOf(symbol, start, count);

                    if (symbolIndex == -1) break;

                    result.Add(symbolIndex);
                    start = symbolIndex + 1;
                }
            }

            return result;
        }

        public static void PartTwo()
        {
            var partTwoSum = 0;
            List<int> previousLineSymbolsIndexes = new List<int>();
            List<int> currentLineSymbolsIndexes = new List<int>();
            List<int> nextLineSymbolsIndexes = new List<int>();
            var previousLine = String.Empty;
            var currentLine = String.Empty;
            var nextLine = String.Empty;

            for (var i = 0; i < input.Length; i++)
            {
                if (String.IsNullOrEmpty(currentLine))
                {
                    currentLine = input[i];
                    nextLine = input[i + 1];

                    currentLineSymbolsIndexes = GetStarSymbolIndex(input[i]);
                    nextLineSymbolsIndexes = GetStarSymbolIndex(input[i + 1]);
                }
                else
                {
                    previousLineSymbolsIndexes = currentLineSymbolsIndexes;
                    currentLineSymbolsIndexes = nextLineSymbolsIndexes;
                    previousLine = currentLine;
                    currentLine = nextLine;
                    if (i >= (input.Length - 1))
                    {
                        nextLine = String.Empty;
                        nextLineSymbolsIndexes = new List<int>();
                    }
                    else
                    {
                        nextLine = input[i + 1];
                        nextLineSymbolsIndexes = GetStarSymbolIndex(input[i + 1]);
                    }
                }

                foreach (var symbol in symbols)
                {
                    currentLine = currentLine.Replace(symbol, '.');
                }

                foreach(var index in currentLineSymbolsIndexes)
                {
                    var numberOne = 0;
                    var numberTwo = 0;

                    var previousCharCurrentLine = currentLine[index - 1];
                    var nextCharCurrentLine = currentLine[index + 1];
                    var previousCharPreviousLine = previousLine[index - 1];
                    var currentCharPreviousLine = previousLine[index];
                    var nextCharPreviousLine = previousLine[index + 1];
                    var previousCharNextLine = nextLine[index - 1];
                    var currentCharNextLine = nextLine[index];
                    var nextCharNextLine = nextLine[index + 1];

                    if(Char.IsDigit(previousCharCurrentLine))
                    {
                        var updatedInputLine = currentLine.Remove(index);
                        var numbersInput = updatedInputLine.Split('.');
                        var number = Int32.Parse(numbersInput.Last());

                        if (numberOne == 0) numberOne = number;
                        else numberTwo = number;
                    }

                    if(Char.IsDigit(nextCharCurrentLine))
                    {
                        var updatedInputLine = currentLine.Remove(0, index + 1);
                        var numbersInput = updatedInputLine.Split('.');
                        var number = Int32.Parse(numbersInput.First());

                        if (numberOne == 0) numberOne = number;
                        else numberTwo = number;
                    }

                    if (Char.IsDigit(previousCharPreviousLine) && !Char.IsDigit(currentCharPreviousLine))
                    {
                        var updatedInputLine = previousLine.Remove(index);
                        var numbersInput = updatedInputLine.Split('.');
                        var number = Int32.Parse(numbersInput.Last());
                        if (numberOne == 0) numberOne = number;
                        else numberTwo = number;
                    }

                    if (Char.IsDigit(nextCharPreviousLine) && !Char.IsDigit(currentCharPreviousLine))
                    {
                        var updatedInputLine = previousLine.Remove(0, index + 1);
                        var numbersInput = updatedInputLine.Split('.');
                        var number = Int32.Parse(numbersInput.First());
                        if (numberOne == 0) numberOne = number;
                        else numberTwo = number;
                    }

                    if (Char.IsDigit(previousCharPreviousLine) && Char.IsDigit(currentCharPreviousLine) && !Char.IsDigit(nextCharPreviousLine))
                    {
                        var updatedInputLine = previousLine.Remove(index + 1);
                        var numbersInput = updatedInputLine.Split('.');
                        var number = Int32.Parse(numbersInput.Last());
                        if (numberOne == 0) numberOne = number;
                        else numberTwo = number;
                    }

                    if (Char.IsDigit(previousCharPreviousLine) && Char.IsDigit(currentCharPreviousLine) && Char.IsDigit(nextCharPreviousLine))
                    {
                        var updatedInputLine = previousLine.Remove(index + 2);
                        var numbersInput = updatedInputLine.Split('.');
                        var number = Int32.Parse(numbersInput.Last());
                        if (numberOne == 0) numberOne = number;
                        else numberTwo = number;
                    }

                    if (!Char.IsDigit(previousCharPreviousLine) && Char.IsDigit(currentCharPreviousLine) && Char.IsDigit(nextCharPreviousLine))
                    {
                        var updatedInputLine = previousLine.Remove(0, index);
                        var numbersInput = updatedInputLine.Split('.');
                        var number = Int32.Parse(numbersInput.First());
                        if (numberOne == 0) numberOne = number;
                        else numberTwo = number;
                    }

                    if (!Char.IsDigit(previousCharPreviousLine) && Char.IsDigit(currentCharPreviousLine) && !Char.IsDigit(nextCharPreviousLine))
                    {
                        var updatedInputLine = previousLine.Remove(0, index);
                        var numbersInput = updatedInputLine.Split('.');
                        var number = Int32.Parse(numbersInput.First());
                        if (numberOne == 0) numberOne = number;
                        else numberTwo = number;
                    }

                    if (Char.IsDigit(previousCharNextLine) && !Char.IsDigit(currentCharNextLine))
                    {
                        var updatedInputLine = nextLine.Remove(index);
                        var numbersInput = updatedInputLine.Split('.');
                        var number = Int32.Parse(numbersInput.Last());
                        if (numberOne == 0) numberOne = number;
                        else numberTwo = number;
                    }

                    if (!Char.IsDigit(currentCharNextLine) && Char.IsDigit(nextCharNextLine))
                    {
                        var updatedInputLine = nextLine.Remove(0, index + 1);
                        var numbersInput = updatedInputLine.Split('.');
                        var number = Int32.Parse(numbersInput.First());
                        if (numberOne == 0) numberOne = number;
                        else numberTwo = number;
                    }

                    if (Char.IsDigit(previousCharNextLine) && Char.IsDigit(currentCharNextLine) && !Char.IsDigit(nextCharNextLine))
                    {
                        var updatedInputLine = nextLine.Remove(index + 1);
                        var numbersInput = updatedInputLine.Split('.');
                        var number = Int32.Parse(numbersInput.Last());
                        if (numberOne == 0) numberOne = number;
                        else numberTwo = number;
                    }

                    if (Char.IsDigit(previousCharNextLine) && Char.IsDigit(currentCharNextLine) && Char.IsDigit(nextCharNextLine))
                    {
                        var updatedInputLine = nextLine.Remove(index + 2);
                        var numbersInput = updatedInputLine.Split('.');
                        var number = Int32.Parse(numbersInput.Last());
                        if (numberOne == 0) numberOne = number;
                        else numberTwo = number;
                    }

                    if (!Char.IsDigit(previousCharNextLine) && Char.IsDigit(currentCharNextLine) && Char.IsDigit(nextCharNextLine))
                    {
                        var updatedInputLine = nextLine.Remove(0, index);
                        var numbersInput = updatedInputLine.Split('.');
                        var number = Int32.Parse(numbersInput.First());
                        if (numberOne == 0) numberOne = number;
                        else numberTwo = number;
                    }

                    if (!Char.IsDigit(previousCharNextLine) && Char.IsDigit(currentCharNextLine) && !Char.IsDigit(nextCharNextLine))
                    {
                        var updatedInputLine = nextLine.Remove(0, index);
                        var numbersInput = updatedInputLine.Split('.');
                        var number = Int32.Parse(numbersInput.First());
                        if (numberOne == 0) numberOne = number;
                        else numberTwo = number;
                    }

                    if (numberOne != 0 && numberTwo != 0)
                    {
                        int gearRatio = numberOne * numberTwo;
                        partTwoSum += gearRatio;
                    }
                }
            }

            Console.WriteLine(partTwoSum);
        }

        public static List<int> GetStarSymbolIndex(string inputLine)
        {
            var result = new List<int>();

            var count = 0;
            var symbolIndex = 0;
            var start = 0;
            var end = inputLine.Length;
            while ((start <= end) && (symbolIndex > -1))
            {
                count = end - start;
                symbolIndex = inputLine.IndexOf('*', start, count);

                if (symbolIndex == -1) break;

                result.Add(symbolIndex);
                start = symbolIndex + 1;
            }

            return result;
        }
    }
}