namespace _27_06.Task2;

public class Category : Base
{
    private static int _id;
    public Category(string name) : base(name)
    {
        Id = ++_id;
    }
}
