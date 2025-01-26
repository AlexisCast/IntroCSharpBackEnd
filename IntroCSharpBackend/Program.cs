
using System.Text.Json;

var baz = new People()
{
    Name = "Baz",
    Age = 31,
};

string json = JsonSerializer.Serialize(baz);

Console.WriteLine(json);

string myJson = @"{
    ""Name"":""Buzz"",
    ""Age"":31
}";

People? buz = JsonSerializer.Deserialize<People>(myJson);
Console.WriteLine(buz?.Name);
Console.WriteLine(buz?.Age);

public class People
{
    public string Name { get; set; }
    public int Age { get; set; }
}