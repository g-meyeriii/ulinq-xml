using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LinqXML
{
    class Program
    {
        static void Main(string[] args)
        {
            //We simply apply our Student-Structure to XML;
            string studentsXML =
                @"<Students>
                    <Student>
                        <Name>Toni</Name>
                        <Age>21</Age>
                        <University>Yale</University>
                        <Year>Junior</Year>
                    </Student>
                    <Student>
                        <Name>Carla</Name>
                        <Age>17</Age>
                        <University>Yale</University>
                        <Year>Freshman</Year>
                    </Student>
                     <Student>
                        <Name>Leyla</Name>
                        <Age>19</Age>
                        <University>Beijing Tech</University>
                        <Year>Sophmore</Year>
                    </Student>
                    <Student>
                        <Name>Frank</Name>
                        <Age>25</Age>
                        <University>Yale</University>
                        <Year>Senior</Year>
                    </Student>
                  </Students>";

            XDocument studentsXdoc = new XDocument();
            studentsXdoc = XDocument.Parse(studentsXML);

            var students = from student in studentsXdoc.Descendants("Student")
                           select new 
                           {
                               Name = student.Element("Name").Value,
                               Age = student.Element("Age").Value,
                               University = student.Element("University").Value,
                               Year = student.Element("Year").Value
                           };

            foreach (var student in students)
            {

                Console.WriteLine("Student {0} with age {1} from University {2} currently in {3} year", student.Name, student.Age, student.University, student.Year);
            }

           var sortedStudents = from student in students 
                                orderby student.Age 
                                select student;
            foreach (var student in sortedStudents)
            {

                Console.WriteLine("Student {0} with age {1} from University {2} currently in {3} ", student.Name, student.Age, student.University, student.Year);
            }

            Console.ReadLine();
        }
    }
}
