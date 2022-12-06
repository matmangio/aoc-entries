using System;

namespace day06;
class Program {

    static void Main(string[] args) {

        string input = Console.ReadLine() + "";

        Console.WriteLine("Star1: " + charactersBeforeDuplicates(input, 4));
        Console.WriteLine("Star2: " + charactersBeforeDuplicates(input, 14));

    }

    static int charactersBeforeDuplicates(string input, int windowSize) {
        int startIndex;
        for (startIndex = 0; ContainsDuplicates(input.Substring(startIndex, windowSize)); startIndex++);
        return startIndex + windowSize;
    }

    static bool ContainsDuplicates(string input) {
        foreach (char c in input) {
            if (input.Where(c.Equals).Count() > 1)
                return true;
        }
        return false;
    }

}
