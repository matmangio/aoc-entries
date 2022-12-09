namespace day09 {

    public enum Direction {
        RIGHT,
        UP,
        LEFT,
        DOWN,
    }

    public static class Extension {

        private static Dictionary<Direction, Func<Position, Position>> updates = new Dictionary<Direction, Func<Position, Position>> {
            {Direction.RIGHT, p => {return new Position(p.x + 1, p.y);}},
            {Direction.LEFT, p => {return new Position(p.x - 1, p.y);}},
            {Direction.UP, p => {return new Position(p.x, p.y + 1);}},
            {Direction.DOWN, p => {return new Position(p.x, p.y - 1);}}
        };

        public static Func<Position,Position> moveFunc(this Direction dir) {
            if (updates.ContainsKey(dir))
                return updates[dir];
            throw new Exception("Invalid direction");
        }

    }
}