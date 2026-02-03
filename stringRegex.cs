using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

class StringTest
{
    static void Main()
    {
        Console.WriteLine("Hello, world!");
        Console.WriteLine();

        string s1 = "abcd";
        string s2 = "ABCD";
        string s3 = @"Liberty Associates, Inc.
provides custom .NET development,
on-site Training and Consulting";
        int result = 0;
        result = s1.CompareTo(s2);
        Console.WriteLine("{0}", result);
        result = string.Compare(s1, s2.ToLower());
        Console.WriteLine("{0}", result);
        result = string.Compare(s1, s2, true);
        Console.WriteLine("{0}", result);
        string s4 = string.Concat(s1, s2);
        Console.WriteLine(s4);
        string s5 = s1 + " " + s2;
        Console.WriteLine(s5);
        string s6 = string.Copy(s4);
        Console.WriteLine(s6);
        string s7 = s3;
        Console.WriteLine(s7);
        bool rez = true;
        rez = s5.Equals(s4);
        if (rez)
            Console.WriteLine("da");
        else
            Console.WriteLine("nu");
        Console.WriteLine("{0}", s3.Length);
        Console.WriteLine("s3:{0}\nEnds with Training?: {1}\n", s3, s3.EndsWith("Training"));
        Console.WriteLine("Ends with Consulting?: {0}", s3.EndsWith("Consulting"));
        Console.WriteLine("\nThe first occurrence of Training ");
        Console.WriteLine("in s3 is {0}\n", s3.IndexOf("Training"));
        string s10 = s3.Insert(10, "excellent ");
        Console.WriteLine("s10: {0}\n", s10);
        string s11 = s3.Insert(s3.IndexOf("Training"), "excellent ");
        Console.WriteLine("s11: {0}\n", s11);
        Console.WriteLine();

        string s12 = "One Two Three Four";
        int ix;
        ix = s12.LastIndexOf(" ");
        string s13 = s12.Substring(ix + 1);
        s12 = s12.Substring(0, ix);
        ix = s12.LastIndexOf(" ");
        string s14 = s12.Substring(ix + 1);
        s12 = s12.Substring(0, ix);
        ix = s12.LastIndexOf(" ");
        string s15 = s12.Substring(ix + 1);
        s12 = s12.Substring(0, ix);
        ix = s12.LastIndexOf(" ");
        string s16 = s12.Substring(ix + 1);
        Console.WriteLine(s13);
        Console.WriteLine(s14);
        Console.WriteLine(s15);
        Console.WriteLine(s16);
        Console.WriteLine();

        string s17 = "One,Two,Three Liberty Associates, Inc.";
        const char Space = ' ';
        const char Comma = ',';
        char[] delimiters = new char[] { Space, Comma };
        string output = "";
        int crt = 1;
        foreach (string substring in s17.Split(delimiters))
        {
            output += crt++;
            output += " * ";
            output += substring;
            output += "\n";
        }
        Console.WriteLine(output);
        Console.WriteLine();

        StringBuilder sb = new StringBuilder();
        crt = 1;
        foreach (string substring in s17.Split(delimiters))
        {
            sb.AppendFormat("{0}: {1}\n", crt++, substring);
        }
        Console.WriteLine(sb);
        Console.WriteLine();

        Console.WriteLine("REGEX");
        Regex regex = new Regex(" |, |,");
        StringBuilder stringBuilder = new StringBuilder();
        int id = 1;
        foreach (string substring in regex.Split(s17))
        {
            stringBuilder.AppendFormat("{0}$ {1}\n", id++, substring);
        }
        Console.WriteLine(stringBuilder);
        Console.WriteLine("Same shit different implementation :)");
        stringBuilder = new StringBuilder();
        id = 1;
        foreach (string substring in Regex.Split(s17, " |, |,"))
        {
            stringBuilder.AppendFormat("{0}$ {1}\n", id++, substring);
        }
        Console.WriteLine(stringBuilder);
        Console.WriteLine();

        string s18 = "This is a test string";
        regex = new Regex(@"(\S+)\s");
        MatchCollection matches = regex.Matches(s18);
        foreach (Match match in matches)
        {
            Console.WriteLine("theMatch.Length: {0}", match.Length);
            if (match.Length != 0)
            {
                Console.WriteLine("theMatch: {0}", match.ToString());
            }
        }
        Console.WriteLine();

        string s19 = "04:03:27 127.0.0.0 LibertyAssociates.com";
        regex = new Regex(@"(?<time>(\d|\:)+)\s" + @"(?<ip>(\d|\.)+)\s" + @"(?<site>\S+)");
        //grupul time = una sau mai multe digits or colons urmate de space
        //grupul ip = unu sau mai multe digits sau dots urmate de spatiu
        //grupul site = una sau mai multe characters
        matches = regex.Matches(s19);
        foreach(Match match in matches)
        {
            if (match.Length != 0)
            {
                Console.WriteLine("\nmatch: {0}", match.ToString());
                Console.WriteLine("time: {0}", match.Groups["time"]);
                Console.WriteLine("ip: {0}", match.Groups["ip"]);
                Console.WriteLine("site: {0}", match.Groups["site"]);
            }
        }
        Console.WriteLine();
        string s20 = "04:03:27 Jesse 0.0.0.127 Liberty ";
        regex = new Regex(@"(?<time>(\d|\:)+)\s" + @"(?<company>\S+)\s" + @"(?<ip>(\d|\.)+)\s" + @"(?<company>\S+)\s");
        matches = regex.Matches(s20);
        foreach(Match match in matches)
        {
            if (match.Length != 0)
            {
                Console.WriteLine("\nmatch: {0}", match.ToString());
                Console.WriteLine("time: {0}", match.Groups["time"]);
                Console.WriteLine("ip: {0}", match.Groups["ip"]);
                Console.WriteLine("company: {0}", match.Groups["company"]);
                foreach(Capture cap in match.Groups["company"].Captures)
                    Console.WriteLine("cap: {0}", cap.ToString());
            }
        }        
    }
}
