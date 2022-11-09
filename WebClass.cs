using System.IO;
using System.Linq;
using System;

namespace WebGen
{
    class WebGenerator : Ainformations, Iinformations
    {
        string webBottom;
        string[] messages;
        string className;
        string[] courses;
        public WebGenerator(string klass, string[] messages, string[] courses)
        {
            this.className = klass;
            this.courses = courses;
            this.messages = messages;
            this.webBottom = $"\n<main>\n{Courses(this.courses)}</main>\n</body>\n</html>";
        }


        public void PrintPage()
        {
            Console.WriteLine(PrintTop());
            Console.WriteLine(PrintMessageToClass(messages, ".net"));
            Console.WriteLine(printBottom());

        }

        public void printToFil()
        {
            FileInfo fi = new FileInfo(@"webFile.html");
            FileStream fs = fi.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(PrintTop());
            sw.WriteLine(PrintMessageToClass(messages, ".net"));
            sw.WriteLine(printBottom());
            sw.Close();
            fs.Close();
        }

        protected virtual string PrintTop()
        {
            string webTop = "<!DOCTYPE html>\n<html>\n<body>";
            return webTop;
        }

        string PrintMessageToClass(string[] messages, string className)
        {
            string welcome = "";

            welcome = messages.Aggregate($"<h1>Välkomna {className.ToUpper()} HÄR!</h1>", (temp, next) =>
            temp += $"\n<p><b>Meddelande {Array.IndexOf(messages, next) + 1}:</b> {next}.</p>");


            #region Innan användning av aggregate. (FOREACH)
            //int messageCount = 0;
            //
            //foreach (string message in messages)
            //{
            //    welcome += $"\n<p><b>Meddelande {messageCount + 1}:</b> {message}.</p>";
            //}
            #endregion

            return welcome;
        }

        string printBottom()
        {
            return webBottom;
        }

        string Courses(string[] courses)
        {
            string courseList = "";

            if (courses != null)
            {
                //Fixar så den den ser fin ut
                for (int i = 0; i < courses.Length; i++)
                {
                    courses[i] = courses[i].Trim();
                }

                courseList = courses.Aggregate("", (temp, next) =>
                temp += $"<p>Kurs om {next.First().ToString().ToUpper() + next.Substring(1).ToLower().Replace("kk", "ck")}</p>\n");

                #region Innan användning av aggregate. (FOREACH)
                //foreach (string course in courses)
                //{
                //    courseList += $"<p>Kurs om {course.First().ToString().ToUpper() + course.Substring(1).ToLower().Replace("kk", "ck")}</p>\n";
                //}
                #endregion
            }

            return courseList;
        }

        public void GetMessage()
        {
            string messagesToReturn = "";
            foreach (string message in messages)
            {
                messagesToReturn += $"{message}\n";
            }
            Console.WriteLine(messagesToReturn);
        }

        public override void GetCourses()
        {
            string kurser = "";
            foreach (string course in this.courses)
            {
                kurser += $"{course.First().ToString().ToUpper() + course.Substring(1).ToLower().Replace("kk", "ck")}\n";
            }
            Console.WriteLine(kurser);
        }

        public override void GetClassName()
        {
            Console.WriteLine(this.className);
        }
    }


    #region   INHERITANCE

    class StyledWebsiteGenerator : WebGenerator
    {
        string primaryColor;
        public StyledWebsiteGenerator(string klass, string[] messages, string[] courses, string primaryColor) : base(klass, messages, courses)
        {
            this.primaryColor = primaryColor;
        }

        protected override string PrintTop()
        {
            //This will be easier to understand
            string webTop = $"<!DOCTYPE html>\n<html>\n<head>\n<style>\np {{ color: {this.primaryColor} }}\n</style>\n</head>\n<body>";
            return webTop;
        }
    }

    #endregion

    #region  INTERFACE

    interface Iinformations
    {
        void GetMessage();
    }

    #endregion

    #region  ABSTRACTION  

    abstract class Ainformations
    {
        public abstract void GetCourses();
        public abstract void GetClassName();
    }
    #endregion
}
