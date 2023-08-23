using System;
using System.Collections.Generic;
using System.Linq;

namespace Q2
{
    class Program
    {
        static void Main(string[] args)
        {
            int exit = 0;
            List<Icollage> data = new List<Icollage>();
            int mainOPS = 0;

            while (mainOPS != 7485)
            {
                Console.WriteLine("Enter 1 For Add  :-");
                Console.WriteLine("Enter 2 For Remove :-");
                Console.WriteLine("Enter 3 For Update :-");
                Console.WriteLine("Enter 4 For Display :-");
                Console.WriteLine("Enter 0 For Exit  :-");

                mainOPS = Convert.ToInt32(Console.ReadLine());

                if (mainOPS == 1)
                {

                    while (exit != 7485)
                    {
                        Console.WriteLine("Enter 1 For Add Student :-");
                        Console.WriteLine("Enter 2 For Add Teacher :-");
                        Console.WriteLine("Enter 3 For Add Cleark :-");
                        Console.WriteLine("Enter 4 For Add Peon :-");
                        Console.WriteLine("Enter 0 For Exit Peon :-");

                        int ops = Convert.ToInt32(Console.ReadLine());


                        int id = 1;
                        if (data.Count() != 0)
                        {
                            id = (from d in data
                                  select d.id).Max() + 1;
                        }

                        if (ops == 1)
                        {
                            data.Add(new student(id));
                        }
                        else if (ops == 2)
                        {
                            data.Add(new Teacher(id));
                        }
                        else if (ops == 3)
                        {
                            data.Add(new Cleark(id));

                        }
                        else if (ops == 4)
                        {
                            data.Add(new Peon(id));

                        }
                        else if (ops == 0)
                        {
                            exit = 7485;
                        }

                    }

                }
                else if (mainOPS == 2)
                {
                    Console.Write("Enter Id for Delete data :-");

                    int Did = Convert.ToInt32(Console.ReadLine());

                    Icollage icollage = data.Where(d => d.id == Did).FirstOrDefault();

                    data.Remove(icollage);

                }
                else if (mainOPS == 3)
                {
                    Console.Write("Enter Id for update data :-");

                    int Uid = Convert.ToInt32(Console.ReadLine());

                    Icollage Udata = (from d in data
                                      where d.id == Uid
                                      select d).FirstOrDefault();

                    Udata.update();
                }
                else if (mainOPS == 4)
                {

                    Console.WriteLine("DATA");

                    Console.WriteLine("________________________________________________________________________________________________________");

                    foreach (var d in data)
                    {
                        d.display();
                    }

                    Console.WriteLine("________________________________________________________________________________________________________");
                }
            }
        }
    }
}
