using System;
using System.Collections.Generic;
using System.Text;

namespace Words.Data
{
    public class Constants
    {
        public const string DictionaryPath = @".\Dictionary.txt";

        public const string Greeting = "Welcome to word unscrambler! How do you want to input words to unscramble? ";
        public const string ChooseInputOption = "Press M for manual or F for reading from file: ";
        public const string ManualInputRequest = "Please enter comma separated words (or single word):  ";
        public const string FilePathRequest = "Please input file path: ";
        public const string IncorrectSelection = "Incorrect selection";
        public const string AskIfStartOver = "Do you want to start over? Y/N";
        public const string ListMatchesFound = "Match found for word";
        public const string NoMatches = "No matches have been found.";
        public const string ManualInputOption = "m";
        public const string FileInputOption = "f";
        public const string YesUserInput = "y";
        public const string NoUserInput = "n";
    }
}
