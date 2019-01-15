using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JavaTracker.Core
{
    public class Module
    {
        private string name; //Name of the module
        private string description; //Descrption of the module
        private int number; //Module number

        //Constructor
        public Module(string nam = "", string desc = "", int num = 0)
        {
            name = nam;
            description = desc;
            number = num;
        }

        //Property for name
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        //Property for description
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }

        //Property for number
        public int Number
        {
            get
            {
                return number;
            }
            set
            {
                number = value;
            }
        }
        
        //Overriden ToString method that prints as
        //Module Name: A1:05
        //Module Description: Write a program that displays the follow: "Hello World!"
        //Module ID Number: 12345
        public override string ToString() =>
            $"Module Name: {Name}\nModule Description: {Description}\nModule ID Number: {Number}";
    }
}
