using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace laboration_4
{
    internal class Person
    {
        public string Name { get; private set; }
        public DateTime Birthday;
        public Gender Gender;
        public Hair Hair;
        public string EyeColor;

        public Person(string name, DateTime birthday, Gender gender, Hair hair, string eyescolor)
        {
            Name = name;
            Hair = hair;
            Gender = gender;
            Birthday = birthday;
            EyeColor = eyescolor;
        }

        public string ToString()
        {
            return $"Name: {Name}" +
                 $"\nBirthday: {Birthday:yyyy/MM/dd}" +
                 $"\nSex: {Gender}" +
                 $"\nHair: {Hair.color} {Hair.length} cm" +
                 $"\nEyesColor: {EyeColor}";
        }
    }
}
