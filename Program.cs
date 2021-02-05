using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace RemoveDuplicateEmails
{
    class Program
    {

        static void Main(string[] args)
        {
            Program programObject = new Program();

            List<string> email = programObject.ReadFromCsvFile(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\")) + "emailList.csv");
            IEnumerable<string> distinctList = email.Distinct();
            Console.WriteLine(distinctList.Count());
            int count = 0;
            foreach (string s in distinctList)
            {
                Console.WriteLine(count + "--> " + s);
                count++;
            }
            Console.ReadLine();


        }
        public List<string> ReadFromCsvFile(string path)
        {

            List<string> readData = new List<string>();
            using (TextFieldParser csvParser = new TextFieldParser(path))
            {
                csvParser.CommentTokens = new string[] { "#" };
                csvParser.SetDelimiters(new string[] { "," });
                csvParser.HasFieldsEnclosedInQuotes = true;

                // Skip the row with the column names
                csvParser.ReadLine();

                while (!csvParser.EndOfData)
                {
                    // Read current line fields, pointer moves to the next line.
                    string[] fields = csvParser.ReadFields();
                    readData.Add(fields[0]);

                }
            }
            return readData;
        }
    }
}
