using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Words.Data;

namespace Words
{
    class Program
    {
        private static readonly FileReader _fileReader = new FileReader();
        private static readonly WordMatcher _wordMatcher = new WordMatcher();

        static void Main(string[] args)
        {
            Console.WriteLine(Constants.Greeting);
            bool optionM;
            bool optionF;
            bool startOver;
            

            do
            {
                Console.Write(Constants.ChooseInputOption);
                string inputType = Console.ReadLine();
                optionM = inputType.Equals(Constants.ManualInputOption, StringComparison.OrdinalIgnoreCase);
                optionF = inputType.Equals(Constants.FileInputOption, StringComparison.OrdinalIgnoreCase);
                if (optionM)
                {
                    Console.Write(Constants.ManualInputRequest);
                    ExecuteManualInputScenario();
                }else if(optionF)
                {
                    Console.Write(Constants.FilePathRequest);
                    var textPath = Console.ReadLine() ?? string.Empty;
                    ExecuteFileInputScenario(textPath);
                }else{
                    Console.WriteLine();
                    Console.WriteLine(Constants.IncorrectSelection);
                }
                string startOverDecision = string.Empty;
                do
                {
                    Console.WriteLine(Constants.AskIfStartOver);
                    startOverDecision = Console.ReadLine();
                    startOver = startOverDecision.Equals(Constants.YesUserInput,StringComparison.OrdinalIgnoreCase);
                
                } while (!startOver && !startOverDecision.Equals(Constants.NoUserInput,StringComparison.OrdinalIgnoreCase));
            }while(startOver);
        }

        private static void ExecuteFileInputScenario(string path)
        {
            List<string> dictionary = _fileReader.ReadFromFile(Constants.DictionaryPath);
            List<string> words = _fileReader.ReadFromFile(path);

            List<MatchedWord> matches = _wordMatcher.Matches(words, dictionary);
            DisplayMatches(matches);
        }

        private static void ExecuteManualInputScenario()
        {
            List<string> dictionary = _fileReader.ReadFromFile(Constants.DictionaryPath);
            string[] words = Console.ReadLine().Split(",");
            List<MatchedWord> matches = _wordMatcher.Matches(words, dictionary);
            DisplayMatches(matches);
        }

        private static void DisplayMatches(List<MatchedWord> matches)
        {
            if (matches.Any())
            {
                foreach (var matchedp in matches)
                {
                    Console.WriteLine($"{Constants.ListMatchesFound} {matchedp.UnscrambledWord.Trim('\r')} : {matchedp.Word.Trim('\r')}");
                }
            }
            else
            {
                Console.WriteLine(Constants.NoMatches);
            }
        }
    }
}
