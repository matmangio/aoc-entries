namespace day07 {

    public interface INode {
        Directory parent();
        bool isDirectory();

        string getName();

        int getSize();
    }

}