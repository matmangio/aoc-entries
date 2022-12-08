using System;

namespace day08;

class Program {

    static void Main(string[] args) {

        int[][] trees = parseInput();

        int visibleTrees = 0;
        for (int i = 0; i < trees.Count(); i++) {
            for (int j = 0; j < trees[i].Count(); j++) {
                visibleTrees += (isVisible(trees, i, j))? 1 : 0;
            }
        }

        Console.WriteLine("Star1: " + visibleTrees);

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
        return isVisibileFrom(matrix, row, col, false, false) ||
               isVisibileFrom(matrix, row, col, false, true)  ||
               isVisibileFrom(matrix, row, col, true, false)  ||
               isVisibileFrom(matrix, row, col, true, true);
    }

    static bool isVisibileFrom(int[][] matrix, int row, int col, bool rowOrCol, bool incOrDec) {
        int tree = matrix[row][col];
        
        int axis = (rowOrCol)? row : col;
        int update = (incOrDec)? 1 : -1;
        int maxOnAxis = (rowOrCol)? matrix.Count() : matrix[0].Count();
        Predicate<int> condition = (incOrDec)? k => (k < maxOnAxis) : k => (k >= 0);
        Predicate<int> visibleIf = (rowOrCol)? k => (matrix[k][col] < tree) : (k) => (matrix[row][k] < tree);

        bool visible = true;
        for (int k = axis + update; condition(k) && visible; k += update) {
            visible = visibleIf(k);
        }

        return visible;
    }
}
