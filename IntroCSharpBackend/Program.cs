Sale sale = new Sale(15);
var message = sale.GetInfo();

Console.WriteLine(message);

public class Sale
{
    public decimal Total { get; set; }
    private decimal _some;
    public Sale(decimal total)
    {
        this.Total = total;
        _some = 8;
    }
    public string GetInfo()
    {
        return "The total is " + Total;
    }
}