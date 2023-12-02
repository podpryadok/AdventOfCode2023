using System.IO;
using System.Linq;

// Part One
var path = "/Users/ihorpodpriadok/Projects/AdventOfCode2023/AdventOfCode2023/Day1/input.txt";
var input = File.ReadAllLines(path);

int sumPartOne = 0;

foreach (var ip in input)
{
    var digit = FinalDigitFromLine(ip);
    sumPartOne += digit;
}

Console.WriteLine(sumPartOne);

// Part Two

int sumPartTwo = 0;
string[] numbers = { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
string[] replaceNumbers = { "on1e", "tw2o", "th3ee", "fo4ur", "fi5ve", "si6x", "se7ven", "eig8ht", "ni9ne" };

foreach (var ip in input)
{
    var newInput = ip;
    foreach (var number in numbers)
    {
        var togle = true;
        while (togle)
        {
            if (newInput.Contains(number))
            {
                var index = Array.IndexOf(numbers, number);
                newInput = newInput.Replace(number, replaceNumbers[index]);
            }
            else { togle = false; }
        }
    }

    var digit = FinalDigitFromLine(newInput);
    sumPartTwo += digit;
}

Console.WriteLine(sumPartTwo);


int FinalDigitFromLine(string input)
{
    int result = 0;

    var DigetsArray = input.Where(char.IsDigit).ToArray();
    if (DigetsArray == null) return result;

    var digit = String.Concat(DigetsArray.First(), DigetsArray.Last());

    Int32.TryParse(digit, out result);

    return result;
}