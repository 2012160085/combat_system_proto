using System;

namespace proto
{
    public class A
    {
        public Name name = new Name("");
        public void print(){
            Console.WriteLine("name is " + name.ToString());
        }
        public A(){
            
        }
    }
}
