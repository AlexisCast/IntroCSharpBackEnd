
var names = new List<string> { "John", "Mary", "Sue", "Ana" };

var namesRestults = from n in names
                    where n.Length > 3 && n.Contains("a")
                    orderby n descending
                    select n;

var namesRestults2 = names
                    .Where(n => n.Length > 3 && n.Contains("a"))
                    .OrderByDescending(n => n)
                    .Select(n => n);

foreach (var name in namesRestults)
{
    Console.WriteLine(name);
}

foreach (var name in namesRestults2)
{
    Console.WriteLine(name);
}