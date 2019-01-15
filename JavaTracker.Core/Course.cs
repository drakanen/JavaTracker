using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JavaTracker.Core
{
    public class Course
    {
        private string name; //Name of the course
        private string description; //Description of the course
        private int number; //Course number
        
        //Constructor
        public Course(string na = "", string desc = "", int num = 0)
        {
            name = na;
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
                return name;
            }
            set
            {
                name = value;
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
        //Course Name: Java 1
        //Course Descrption: The first java course
        //Course ID Number: 12345
        public override string ToString() =>
            $"Course Name: {Name}\nCourse Description: {Description}\nCourse ID Number: {Number}";
    }
}
