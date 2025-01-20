
var numbers = new MyList<int>(5);
var names = new MyList<string>(5);
var beers = new MyList<Beer>(2);

numbers.Add(1);
numbers.Add(2);
numbers.Add(3);
numbers.Add(4);
numbers.Add(5);
numbers.Add(6);
Console.WriteLine(numbers.GetContent());

names.Add("John1");
names.Add("Doe2");
names.Add("Jane3");
names.Add("Doe4");
names.Add("John5");
names.Add("Doe6");
names.Add("Doe7");
Console.WriteLine(names.GetContent());

beers.Add(new Beer()
{
    Names = "Beer1",
    Price = 5
});
beers.Add(new Beer()
{
    Names = "Beer2",
    Price = 6
});
beers.Add(new Beer()
{
    Names = "Beer3",
    Price = 7
});
Console.WriteLine(beers.GetContent());


internal class Beer
{
    public string Names { get; set; }
    public int Price { get; set; }

    public override string ToString()
    {
        return $"Name: {Names} | Price: {Price}";
    }
}

public class MyList<T>
{
    private List<T> _list = new List<T>();
    private int _limit;
    public MyList(int limit)
    {
        _limit = limit;
        _list = new List<T>();
    }

    public void Add(T element)
    {
        Console.WriteLine("_list.Count: " + _list.Count + " _limit: " + _limit);
        if (_list.Count < _limit)
        {
            _list.Add(element);
        }
        else
        {
            Console.WriteLine("Limit exceeded!!");
        }
    }

    public string GetContent()
    {
        var content = "";
        foreach (var element in _list)
        {
            content += element + ", ";
        }
        return content;
    }
}