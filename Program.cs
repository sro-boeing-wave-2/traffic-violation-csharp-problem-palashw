using System;
using System.IO;
using System.Text;

namespace TrafficViolations
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] fc = ReadFile(@"D:\workspace\CSharp\Assignments\traffic-violation-csharp-problem-palashw\data\Traffic_Violations.csv");
            Console.WriteLine(fc);
            Console.ReadLine();
            
        }

        public static int _bufferSize = 163849999;

        // returns a char array of all the contents in the file.
        public static char[] ReadFile(string filename)
        {
            StringBuilder stringBuilder = new StringBuilder();
            FileStream fileStream = new FileStream(filename, FileMode.Open, FileAccess.Read);

            using (StreamReader streamReader = new StreamReader(fileStream))
            {
                char[] fileContents = new char[_bufferSize];
                int charsRead = streamReader.Read(fileContents, 0, _bufferSize);
                
                if (charsRead == 0)
                    throw new Exception("File is 0 bytes");

                while (charsRead > 0)
                {
                    stringBuilder.Append(fileContents);
                    charsRead = streamReader.Read(fileContents, 0, _bufferSize);
                }

                return fileContents;
            }
        }
    }
}
