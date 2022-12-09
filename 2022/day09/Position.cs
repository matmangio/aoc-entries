namespace day09;

public record struct Position(int x, int y) {
    public static bool adiacent(Position pos1, Position pos2) {
        return Math.Abs(pos1.x - pos2.x) <= 1 && Math.Abs(pos1.y - pos2.y) <= 1;
    }
}
