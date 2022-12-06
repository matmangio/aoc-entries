using System;

namespace day02;
public class Program {

    public static void Main(string[] args) {
        
        int myPoints = 0;

        while (!isEOF()) {
            string line = Console.ReadLine() + "";
            myPoints += pointsPerRound(line[0], line[2]);
        }

        Console.WriteLine("Star1: " + myPoints);

    }

    private static int pointsPerRound(char opponentMove, char myMove) {
        int opponentMoveValue = evaluateMove(opponentMove);
        int myMoveValue = evaluateMove(myMove);

        int points = myMoveValue + 1;
        if ((opponentMoveValue + 1) % 3 == myMoveValue) {
            points += 6;
        } else if (myMoveValue == opponentMoveValue) {
            points += 3;
        }

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

    private static bool isEOF() {
        return Console.In.Peek() == -1;
    }

}
