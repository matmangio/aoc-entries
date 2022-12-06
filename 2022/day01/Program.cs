using System;

namespace day01;

public static class Program {

    static void Main(string[] args) {

        List<int> maxThree = new List<int>(new int[3]);
        while (!isEOF()) {
            int current = getNextElfCarry();
            int minMax = maxThree.Min();
            if (current > minMax) 
                maxThree[maxThree.IndexOf(minMax)] = current;
        }

        Console.WriteLine("Star1: " + maxThree.Max());
        Console.WriteLine("Star2: " + maxThree.Sum());

    }

    private static int getNextElfCarry() {
        int carry = 0;
        string line = Console.ReadLine() + "";
        while (!line.Equals("")) {
            carry += int.Parse(line);
            line = Console.ReadLine() + "";
        }
        return carry;
    }

    private static bool isEOF() {
        return Console.In.Peek() == -1;
    }
}
