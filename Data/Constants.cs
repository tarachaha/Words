using System;
using System.Collections.Generic;
using System.Text;

namespace Words.Data
{
    public class Constants
    {
        public const string dictionaryPath = @".\Dictionary.txt";

        public const string greeting = "Welcome to word unscrambler! How do you want to input words to unscramble? ";
        public const string chooseInputOption = "Press M for manual or F for reading from file: ";
        public const string manualInputRequest = "Please enter comma separated words (or single word):  ";
        public const string filePathRequest = "Please input file path: ";
        public const string incorrectSelection = "Incorrect selection";
        public const string askIfStartOver = "Do you want to start over? Y/N";
        public const string listMatchesFound = "Match found for word";
        public const string noMatches = "No matches have been found.";
    }
}
