using System;
using System.Text;
using System.Text.RegularExpressions;

namespace day05;
class Program {

    record Step {
        public int boxes, fromStack, toStack;
    }

    static void Main(string[] args) {

        List<Stack<char>> stacks = getInitialStacks();

        while (!isEOF()) {
            Step next = getNextStep();
            stacks = executeStep(stacks, next);
        }

        Console.WriteLine("Star1: " + getStacksTops(stacks));

    }

    private static List<Stack<char>> getInitialStacks() {
        List<Stack<char>> stacks = new List<Stack<char>>();

        string line = Console.ReadLine() + "";
        while (line != "") {

            for (int i = 0; i < line.Length; i++) {
                char c = line[i];
                if (char.IsLetter(c))
                    pushOnStack(stacks, i, c);
            }

            line = Console.ReadLine() + "";
        }

        reverseStacks(stacks);

        return stacks;
    }

    private static void reverseStacks(List<Stack<char>> stacks) {
        foreach (Stack<char> stack in stacks) {
            List<char> supportList = new List<char>();

            while (stack.Count > 0)
                supportList.Add(stack.Pop());

            foreach (char c in supportList)
                stack.Push(c);
        }
    }

    private static void pushOnStack(List<Stack<char>> stacks, int i, char c) {
        while (stacks.Count - 1 < i / 4)
            stacks.Add(new Stack<char>());
        stacks[i / 4].Push(c);
    }

    private static Step getNextStep() {
        Step step = new Step();

        string line = Console.ReadLine() + "";
        Match[] numbers = Regex.Matches(line, @"\d+").ToArray();

        if (numbers.Count() >= 3) {
            step.boxes = int.Parse(numbers[0].ToString());
            step.fromStack = int.Parse(numbers[1].ToString()) - 1;
            step.toStack = int.Parse(numbers[2].ToString()) - 1;
        } else {
            step.boxes = -1;
        }

        return step;
    }

    private static List<Stack<char>> executeStep(List<Stack<char>> stacks, Step step) {
        for (int i = 0; i < step.boxes; i++)
            stacks[step.toStack].Push(stacks[step.fromStack].Pop());
        return stacks;
    }

    private static string getStacksTops(List<Stack<char>> stacks) {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < stacks.Count; i++) {
            sb.Append(stacks[i].Peek());
        }
        return sb.ToString();
    }

    private static bool isEOF() {
        return Console.In.Peek() == -1;
    }
}
