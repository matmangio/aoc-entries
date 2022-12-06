using System;

namespace day06;
class Program {

    static void Main(string[] args) {

        string input = Console.ReadLine() + "";

        int endIndex = 3;
        for (; ContainsDuplicates(input.Substring(endIndex - 3, 4)); endIndex++);

        Console.WriteLine("Star1: " + (endIndex + 1));

    }

    static bool ContainsDuplicates(string input) {
        foreach (char c in input) {
            if (input.Where(c.Equals).Count() > 1)
                return true;
        }
        return false;
    }

}
