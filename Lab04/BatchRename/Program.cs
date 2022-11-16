using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using static System.Net.Mime.MediaTypeNames;
using System.Windows;
using System.IO;
using static System.Net.WebRequestMethods;

namespace BatchRename
{
    interface IRenameRule
    {
        string Rename(string Original);
        string Name();
    }

    class ReplaceRule : IRenameRule
    {
        private List<string> Needles;
        private string Replacement;
        private string Replacement1;

        public ReplaceRule(List<string> Needles_1, string Replacement_1, string Replacement_2)
        {
            Needles = Needles_1;
            Replacement = Replacement_1;
            Replacement1 = Replacement_2;
        }

        public string Rename(string Original)
        {
            string result = Original;

            foreach (string Needle in Needles)
            {
                if (Needle == ".pdf")
                {
                    result = result.Replace(Needle, Replacement1);
                }
                else
                {
                    result = result.Replace(Needle, Replacement);
                }
            };

            return result;
        }

        public string Name() => "Replace";

        public override string ToString()
        {
            const string Separator = ", ";
            var builder = new StringBuilder();
            for (int i = 0; i < Needles.Count; i++)
            {
                var Needle_1 = Needles[i];
                builder.Append(Needle_1);

                if (i != Needles.Count - 1)
                {
                    builder.Append(Separator);
                }    
            };
            string NeedleString = builder.ToString();
            string result = $"{Name()} [{NeedleString}] {Replacement}";
            return result;
        }
    }

    class OneSpaceRule : IRenameRule
    {
        public string Name() => "OneSpace";

        public string Rename(string Original)
        {
            const char space = ' ';
            string result = Original;
            var builder = new StringBuilder();
            for (var i = 0; i < Original.Length; i++)
            { 
                char c = Original[i];
                if (c != space)
                {
                    builder.Append(c);
                }
                else
                {
                    if (i > 0)
                    {
                        if (Original[i - 1] != space)
                        {
                            builder.Append(c);
                        }
                    }
                    else
                    {
                        builder.Append(c);
                    }
                }
            }

            result = builder.ToString();
            return result;
        }

        public override string ToString()
        {
            string result = $"{Name()}";
            return result;
        }
    }

    class PrefixRule : IRenameRule
    {
        private string Prefix = "";
        private string Prefix0 = "";

        public PrefixRule(string Prefix_1)
        {
            Prefix = Prefix_1;
        }

        public string Name() => "Prefix";

        public string Rename(string Original)
        {
            string result = $"{Prefix}{Original}";
            return result;
        }

        public override string ToString()
        {
            string result = $"{Name()} {Prefix} {Prefix0}";
            return result;
        }
    }

    class UppercaseRule : IRenameRule
    {
        public string Name() => "UppercaseRule";

        public string Rename(string Original)
        {
            string result = Original;

            for (int i = 0; i < Original.Length; i++)
            {
                char[] Temp = Original.ToCharArray();
                for (int j = 0; j < Temp.Length; j++)
                {
                    if (j == 0 || Temp[j - 1] == ' ')
                    {
                        Temp[j] = Char.ToUpper(Temp[j]);
                    }
                }
                result = new string(Temp);
            }
            return result;
        }

        public override string ToString()
        {
            string result = $"{Name()}";
            return result;
        }
    } 

    class Program
    {
        static void Main(string[] args)
        {
            string[] list =
            {
                "Ernesto Lowe google.pdf",
                "Calvin-hopkins.pdf",
                "Brandon    Mullins.pdf",
                "Jon Wood__.pdf",
                "marianne-owers   google.pdf",
                "Luis--Chavez.pdf",
                "Cecil Logan.pdf",
                "Saul_kennedy.pdf",
                "Raul___Thompson___google.pdf",
                "Juana--Wagner.pdf",
                "sophie_chapman---google.pdf",
                "Donna___Mason google.pdf",
                "garry-roy.pdf",
                "Drew sparks--google.pdf",
                "Jeffrey norris.pdf",
                "Dwayne_townsend.pdf",
                "Violet-Garza google.pdf",
                "Oscar----Ellis.pdf",
                "jeremiah wwest.pdf",
                "emma    Padilla.pdf",
                "Michael      jack-forsel google.pdf"
            };

            for (int i = 0; i < list.Length; i++)
            {
                string HayStack = list[i];

                var Needles_1 = new List<string> { "-", "_", ".pdf", "google" };
                string Replacement_1 = " ";
                string Replacement_2 = " Facebook.pdf";
                IRenameRule Rule1 = new ReplaceRule(Needles_1, Replacement_1, Replacement_2);

                IRenameRule Rule2 = new OneSpaceRule();

                IRenameRule Rule3 = new UppercaseRule();

                string Prefix_1 = "CV ";
                IRenameRule Rule4 = new PrefixRule(Prefix_1);

                var Rules = new List<IRenameRule>
                {
                    Rule1, Rule2, Rule3, Rule4
                };

                string result = HayStack;
                foreach (var Rule in Rules)
                {
                    result = Rule.Rename(result);
                }

                Console.WriteLine(result);
                string RuleFilename = "BatchRename.txt";
                var write = new StreamWriter(RuleFilename);
                foreach (var Rule in Rules)
                {
                    write.WriteLine(Rule.ToString());
                }
                write.Close();
            }
        }
    }
}