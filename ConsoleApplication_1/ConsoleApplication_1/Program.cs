using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication_1
{

    class Program
    {
        static void Main(string[] args)
        {
            //unchecked { int x = 99999999; x *= 100000; }

            string firstName = "", lastName = "";
            DateTime studentDate;

            string teacherName = "", courseName = "";
            int degree;

            try
            {
                GetStudentInformation(out firstName, out lastName, out studentDate);
                GetAddInformation(out teacherName, out courseName, out degree);

                PrintStudentDetails(firstName, lastName, studentDate, teacherName, courseName, degree);
            }
            catch (FormatException fEx)
            {
                Console.WriteLine("Execution Aborted. " + fEx.Message);
            }

            Console.ReadKey();
        }

        static void GetStudentInformation(out string firstName, out string lastName, out DateTime studentDate)
        {
            Console.WriteLine("Enter the student's first name: ");
//            string firstName = Console.ReadLine();
            firstName = Console.ReadLine();

            Console.WriteLine("Enter the student's last name");
//            string lastName = Console.ReadLine();
            lastName = Console.ReadLine();
            // Code to finish getting the rest of the student data

            Console.WriteLine("Enter the student's date");
//            DateTime studentDate;
            studentDate = ReadDateTime(3);

        }

        static void GetAddInformation(out string teacherName, out string courseName, out int degree)
        {
            Console.WriteLine("Enter the teacher's name: ");
            teacherName = Console.ReadLine();

            Console.WriteLine("Enter the cource name");
            courseName = Console.ReadLine();

            Console.WriteLine("Enter the degree");
            degree = ReadInt(2);

        }


        static void PrintStudentDetails(string first, string last, DateTime birthday, string teacher, string course, int degree)
        {
            Console.WriteLine("{0} {1} was born on: {2}", first, last, birthday.ToString());
            Console.WriteLine(" Teacher: {0}\n Course: {1}\n Degree: {2}", teacher, course, degree.ToString());
        }


        static DateTime ReadDateTime(int maxAdditAttempts = 0)
        {
            int attempt = 1;
            bool res = false;
            DateTime retDT;

            while (((res = DateTime.TryParse(Console.ReadLine(), out retDT)) == false) && (attempt <= maxAdditAttempts))
            {
                Console.WriteLine("The date you've entered has invalid format. Try again. {0} attempts left.", maxAdditAttempts - attempt + 1);
                attempt += 1;
            }
            if (res == false)
            {
                throw new FormatException("Incorrect date format");
            }

            return retDT;
        }

        static int ReadInt(int maxAdditAttempts = 0)
        {
            int attempt = 1;
            bool res = false;
            int retInt;

            while (((res = int.TryParse(Console.ReadLine(), out retInt)) == false) && (attempt <= maxAdditAttempts))
            {
                Console.WriteLine("The number you've entered has invalid format. Try again. {0} attempts left.", maxAdditAttempts - attempt + 1);
                attempt += 1;
            }
            if (res == false)
            {
                throw new FormatException("Incorrect number format");
            }

            return retInt;
        }
        
    }
}
