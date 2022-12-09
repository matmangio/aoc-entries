using System;

namespace day09;

public class Program {

    private record struct Motion(Direction dir, int steps) {}

    static void Main(string[] args) {

        List<Motion> movement = parseInput();
        List<Position> knots = new List<Position>();
        for (int i = 0; i < 10; i++) {
            knots.Add(new Position());
        }
        
        List<Position> secondKnotVisitedPositions = new List<Position>();
        secondKnotVisitedPositions.Add(knots[1]);

        List<Position> lastKnotVisitedPositions = new List<Position>();
        lastKnotVisitedPositions.Add(knots.Last());

        foreach (Motion m in movement) {
            for (int i = 0; i < m.steps; i++) {
                knots[0] = move(m.dir, knots.First());
                for (int j = 1; j < knots.Count(); j++)
                    knots[j] = updatePosition(knots[j], knots[j-1]);

                if (!secondKnotVisitedPositions.Contains(knots[1]))
                    secondKnotVisitedPositions.Add(knots[1]);

                if (!lastKnotVisitedPositions.Contains(knots.Last()))
                    lastKnotVisitedPositions.Add(knots.Last());
            }
        }

        Console.WriteLine("Star1: " + secondKnotVisitedPositions.Count());
        Console.WriteLine("Star2: " + lastKnotVisitedPositions.Count());

    }

    static List<Motion> parseInput() {
        List<Motion> output = new List<Motion>();

        string line = Console.ReadLine() + "";
        while (line != "") {
            string[] parts = line.Split(" ");

            if (parts.Length > 1) {
                Motion next = new Motion(toDirection(parts[0][0]), int.Parse(parts[1]));
                output.Add(next);
            }

            line = Console.ReadLine() + "";
        }

        return output;
    }

    static Direction toDirection(char c) {
        switch (c) {
            case 'R': return Direction.RIGHT;
            case 'L': return Direction.LEFT;
            case 'U': return Direction.UP;
            case 'D': return Direction.DOWN;
            default: throw new Exception("Invalid direction: " + c);
        }
    }

    static Position move(Direction dir, Position prev) {
        return dir.moveFunc().Invoke(prev);
    }

    private static Position updatePosition(Position tail, Position head) {
        Position next = new Position(tail.x, tail.y);

        if (!Position.adiacent(tail, head)) {
            next.x = moveOneTowards(tail.x, head.x);
            next.y = moveOneTowards(tail.y, head.y);
        }
        
        return next;
    }

    private static int moveOneTowards(int from, int to) {
        if (to - from >= 1) {
            return from + 1;
        } else if (to - from <= -1) {
            return from - 1;
        }
        return from;
    }

}
