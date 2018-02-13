using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class ZooShop:Owner
    {
        private string name;
        public ZooShop(string name) : base()
        {
            this.name = name;
        }
        public override string ToString()
        {
            return "Зоо-магазин \"" + name + "\"";
        }
    }
}
