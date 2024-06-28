namespace _27_06.Task2;

public abstract class Base
{
    public int Id { get; protected set; }
    public string Name { get; protected set; }
    protected Base(string name)
    {
        Name = name;
    }
    public override string ToString()
    {
        return $"Id: {Id} | Name: {Name}";
    }
}
