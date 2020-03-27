Console.WriteLine("str");

using System;

public class Test {
    public void Print(string str) {
        Console.WriteLine(str);
    }
}

static int Main(string[] args)
{
    // System.Console.WriteLine();
    new Test().Print("123456");
    return 0;
}
Main(null);


new Test().Print("zzzzzz");