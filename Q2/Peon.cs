using System;
using System.Collections.Generic;
using System.Text;

namespace Q2
{
    class Peon : Icollage
    {
        public int id { get ; set ; }
        public string name { get; set ; }
        public string workType { get; set ; }

        public Peon(int ID)
        {
            id = ID;
            Console.Write("Enter name :-");
            name = Console.ReadLine();
            Console.Write("Enter Work Type :-");
            workType = Console.ReadLine();
        }
        public void display()
        {
            Console.WriteLine("ID :- " + id +" Name :- " + name + " Work Type :- " + workType);
        }

        public void update()
        {
            throw new NotImplementedException();
        }
    }
}
