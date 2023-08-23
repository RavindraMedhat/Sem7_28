using System;
using System.Collections.Generic;
using System.Text;

namespace Q3
{
    interface GenericInterface<T> where T : class
    {
        public List<T> AllData { get; set; }
        public T GetData(int ID);
        //public List<T> GetAllData();
        public void AddData(T Data);
        public void DeleteData(int id);
        public void UpdateData();
        public void DisplayData();


    }
}
