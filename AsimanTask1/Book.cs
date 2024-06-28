namespace _27_06.Task2;

public class Book : Base
{
    private static int _id;

    public string Author { get; set; }
    public Category Category { get; set; }
    public Book(string name, string author, Category category) : base(name)
    {
        Id = ++_id;
        Author = author;
        Category = category;
    }

    public override string ToString()
    {
        return base.ToString() + $"| Author: {Author} | Category: {Category.Name}";
    }


}
