using System;

namespace day07 {

    class Program {

        static void Main(string[] args) {

            const int smallTreshold = 100000;
            const int diskSpace = 70000000;
            const int neededSpace = 30000000;

            Directory fileSystem = new FileSystemParser().parseTillEof(Console.In);

            int total = 0;
            List<Directory> smallDirs = findDirectoriesMatching(fileSystem, dir => (dir.getSize() <= smallTreshold));
            foreach (Directory d in smallDirs) 
                total += d.getSize();
            Console.WriteLine("Star1: " + total);

            int spaceToFree = neededSpace - (diskSpace - fileSystem.getSize());
            List<Directory> bigEnoughDirs = findDirectoriesMatching(fileSystem, dir => (dir.getSize() >= spaceToFree));
            Directory? smallestAmongBigEnough = bigEnoughDirs.MinBy(dir => dir.getSize());
            Console.WriteLine("Star2: " + ((smallestAmongBigEnough != null)? smallestAmongBigEnough.getSize() : "not found" ));

        }

        static List<Directory> findDirectoriesMatching(Directory root, Predicate<Directory> predicate) {
            List<Directory> matches = new List<Directory>();

            if (predicate.Invoke(root)) matches.Add(root);
            foreach(INode node in root) {
                if (node.isDirectory()) {
                    List<Directory> newMatches = findDirectoriesMatching((Directory) node, predicate);
                    foreach (Directory dir in newMatches)
                        matches.Add(dir);
                }
            }

            return matches;
        }

    }

}