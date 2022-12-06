using System;

namespace day01;

public static class Program {

    static void Main(string[] args) {

        int max = 0;
        while (!isEOF()) {
            int current = getNextElfCarry();
            if (current > max) 
                max = current;
        }

        Console.WriteLine("Star1: " + max);

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
