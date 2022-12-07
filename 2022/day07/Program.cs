using System;

namespace day07 {

    class Program {

        static void Main(string[] args) {

            Directory fileSystem = new FileSystemParser().parseTillEof(Console.In);
            List<Directory> smallDirs = findDirectoriesSmallerThan(fileSystem, 100000);

            int total = 0;
            foreach (Directory d in smallDirs) 
                total += d.getSize();

            Console.WriteLine("Star1: " + total);

        }

        static List<Directory> findDirectoriesSmallerThan(Directory root, int size) {
            List<Directory> matches = new List<Directory>();

            if (root.getSize() <= size) matches.Add(root);
            foreach(INode node in root) {
                if (node.isDirectory()) {
                    List<Directory> newMatches = findDirectoriesSmallerThan((Directory) node, size);
                    foreach (Directory dir in newMatches)
                        matches.Add(dir);
                }
            }

            return matches;
        }

    }

}