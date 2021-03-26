using System;
using System.IO;

namespace DateCheck
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.Error.WriteLine("Args number is too small!");
                Environment.Exit(1);
            }

            string[] content = File.ReadAllLines(args[1]);

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
                string s = content[i].Replace("***", "")
                    .Replace("**_", "")
                    .Replace("_**", "");

                if (s.StartsWith("Next review due") || s.StartsWith("页面上一次复查"))
                {
                    nextReview = s
                        .Replace("：", "")
                        .Replace(":", "")
                        .Replace("Next review due", "")
                        .Replace("页面上一次复查", "")
                        .Trim();
                    continue;
                }

                if (s.StartsWith("Page last reviewed") || s.StartsWith("下一次复查"))
                {
                    pageLastDue = s
                        .Replace("：", "")
                        .Replace(":", "")
                        .Replace("Page last reviewed:", "")
                        .Replace("", "")
                        .Replace("下一次复查", "")
                        .Trim();
                    continue;
                }

                if (content[i].StartsWith("***") || content[i].StartsWith("**_"))
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
