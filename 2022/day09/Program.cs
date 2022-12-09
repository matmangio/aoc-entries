using System;

namespace day09;

public class Program {

    private record struct Motion(Direction dir, int steps) {}

    static void Main(string[] args) {

        List<Motion> movement = parseInput();
        Position head = new Position(), tail = new Position();
        List<Position> visitedPositions = new List<Position>();
        visitedPositions.Add(tail);

        foreach (Motion m in movement) {
            for (int i = 0; i < m.steps; i++) {
                head = move(m.dir, head);
                tail = updatePosition(tail, head);
                if (!visitedPositions.Contains(tail))
                    visitedPositions.Add(tail);
            }
        }

        Console.WriteLine("Star1: " + visitedPositions.Count());

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
