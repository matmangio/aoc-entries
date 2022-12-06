using System;

namespace day03;
class Program {

    static void Main(string[] args) {
        int sum = 0;

        while (!isEOF()) {
            sum += priority(findCommonElement(Console.ReadLine() + ""));
        }

        Console.WriteLine("Star1: " + sum);
    }

    static char findCommonElement(string rucksack) {
        string firstHalf = rucksack.Substring(0, rucksack.Length / 2);
        string secondHalf = rucksack.Substring(rucksack.Length / 2, rucksack.Length / 2);
        return firstHalf.Intersect(secondHalf).First();
    }

    static int priority(char item) {
        if (char.IsLower(item)) 
            return item - 'a' + 1;
        return item - 'A' + 27;
    }

    static bool isEOF() {
        return Console.In.Peek() == - 1;
    }
}
