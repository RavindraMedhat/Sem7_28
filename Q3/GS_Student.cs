using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace Q3
{
    class GS_Student : GenericInterface<studentModel>
    {
        public GS_Student()
        {
            AllData = new List<studentModel>();
        }
        public List<studentModel> AllData { get; set; }

        //public static List<student> AllData = new List<student>();

        public studentModel GetData(int ID)
        {
            return (from d in AllData
                    where d.id == ID
                    select d).FirstOrDefault();
        }

        public void AddData(studentModel Data)
        {
            AllData.Add(Data);
        }


        public void DeleteData(int id)
        {

            studentModel Ddata = AllData.Where(d => d.id == id).FirstOrDefault();
            AllData.Remove(Ddata);
        }

        public void UpdateData()
        {
            Console.Write("Enter Id for update data :-");

            int Uid = Convert.ToInt32(Console.ReadLine());

            studentModel Udata = (from d in AllData
                              where d.id == Uid
                              select d).FirstOrDefault();

            Console.Write("Enter New name :-");
            Udata.name = Console.ReadLine();
            Console.Write("Enter New DOB :-");
            Udata.dob = Console.ReadLine();
            Console.Write("Enter Semster :-");
            Udata.Sem = Convert.ToInt32(Console.ReadLine());
        }

        public void DisplayData()
        {
            Console.WriteLine("DATA :-");

            Console.WriteLine("________________________________________________________________________________________________________");

            foreach (var d in AllData)
            {
                d.display();
            }

            Console.WriteLine("________________________________________________________________________________________________________");

        }
    }
}
