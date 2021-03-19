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
            bool startOver;           

            do
            {
                Console.Write(Constants.ChooseInputOption);
                string inputType = Console.ReadLine();
                switch (inputType.ToLower())
                {
                    case Constants.ManualInputOption:
                        Console.Write(Constants.ManualInputRequest);
                        ExecuteManualInputScenario();
                        break;
                    case Constants.FileInputOption:
                        Console.Write(Constants.FilePathRequest);
                        var textPath = Console.ReadLine() ?? string.Empty;
                        ExecuteFileInputScenario(textPath);
                    default:
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
        
        private static bool GetStartOverDecision()
        {
            string decision = AskAndGetDecisionUntilCorrect();
            switch (decision)
            {
                case Constants.YesUserInput:
                    return true;
                    break;
                case Constants.NoUserInput:
                    return false;
                    break;
                default:
                    return false;
                    break
            }
        }
        private static string AskAndGetDecisionUntilCorrect()
        {
            bool startOver = true;
            string startOverDecision = string.Empty;
            do
            {
                Console.WriteLine(Constants.AskIfStartOver);
                startOverDecision = Console.ReadLine();
                if (startOverDecision.Equals(Constants.YesUserInput,StringComparison.OrdinalIgnoreCase) ||
                   startOverDecision.Equals(Constants.NoUserInput,StringComparison.OrdinalIgnoreCase))
                {
                    startOver = false;
                }
            }while(startOver);
            return startOverDecision;
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
