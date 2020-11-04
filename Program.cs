using System;

namespace proto
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Callbacks c = new Callbacks();
            Callbacks.instance = c;
            A a = new A();
            Console.WriteLine("A's name is " + a.name.ToString());
            c.printName += a.print;
            a.name.value = "BB";
            Console.WriteLine("A's name is now " + a.name.ToString());
            
            c.printName();
        }
    }
}
