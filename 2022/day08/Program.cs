using System;

namespace day08;

class Program {

    record TreeDirectionPair {
        public bool visibleFromOutside;
        public int treesVisibileInDirection;

        public TreeDirectionPair(bool visible, int count) {
            this.visibleFromOutside = visible;
            this.treesVisibileInDirection = count;
        }
    }

    static void Main(string[] args) {

        int[][] trees = parseInput();

        int maxScore = 0;
        int visibleTrees = 0;
        for (int i = 0; i < trees.Count(); i++) {
            for (int j = 0; j < trees[i].Count(); j++) {
                visibleTrees += (isVisible(trees, i, j))? 1 : 0;
                int score = treeScenicScore(trees, i, j);
                maxScore = (score > maxScore)? score : maxScore;
            }
        }

        Console.WriteLine("Star1: " + visibleTrees);
        Console.WriteLine("Star2: " + maxScore);

    }

    static int[][] parseInput() {
        List<int[]> matrix = new List<int[]>();

        string line = Console.ReadLine() + "";
        int rowLength = line.Length;
        while (line != "") {
            int[] row = new int[rowLength];

            for (int i = 0; i < rowLength; i++) 
                row[i] = (int) char.GetNumericValue(line[i]);

            matrix.Add(row);

            line = Console.ReadLine() + "";
        }

        return matrix.ToArray();
    }

    static bool isVisible(int[][] matrix, int row, int col) {
        return isVisibileFrom(matrix, row, col, false, false).visibleFromOutside ||
               isVisibileFrom(matrix, row, col, false, true).visibleFromOutside  ||
               isVisibileFrom(matrix, row, col, true, false).visibleFromOutside  ||
               isVisibileFrom(matrix, row, col, true, true).visibleFromOutside;
    }

    static int treeScenicScore(int[][] matrix, int row, int col) {
        return isVisibileFrom(matrix, row, col, false, false).treesVisibileInDirection *
               isVisibileFrom(matrix, row, col, false, true).treesVisibileInDirection  *
               isVisibileFrom(matrix, row, col, true, false).treesVisibileInDirection  *
               isVisibileFrom(matrix, row, col, true, true).treesVisibileInDirection;
    }

    private static TreeDirectionPair isVisibileFrom(int[][] matrix, int row, int col, bool rowOrCol, bool incOrDec) {
        int tree = matrix[row][col];
        
        int axis = (rowOrCol)? row : col;
        int update = (incOrDec)? 1 : -1;
        int maxOnAxis = (rowOrCol)? matrix.Count() : matrix[0].Count();
        Predicate<int> condition = (incOrDec)? k => (k < maxOnAxis) : k => (k >= 0);
        Predicate<int> visibleIf = (rowOrCol)? k => (matrix[k][col] < tree) : (k) => (matrix[row][k] < tree);

        int count = 0;
        bool visible = true;
        for (int k = axis + update; condition(k) && visible; k += update) {
            visible = visibleIf(k);
            count++;
        }

        return new TreeDirectionPair(visible, count);
    }
}
