using System;
using System.Collections.Generic;
using Words.Data;

namespace Words
{
    public class WordMatcher
    {
        private static readonly FileReader _fileReader = new FileReader();

        //Create two overloads for 'Matches' method - for file and manual input
        //
        //Manual input
        public List<MatchedWord> Matches(string[] words, List<string> dictionary)
        {
            List<MatchedWord> matchedWords = new List<MatchedWord>();
            //Iterate through each word given and each word in dictionary
            if (dictionary.Count > 1)
            {
                foreach (string wordToCheck in words)
                {
                    //Sorting characters in checker and checkee to compare them
                    char[] toCheck = wordToCheck.Trim(' ').ToCharArray();
                    Array.Sort(toCheck);
                    var sortedToCheck = new string(toCheck);

                    foreach (string dictWord in dictionary)
                    {

                        char[] refrenceWord = dictWord.Trim('\r').ToCharArray();
                        Array.Sort(refrenceWord);
                        var sortedReferenceWord = new string(refrenceWord);
                        //Check if letter sorted words match and were not the same before sorting
                        if (sortedToCheck.Equals(sortedReferenceWord, StringComparison.OrdinalIgnoreCase) &&
                            !(wordToCheck.Equals(dictWord.Trim('\r'), StringComparison.OrdinalIgnoreCase)))
                        {
                            matchedWords.Add(new MatchedWord() { Word = dictWord, UnscrambledWord = wordToCheck });
                        }
                    }
                }
            }
            return matchedWords;
        }
        //File input
        public List<MatchedWord> Matches(List<string> words, List<string> dictionary)
        {
            List<MatchedWord> matchedWords = new List<MatchedWord>();

            //Iterate through each word read from file and each word in dictionary
            if (dictionary.Count > 1)
            {
                foreach (string wordToCheck in words)
                {
                    //Sorting characters in checker and checkee to compare them
                    char[] toCheck = wordToCheck.ToCharArray();
                    Array.Sort(toCheck);
                    var sortedToCheck = new string(toCheck);

                    foreach (string dictWord in dictionary)
                    {

                        char[] refrenceWord = dictWord.Trim('\r').ToCharArray();
                        Array.Sort(refrenceWord);
                        var sortedReferenceWord = new string(refrenceWord);
                        //Check if letter sorted words match and were not the same before sorting
                        if (sortedToCheck.Equals(sortedReferenceWord, StringComparison.OrdinalIgnoreCase) &&
                            !(wordToCheck.Equals(dictWord.Trim('\r'), StringComparison.OrdinalIgnoreCase)))
                        {
                            matchedWords.Add(new MatchedWord() { Word = dictWord, UnscrambledWord = wordToCheck });
                        }
                    }
                }
            }
            return matchedWords;
        }
    }
}