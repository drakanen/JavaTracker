using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JavaTracker.Core;
using System.IO;

namespace JavaTracker.Persistance
{
    public class StudentFileService : IStudentService
    {
        List<Student> students;
        string pathName;

        //Constructor
        public StudentFileService(string pathName)
        {
            this.pathName = pathName; //Path to the file of students
            try
            {
                students = LoadFile(); //Load the file of students
            }
            catch (FileNotFoundException)
            {
                File.WriteAllText(pathName, "");
                students = LoadFile();
            } 
        }

        //This method gets all of the students currently in the student list
        public List<Student> GetAllStudents()
        {
            students = LoadFile();
            return students;
        }

        //This method gets all the student information from a file
        public List<Student> LoadFile()
        {
            if (File.Exists(pathName))
            {
                StreamReader sr = File.OpenText(pathName); //Streamreader to read the file
                List<Student> student = new List<Student>(); //Holds the list of students in the file
                string line; //Holds a line in the file
                string value = ""; //The current value to be looked at
                int i = 0; //Which element of the line string to look at

                //While the file is not empty,
                //parse through it and get all of the information to fill in a student object
                //then add it to a list and return the list when completed
                while (!sr.EndOfStream)
                {
                    Student s = new Student();
                    List<int> modules = new List<int>(); //Holds the modules for each student
                    line = sr.ReadLine();
                    while (!line[i].Equals(";") && i < line.Length - 1) //While the line has not ended
                    {
                        if (line[i].Equals('%') && s.FirstName == "") //If first name is completed and not full, set it
                        {
                            s.FirstName = value; //Assign the value
                            value = ""; //Reset the string
                        }
                        else if (line[i].Equals('%') && s.LastName == "") //If last name is completed and not full, set it
                        {
                            s.LastName = value; //Assign the value
                            s.FullName = s.FirstName + " " + s.LastName;    //Also set the full name
                            value = ""; //Reset the string
                        }
                        else if (line[i].Equals('%') && s.IDNumber == 0) //If first name is completed and not full, set it
                        {
                            s.IDNumber = int.Parse(value); //Cast the string to an int and assign the value
                            value = ""; //Reset the string
                        }
                        else if (line[i].Equals('%'))  //If all the others are full, start adding the modules
                        {
                            modules.Add(int.Parse(value)); //Add the module number to an int list after casting it
                            value = ""; //Reset the string
                        }
                        else
                            value += line[i]; //Add the next letter to the string
                        ++i;
                    }
                    s.setModules(modules); //Set the student's modules completed
                    student.Add(s); //Add the student to the student list
                    s = null;
                    modules = null;
                    i = 0; //Reset the i counter
                }
                sr.Close(); //Close the file
                sr.Dispose(); //Dispose of the streamreader
                return student;
            }
            else
                throw new FileNotFoundException();

        }

        //This method saves changes to the student file
        public void SaveChanges()
        {
            string toWrite = ""; //What to write to the file
            if (students != null) //If the student list is not empty
            {
                foreach (Student stud in students) //for each student, put their info into the toWrite string
                {
                    toWrite += stud.FirstName + "%";
                    toWrite += stud.LastName + "%";
                    toWrite += stud.IDNumber + "%";
                    foreach (int mod in stud.getModules())
                    {
                        toWrite += mod.ToString() + "%"; //Add each completed module from the list
                    }
                    toWrite += ";";
                    toWrite += Environment.NewLine;
                }
             }
            File.WriteAllText(pathName, toWrite);
        }

        public void AddStudent(Student st)
        {
            students.Add(st); //Add the student object to the students list
        }

        public Student GetStudent(int id)
        {
            foreach (var student in students) //Find the student with the matching ID
            {
                if (student.IDNumber == id)
                {
                    return student; //Return the matching student object
                }
            }
            Console.WriteLine("Student not found.");
            return null; //If the student was not found, say so and return null
        }

        public void DeleteStudent(int id)
        {
            Student st = null;
            foreach (var student in students) //Search for the student with the matching ID
            {
                if (student.IDNumber == id)
                {
                    st = student; //Grab the student
                    break; //Exit the foreach loop
                }
            }
            students.Remove(st); //Remove the student from the list
        }
    }
}
