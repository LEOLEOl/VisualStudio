using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateDemo
{
    public delegate void MyEventHandler(string msg);
    
    public class Window
    {
        public event MyEventHandler Click;
        
        public Window(int top, int left)
        {
            this.top = top;
            this.left = left;
        }
        // mô phỏng vẽ cửa sổ
        public virtual void DrawWindow() { }
        public void FireEvent()
        {
            if (Click != null)
                Click("Event Fire.");
        }
        // Có hai biến thành viên private do đó hai
        // biến này sẽ không thấy bên trong lớp con
        int top;
        private int left;
    }
    // ListBox dẫn xuất từ Window
    public class ListBox : Window
    {
        public ListBox(int top, int left)
            : base(top, left)
        {
            //Console.WriteLine("Constructor's ListBox have 2 parameter");
        }
        // Khởi dựng có tham số
        public ListBox(int top, int left, string theContents)
            : base(top, left) // gọi khởi dựng của lớp cơ sở
        {
            mListBoxContents = theContents;
        }

        public override void DrawWindow()
        {
            Console.WriteLine("DrawWindow's ListBox");
        }

        // biến thành viên private
        private string mListBoxContents;
    }

    public class Tester
    {
        public static void Main()
        {
            Window w = new Window(100, 100);
            w.Click += w_Click;
            w.FireEvent(); // phát sinh sự kiện
            Console.ReadLine();
        }

        static void w_Click(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
