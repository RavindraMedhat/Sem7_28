using System;
using System.Collections.Generic;
using System.Text;

namespace Q2
{
    class student : Icollage
    {

        public int id { get; set; }
        public string name { get; set; }
        public string dob { get; set; }
        public int Sem { get; set; }

        public student(int Id)
        {
            id = Id;
            Console.Write("Enter name :-");
            name = Console.ReadLine();
            Console.Write("Enter DOB :-");
            dob = Console.ReadLine();
            Console.Write("Enter Semster :-");
            Sem = Convert.ToInt32(Console.ReadLine());
        }
        public void display()
        {
            Console.WriteLine("ID :- " + id + " Name :- " + name + " Dob :- " + dob + " Sem :- " + Sem);
        }

        public void update()
        {
            Console.Write("Enter New name :-");
            name = Console.ReadLine();
            Console.Write("Enter New DOB :-");
            dob = Console.ReadLine();
            Console.Write("Enter Semster :-");
            Sem = Convert.ToInt32(Console.ReadLine());
        }
    }
}
