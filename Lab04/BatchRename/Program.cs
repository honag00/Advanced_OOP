using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

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

        public ReplaceRule(List<string> Needles_1, string Replacement_1)
        {
            Needles = Needles_1;
            Replacement = Replacement_1;
        }

        public string Rename(string Original)
        {
            string result = Original;

            foreach (string Needle in Needles)
            {
                result = result.Replace(Needle, Replacement);
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
            string result = $"{Name()} {Prefix}";
            return result;
        }
    }

    class UppercaseRule : IRenameRule
    {
        public string Name() => "UppercaseRule";

        public string Rename(string Original)
        {
            char FirstLetter = char.ToUpper(Original[0]);
            string Rename = Original.Substring(1, Original.Length - 1);
            string result = $"{FirstLetter}{Rename}";

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
            string HayStack = "Michael      jack-forsel google.pdf";

            var Needles_1 = new List<string> {"google"};
            string Replacement_1 = "facebook";
            IRenameRule Rule1 = new ReplaceRule(Needles_1, Replacement_1);

            IRenameRule Rule2 = new OneSpaceRule();

            IRenameRule Rule4 = new UppercaseRule();

            string Prefix_1 = "CV ";
            IRenameRule Rule3 = new PrefixRule(Prefix_1);

            var Rules = new List<IRenameRule>
            { 
                Rule1, Rule2, Rule3, Rule4 
            };

            string result = HayStack;
            foreach(var Rule in Rules)
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