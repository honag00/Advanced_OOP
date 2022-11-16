using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BatchRename
{
    class Program
    {
        static List<string> Rename_1(List<string> file)
        {
            for (int i = 0; i < file.Count; i++)
            {
                StringBuilder temp = new StringBuilder(file[i]);
                temp.Replace("-", " ");
                temp.Replace("_", " ");
                string newfile = temp.ToString();
                file[i] = newfile;
            }
            return file;
        }

        static List<string> UpperCase(List<string> file)
        {
            for (int i = 0; i < file.Count; i++)
            {
                char[] Temp = file[i].ToCharArray();
                for (int j = 0; j < Temp.Length; j++)
                {
                    if (j == 0 || Temp[j - 1] == ' ')
                    {
                        Temp[j] = Char.ToUpper(Temp[j]);
                    }
                }
                file[i] = new string(Temp);
            }

            return file;
        }

        static void Print(List<string> file)
        {
            foreach (string line in file)
            {
                Console.WriteLine(line);
            }
        }

        interface IRenameRule
        {
            List<string> Rename(List<string> file, string Word);
        };

        class ReplaceRule : IRenameRule
        {
            public List<string> Rename(List<string> file, string Word)
            {
                string Temp;
                string Facebook;
                string Google;

                for (int i = 0; i < file.Count; i++)
                {
                    string[] tokens = file[i].Split(new string[] { "." }, StringSplitOptions.None);
                    string LeftFile = tokens[0];
                    string RightLife = tokens[1];

                    string[] vs = Word.Split(new string[] { " => " }, StringSplitOptions.None);
                    string repgg = vs[0];
                    Facebook = vs[1];

                    string[] vs1 = repgg.Split(new string[] {" "}, StringSplitOptions.None);
                    Google = vs1[1];

                    StringBuilder builder = new StringBuilder(LeftFile + " " + Google + "." + RightLife);
                    file[i] = builder.ToString();
                    Temp = file[i].Replace(Google, Facebook);
                    file[i] = Temp;
                }

                return file;
            }
        }

        class OneSpaceRule : IRenameRule
        {
            public List<string> Rename(List<string> file, string Word)
            {
                Rename_1(file);
                for (int i = 0; i < file.Count; i++)
                {
                    string Temp = file[i];
                    for (int j = 0; j < Temp.Length; j++)
                    {
                        if (Temp[j] == ' ' && Temp[j - 1] == ' ')
                        {
                            Temp = Temp.Remove(j, 1);
                            j--;
                        }
                    }
                    file[i] = Temp;
                }

                return file;
            }
        }

        class PrefixRule : IRenameRule
        {
            public List<string> Rename(List<string> file, string Word)
            {
                UpperCase(file);

                for (int i = 0; i < file.Count; i++)
                {
                    string[] tokens = Word.Split(new string[] {" "}, StringSplitOptions.None);
                    string right = tokens[1];
                    StringBuilder builder = new StringBuilder(right + " " + file[i]);
                    file[i] = builder.ToString();
                }

                return file;
            }
        }

        static List<string> Command(string filename, List<string> file)
        {
            var Lines = File.ReadAllLines(filename);

            List<string> temp = new List<string>();
            foreach (string line in Lines)
            {
                if (line.Contains("Replace"))
                {
                    IRenameRule replace = new ReplaceRule();
                    replace.Rename(file, line);
                    temp = file;
                }
                else if (line.Contains("Space"))
                {
                    IRenameRule onespace = new OneSpaceRule();
                    onespace.Rename(file, line);
                    temp = file;
                }
                else
                {
                    IRenameRule add = new PrefixRule();
                    add.Rename(file, line);
                    temp = file;
                }
            }

            return temp;
        }

        static void Main(string[] args)
        {
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
                "Raul___Thompson___.pdf",
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

            Command("Data.txt", filenames);
            Print(filenames);
        }
    }
}