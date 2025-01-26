
//var show = Show;

//Show("Hello, World!");

//Some(show, "Hello, How are you?!");

//void Show(string message)
//{
//    Console.WriteLine(message);
//}

//void Some(Action<string> fn, string message) //return nothing
//{
//    show("Does something at the start...");
//    fn(message);
//    Console.WriteLine("Does somthing at the end...");
//}


//--------------------------------------------------------------

var show = Show;

Some(show, "Hello, How are you?!");

string Show(string message)
{
    return message.ToUpper();
}

void Some(Func<string, string> fn, string message) //return something
{
    Console.WriteLine(show("Does something at the start..."));
    Console.WriteLine(fn(message));
    Console.WriteLine("Does somthing at the end...");
}



