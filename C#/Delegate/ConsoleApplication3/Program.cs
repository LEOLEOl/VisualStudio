using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace DelegateDemo
{
    public delegate void MyEventHandler(string msg);

    public class Demo
    {
        public static void Main()
        {
            Demo d = new Demo();
            MyEventHandler handler = new MyEventHandler(d.DisplayMsg);
            handler += d.ShowHello;
            handler("Test");
            Console.ReadLine();
        }
        public void DisplayMsg(string msg)
        {
            Console.WriteLine(msg);
        }
        public void ShowHello(string name)
        {
            Console.WriteLine("Hello " + name);
        }
    }
}