namespace day07 {

    internal class ConcreteFile : INode {

        string name;
        int size;
        Directory parentDir;

        public ConcreteFile(string name, int size, Directory parentDir) {
            this.name = name;
            this.size = size;
            this.parentDir = parentDir;
        }

        public string getName() {
            return this.name;
        }

        public int getSize() {
            return this.size;
        }

        public bool isDirectory() {
            return false;
        }

        public Directory parent() {
            return parentDir;
        }
    }

}