using System;
using System.Collections.Generic;
using System.Linq;

namespace Q3
{
    class Program
    {
        static void Main(string[] args)
        {
            GS_Student student = new GS_Student();

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
                    int id = 1;

                    if (student.AllData.Count() != 0)
                    {
                        id = (from d in student.AllData
                              select d.id).Max() + 1;
                    }

                    student.AddData(new studentModel(id));

                }
                else if (mainOPS == 2)
                {
                    Console.Write("Enter Id for Delete data :-");
                    int Did = Convert.ToInt32(Console.ReadLine());

                    student.DeleteData(Did);
                }
                else if (mainOPS == 3)
                {
                    student.UpdateData();
                }
                else if (mainOPS == 4)
                {
                    student.DisplayData();
                }
                else if (mainOPS == 0)
                {
                    mainOPS = 7485;
                }
            }

        }
    }
}
