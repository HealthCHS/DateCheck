using System;
using System.IO;

namespace DateCheck
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "D:\\a.md";
            string[] content = File.ReadAllLines(path);

            /*
             * ***Page last reviewed: 4 February 2021  
             * Next review due: 4 February 2024  
             * Source link:  
             * Source license: ***
             */

            string nextReview = "";
            string pageLastDue = "";

            for (int i = content.Length - 1; i > 0; --i)
            {
                string s = content[i].Replace("***", "");

                if (s.StartsWith("Next review due:"))
                {
                    nextReview = s.Replace("Next review due:", "").Trim();
                    continue;
                }

                if (s.StartsWith("Page last reviewed:"))
                {
                    pageLastDue = s.Replace("Page last reviewed:", "").Trim();
                    continue;
                }

                if (content[i].StartsWith("***"))
                {
                    break;
                }
            }

            var nr = DateTime.Parse(nextReview);
            var ld = DateTime.Parse(pageLastDue);
            Console.WriteLine(nr);
            Console.WriteLine(ld);

        }

    }
}
