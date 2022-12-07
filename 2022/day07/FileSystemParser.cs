using System.Text.RegularExpressions;

namespace day07
{
    public class FileSystemParser {

        Directory root;
        Directory currentDir;

        private Dictionary<string, Func<string[], int>> knownFunctions;

        public FileSystemParser() {
            root = new Directory("/", null);
            currentDir = root;

            knownFunctions = new Dictionary<string, Func<string[], int>>();
            knownFunctions.Add("cd", args => {
                switch (args[0]) {
                    case "..": currentDir = currentDir.parent(); break;
                    case "/": currentDir = root; break;
                    default: 
                        Directory? childDir = currentDir.findChildDirectory(args[0]);
                        currentDir = (childDir != null) ? childDir : currentDir; 
                        break;
                }
                return 0;
            });
        }

        public Directory parseTillEof(TextReader input) {

            while (!isEOF(input)) {
                string line = input.ReadLine() + "";
                if (line.Count() < 1) continue;
                if (line.First().Equals('$'))
                    executeCommand(line);
                else
                    addToCurrentDir(line);
            }

            currentDir = root;
            return root;

        }

        private void executeCommand(string line) {
            string[] components = line.Split(" ");
            string command = components[1];
            string[] args = components.Skip(2).ToArray();

            if (knownFunctions.ContainsKey(command))
                knownFunctions[command].Invoke(args);
        }

        private void addToCurrentDir(string line) {
            string[] arguments = line.Split(" ");
            if (Regex.IsMatch(arguments[0], @"\d+"))
                currentDir.Add(new ConcreteFile(arguments[1], int.Parse(arguments[0]), currentDir));
            else 
                currentDir.Add(new Directory(arguments[1], currentDir));
        }

        static bool isEOF(TextReader input) {
            return input.Peek() == -1;
        }

    }
}