
/*
Func<int, int, int> sub = (a, b) => a - b;

Func<int, int> some = a => a * 2;

Func<int, int> some2 = a =>
{
    a = a + 2;
    return a;
};

int subResult = sub(10, 5);

Console.WriteLine(subResult);
*/


Some((a, b) => a + b, 5);
void Some(Func<int, int, int> fn, int number)
{
    var result = fn(number, number);
}