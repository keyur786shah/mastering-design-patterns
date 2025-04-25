// Step 1: Common Interface
public interface IFileSystemItem
{
    void Display(string indent = "");
}

// Step 2: Leaf Class
public class File : IFileSystemItem
{
    private string _name;
    public File(string name) { _name = name; }

    public void Display(string indent = "") => Console.WriteLine($"{indent}- File: {_name}");
}

// Step 3: Composite Class
public class Folder : IFileSystemItem
{
    private string _name;
    private List<IFileSystemItem> _items = new List<IFileSystemItem>();

    public Folder(string name) { _name = name; }

    public void AddItem(IFileSystemItem item) => _items.Add(item);

    public void Display(string indent = "")
    {
        Console.WriteLine($"{indent}+ Folder: {_name}");
        foreach (var item in _items)
            item.Display(indent + "  ");
    }
}

// Step 4: Client
class Program
{
    static void Main()
    {
        var file1 = new File("Resume.docx");
        var file2 = new File("Photo.png");

        var folder1 = new Folder("Documents");
        folder1.AddItem(file1);

        var folder2 = new Folder("Pictures");
        folder2.AddItem(file2);

        var rootFolder = new Folder("Root");
        rootFolder.AddItem(folder1);
        rootFolder.AddItem(folder2);

        rootFolder.Display();
    }
}
