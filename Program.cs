using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Words
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to word unscrambler! How do you want to input words to unscramble? ");
            bool optionM;
            bool optionF;
            bool startOver = false;
            
            do
            {
                Console.Write("Press M for manual or F for reading from file: ");
                string inputType = Console.ReadLine();
                optionM = inputType.Equals("m", StringComparison.OrdinalIgnoreCase);
                optionF = inputType.Equals("f", StringComparison.OrdinalIgnoreCase);
                if (optionM)
                {
                    Console.Write("Please enter comma separated words (or single word):  ");
                    ExecuteManualInputScenario();
                }else if(optionF)
                {
                    Console.Write("Please input file path: ");
                    var textPath = Console.ReadLine() ?? string.Empty;
                    ExecuteFileInputScenario(textPath);
                }else{
                    Console.WriteLine();
                    Console.WriteLine("Incorrect selection");
                }
                string startOverDecision = string.Empty;
                do
                {
                    Console.WriteLine("Do you want to start over? Y/N");
                    startOverDecision = Console.ReadLine();
                    startOver = startOverDecision.Equals("Y",StringComparison.OrdinalIgnoreCase);
                } while (!startOver && !startOverDecision.Equals("N",StringComparison.OrdinalIgnoreCase));
            }while(startOver);
        }

        private static void ExecuteFileInputScenario(string path)
        {
            List<string> words = new List<string>();
            FileReader.ReadFromFile(path, words);
            foreach (string item in words)
            {
                Console.WriteLine(item);
            }
            
        }

        private static void ExecuteManualInputScenario()
        {
            throw new NotImplementedException();
        }
    }
}
