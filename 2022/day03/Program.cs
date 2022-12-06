using System;

namespace day03;
class Program {

    static void Main(string[] args) {
        int sumFirstStar = 0, sumSecondStar = 0;

        string[] rucksackGroup = new string[3];
        int counter = 0;

        while (!isEOF()) {
            string rucksack = Console.ReadLine() + "";

            if (rucksack.Length > 0) {
                sumFirstStar += priority(findCommonElementInCompartments(rucksack));

                rucksackGroup[counter] = rucksack;
                counter++;

                if (counter >= 3) {
                    sumSecondStar += priority(findCommonElementInRucksacks(rucksackGroup));
                    counter = 0;
                }
            }
        }

        Console.WriteLine("Star1: " + sumFirstStar);
        Console.WriteLine("Star2: " + sumSecondStar);
    }

    static char findCommonElementInCompartments(string rucksack) {
        string firstHalf = rucksack.Substring(0, rucksack.Length / 2);
        string secondHalf = rucksack.Substring(rucksack.Length / 2, rucksack.Length / 2);
        return firstHalf.Intersect(secondHalf).First();
    }

    static char findCommonElementInRucksacks(string[] rucksacks) {
        IEnumerable<char> intersect = rucksacks[0];
        for (int i = 1; i < 3; i++)
            intersect = intersect.Intersect(rucksacks[i]);
        return intersect.First();
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
