using System;

namespace day02;
public class Program {

    public static void Main(string[] args) {
        
        int firstStartPoints = 0, secondStarPoints = 0;

        while (!isEOF()) {
            string line = Console.ReadLine() + "";
            if (line.Length >= 2) {
                firstStartPoints += pointsForFirstStar(line[0], line[2]);
                secondStarPoints += pointsForSecondStar(line[0], line[2]);
            }
        }

        Console.WriteLine("Star1: " + firstStartPoints);
        Console.WriteLine("Star2: " + secondStarPoints);

    }

    private static int pointsForFirstStar(char opponentMove, char myMove) {
        int opponentMoveValue = evaluateMove(opponentMove);
        int myMoveValue = evaluateMove(myMove);

        int points = myMoveValue + 1;
        if (modulus(opponentMoveValue + 1, 3) == myMoveValue) {
            points += 6;
        } else if (myMoveValue == opponentMoveValue) {
            points += 3;
        }

        return points;
    }

    private static int pointsForSecondStar(char opponentMove, char outcome) {
        int points = evaluateMove(outcome) * 3;
        points += modulus(evaluateMove(opponentMove) + offsetByOutcome(outcome), 3) + 1;
        return points;
    }

    private static int evaluateMove(char move) {
        char reference;
        if (move <= 'C') 
            reference = 'A';
        else 
            reference = 'X';
        return move - reference;
    }

    private static int offsetByOutcome(char outcome)
    {
        return outcome - 'Y';
    }

    private static bool isEOF() {
        return Console.In.Peek() == -1;
    }

    private static int modulus(int dividend, int divisor) {
        return (dividend % divisor + divisor) % divisor;
    }

}
