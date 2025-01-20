var sale1 = new Sale(15);
var beer1 = new Beer();

Some(sale1);
Some(beer1);

void Some(ISave save)
{
    save.Save();
}


interface ISale
{
    decimal Total { get; set; }

}

interface ISave
{
    public void Save();
}

public class Sale : ISale, ISave
{
    public decimal Total { get; set; }
    public Sale(decimal total)
    {
        this.Total = total;
    }

    public void Save()
    {
        Console.WriteLine("It was saved in the Sale DB!!");
    }
    public string GetInfo()
    {
        return "The total is " + Total;
    }
}

public class Beer : ISave
{
    public void Save()
    {
        Console.WriteLine("It was saved in the Beer DB!!");
    }
}