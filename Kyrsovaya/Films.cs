using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kyrsovaya
{
    public class Films
    {
        private string name;
        private  List<string> genre;
        private int year;
        private string description;
        private string imagePath;

        public List<string> Genre { get => genre; set => genre = value; }
        public string Name { get => name; set => name = value; }
        public int Year { get => year; set => year = value; }
        public string Description { get => description; set => description = value; }
        public string ImagePath { get => imagePath; set => imagePath = value; }
    }
}
