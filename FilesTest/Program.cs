using System;
using System.IO;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace FilesTest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> prod1 = new List<Product>();
            int i = 0;
            try
            {
                Directory.CreateDirectory(@"c:\code\docs\out");
                string sourcePath = @"C:\code\docs\arq1.txt";
                string path = @"c:\code\docs\out\";
                //FileStream fs = new FileStream(path + "summary.csv", FileMode.OpenOrCreate);
                //StreamReader sr = new StreamReader(fs);
                //StreamWriter sw = new StreamWriter(fs);

                string[] lines = File.ReadAllLines(sourcePath);

                using (StreamWriter sw = File.AppendText(path + "summary.csv"))
                {
                    foreach (string eachline in lines)
                    {
                        string[] linha = eachline.Split(',');

                        double price = double.Parse(linha[1], CultureInfo.InvariantCulture);
                        int quantity = int.Parse(linha[2]);

                        prod1.Add(new Product(linha[0], price, quantity));                        

                        Console.WriteLine(eachline);
                        sw.WriteLine(prod1[i].name+ ", " + prod1[i].Total().ToString("F2"));
                        i++;
                    }
                }

                using (StreamReader sr = File.OpenText(path + "summary.csv"))
                {
                    Console.WriteLine();
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        Console.WriteLine(line);
                    }
                }
            }
            catch (IOException erro)
            {
                Console.WriteLine("Error: " + erro);
            }


            
        }
    }
}