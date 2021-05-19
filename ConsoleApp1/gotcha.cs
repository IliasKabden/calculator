using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class gotcha
    {
        public double result;

        public void tricks(string NameFile)
        {
            try
            {
                StreamReader readr = new StreamReader(NameFile);
                List<string> Opiration = new List<string>();


                while (readr.EndOfStream != true)
                {
                    string input = readr.ReadLine();
                    Opiration.Add(input);
                }

                Opiration.ForEach(delegate (String name)
                {
                    Console.WriteLine(name);
                    Console.WriteLine();
                });

                readr.Close();

                string LastTrim = Opiration.Last().Trim();


                if (LastTrim.Contains("apply"))
                {
                    LastTrim = LastTrim.Replace("apply", "");
                    result = Convert.ToInt32(LastTrim);

                    foreach (string item in Opiration)
                    {
                        var results = Regex.Replace(item, @"[0-9\-]", string.Empty).Trim();
                        string compare = results.ToString();
                        switch (compare)
                        {
                            case "add":
                                int a = ReplaceLast("add", item);
                                result = result + a;
                                break;

                            case "subtract":
                                a = ReplaceLast("subtract", item);
                                result = result - a;
                                break;

                            case "multiply":
                                a = ReplaceLast("multiply", item);
                                result = result * a;
                                break;

                            case "divide":
                                a = ReplaceLast("divide", item);
                                if (a != 0)
                                    result = result / a;
                                else
                                    Console.WriteLine("do not divide by 0");
                                break;
                        }
                    }
                }
                Console.WriteLine("[Output to screen] \n{0}", result);
            }
            catch
            {
                Console.WriteLine("Not a correct instruction");
            }
        }

        public int ReplaceLast(string Find, string Source)
        {
            int result = Convert.ToInt32(Source.Replace(Find, "").Trim());
            return result;
        }
    }
}
