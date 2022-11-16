using System;
using System.Runtime;
using System.Text;
using System.Globalization;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace BatchRename
{
    internal class Program
    {
        static string replacespecial(string str)
        {
            string a;
            str = str.Replace("-", " ");
            str = str.Replace("_", " ");
            return str;

        }
        static string ToTitleCase(string title)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(title.ToLower());
        }
        static string OneSpace(string str)
        {
            Regex regex = new Regex(@"[ ]{2,}", RegexOptions.None);
            str = regex.Replace(str, @" ");
            return str;
        }
        static string addDate(string str)
        {
            var today = DateTime.Now;
            var day = today.Day;
            var month = today.Month;
            var year = today.Year;
            string temp = Convert.ToString(day) + Convert.ToString(month) + Convert.ToString(year);
            str =  temp + " " + str;
            return str;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("");
            var filenames = new List<string>() 
            {
                "Ernesto Lowe.pdf",
                "Calvin-hopkins.pdf",
                "Brandon    Mullins.pdf",
                "Jon Wood.pdf",
                "marianne-owers.pdf",
                "Luis--Chavez.pdf",
                "Cecil Logan.pdf",
                "Saul_kennedy.pdf",
                "Raul___Thompson___CV.pdf",
                "Juana--Wagner.pdf",
                "sophie_chapman.pdf",
                "Donna___Mason.pdf",
                "garry-roy.pdf",
                "Drew sparks.pdf",
                "Jeffrey norris.pdf",
                "Dwayne_townsend.pdf",
                "Violet-Garza.pdf",
                "Oscar----Ellis.pdf",
                "jeremiah wwest.pdf",
                "emma    Padilla.pdf",
            };

            string temp = null;
            for (int i = 0; i < 18; i++)
            {
                Console.WriteLine(filenames[i]);
                temp = replacespecial(filenames[i]);
                ToTitleCase(temp);
                string temp1 = OneSpace(temp);
                string temp2 = addDate(temp1);

                Console.WriteLine("Changed to : ");
                Console.WriteLine(temp2);

            }
        }
    }
}