using System.Collections;

namespace day07 {

    public class Directory : INode, IEnumerable<INode> {
        
        private string name;
        Directory? parentDir;
        List<INode> content;

        public Directory(string name, Directory? parentDir) {
            this.name = name;
            this.parentDir = parentDir;
            this.content = new List<INode>();
        }

        public bool isDirectory() {
            return true;
        }

        public Directory parent() {
            if (this.parentDir == null) 
                return this;
            return this.parentDir;
        }

        public void Add(INode node) {
            content.Add(node);
        }

        public Directory? findChildDirectory(string name) {
            foreach (INode node in content)
                if (node.isDirectory() && node.getName().Equals(name))
                    return (Directory) node;
            return null;
        }

        public string getName() {
            return name;
        }

        public int getSize() {
            int total = 0;

            foreach (INode node in content)
                total += node.getSize();

            return total;
        }

        public IEnumerator<INode> GetEnumerator() {
            return content.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return content.GetEnumerator();
        }
    }
}