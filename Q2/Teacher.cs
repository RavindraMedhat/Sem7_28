using System;
using System.Collections.Generic;
using System.Text;

namespace Q2
{
    class Teacher : Icollage
    {
        public int id { get; set; }
        public string name { get; set; }
        public string Sub { get; set; }

        public Teacher(int ID)
        {
            id = ID;
            Console.Write("Enter name :-");
            name = Console.ReadLine();
            Console.Write("Enter Subject :-");
            Sub = Console.ReadLine();
        }
        public void display()
        {
            Console.WriteLine("ID :- " + id + " Name :- " + name +  " Subject :- " + Sub);
        }

        public void update()
        {
            Console.Write("Enter new name :-");
            name = Console.ReadLine();
            Console.Write("Enter new Subject :-");
            Sub = Console.ReadLine();
        }
    }
}
