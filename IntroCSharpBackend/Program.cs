using System.Dynamic;

Sale sale = new Sale(15);
var message = sale.GetInfo();

Console.WriteLine(message);

var saleWithTax = new SaleWithTax(15, 1.16m);
var messageWithTax = saleWithTax.GetInfoWithTax();
var messageWithTax2 = saleWithTax.GetInfoWithTax();
Console.WriteLine(messageWithTax);
Console.WriteLine(messageWithTax2);

Console.WriteLine(saleWithTax.GetInfo("Hello World"));
Console.WriteLine(saleWithTax.GetInfo(1));


class SaleWithTax : Sale
{
    public decimal Tax { get; set; }
    public SaleWithTax(decimal total, decimal tax) : base(total)
    {
        this.Tax = tax;
    }
    public string GetInfoWithTax()
    {
        return "The total is: " + Total + " Tax is: " + Tax;
    }
    public override string GetInfo()    // override the method in the parent class
    {
        return "The total is: " + Total + " Tax is: " + Tax;
    }
    public string GetInfo(string message) // method overloading to have multiple parameters with the same name
    {
        return message;
    }
    public string GetInfo(int a) // method overloading to have multiple parameters with the same name
    {
        return a.ToString();
    }
}

public class Sale
{
    public decimal Total { get; set; }
    private decimal _some;
    public Sale(decimal total)
    {
        this.Total = total;
        _some = 8;
    }
    public virtual string GetInfo() // virtual allows to override the method in the child class
    {
        return "The total is " + Total;
    }
}