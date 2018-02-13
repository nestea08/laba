using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class Human:Owner
    {
        private string name;
        private string surname;
        public Human(string name,string surname) : base()
        {
            this.name = name;
            this.surname = surname;
        }
        public override string ToString()
        {
            return name + surname;
        }
    }
}
