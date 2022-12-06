using System;

namespace day04;

class Program {

    record Assignment {
        public int start;
        public int end;
    }

    static void Main(string[] args) {

        int fullContainmentsCounter = 0;
        int overlapCounter = 0;

        while (!isEOF()) {
            string line = Console.ReadLine() + "";
            if (line.Contains(',')) {
                string[] assignmentsStrings = line.Split(',');
                Assignment ass1 = parseAssignement(assignmentsStrings[0]);
                Assignment ass2 = parseAssignement(assignmentsStrings[1]);
                if (fullyContains(ass1, ass2) || fullyContains(ass2, ass1))
                    fullContainmentsCounter++;
                if (overlap(ass1, ass2))
                    overlapCounter++;
            }
        }

        Console.WriteLine("Star1: " + fullContainmentsCounter);
        Console.WriteLine("Star2: " + overlapCounter);

    }

    static bool fullyContains(Assignment container, Assignment contained) {
        return container.start <= contained.start && container.end >= contained.end;
    }

    static bool overlap(Assignment ass1, Assignment ass2) {
        return (ass1.start <= ass2.end && ass1.end >= ass2.start) || (ass2.start <= ass1.end && ass2.end >= ass1.start);
    }

    static Assignment parseAssignement(string str) {
        Assignment output = new Assignment();
        string[] splits = str.Split('-');
        output.start = int.Parse(splits[0]);
        output.end = int.Parse(splits[1]);
        return output;
    }

    static bool isEOF() {
        return Console.In.Peek() == -1;
    }
}
