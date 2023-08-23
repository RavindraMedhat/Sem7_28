using System;
using System.Collections.Generic;
using System.Text;

namespace Q2
{
    interface Icollage
    {
        public int id { get; set; }
        public string name { get; set; }
        public void update();
        public void display();

    }
}
