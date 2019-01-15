using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JavaTracker.Core
{
    public class Student
    {
        private string firstName; //Student's first name
        private string lastName;  //Student's last name
        private string fullName;  //Student's full name
        private string modules;   //Modules in a string format
        private int idNumber;     //Student's ID number
        private List<int> completedModuleIds = new List<int>();

        //Constructor
        public Student(string first = "", string last = "", int id = 0)
        {
            firstName = first;
            lastName = last;
            idNumber = id;
            fullName = first + " " + last;
        }

        //Property for firstName
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }

        //Property for lastName
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }

        //Property for fullName
        public string FullName
        {
            get
            {
                return fullName;
            }
            set
            {
                fullName = FirstName + " " + LastName;
            }
        }

        //Property for idNumber
        public int IDNumber
        {
            get
            {
                return idNumber;
            }
            set
            {
                idNumber = value;
            }
        }
        
        //Property for modules
        public string Modules
        {
            get
            {
                modules = getModulesAsString();
                return modules;
            }
            set
            {
                modules = value;
            }
        }

        //Returns the list of modules
        public List<int> getModules()
        {
            return completedModuleIds;
        }

        //Add a module to the list
        public void addModule(int mod)
        {
            completedModuleIds.Add(mod);
        }

        //Remove a module from the list
        public void removeModule(int mod)
        {
            completedModuleIds.Remove(mod);
        }

        //Returns the list of modules as a string
        public string getModulesAsString()
        {
            string modules = "";
            if (completedModuleIds.Count > 0)
            {
                foreach (int mod in completedModuleIds)
                {
                    modules += mod.ToString();
                    modules += ", ";
                }
                modules = modules.Remove(modules.Length - 2);
            }
            return modules;
        }

        //Set the list of modules
        public void setModules(List<int> li)
        {
            completedModuleIds = li;
        }

        //Overriden ToString method that prints as
        //Student Name: John Dayne
        //Student ID Number: 12345
        //Modules: 1, 2, 3
        public override string ToString()
        {
            string a = "";
            if (completedModuleIds.Count > 0)
            {
                a = getModulesAsString();

                return $"Student Name: {FullName}\nStudent ID Number: {IDNumber}\nModules: {a}\n";
            }
           else
                return $"Student Name: {FullName}\nStudent ID Number: {IDNumber}\nNo modules\n";
        }
    }
}