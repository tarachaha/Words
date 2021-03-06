using System;
using System.Collections.Generic;
using Words.Data;

namespace Words
{
    public class WordMatcher
    {
        private static readonly FileReader _fileReader = new FileReader();
        internal List<MatchedWord> Matches(string[] words, string dict)
        {
            List<MatchedWord> matchedWords = new List<MatchedWord>();
            List<string> dictionary = _fileReader.ReadFromFile(dict);
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
        internal List<MatchedWord> Matches(List<string> words, string dict)
        {
            List<MatchedWord> matchedWords = new List<MatchedWord>();
            List<string> dictionary = _fileReader.ReadFromFile(dict);
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

                        char[] refrenceWord = dictWord.ToCharArray();
                        Array.Sort(refrenceWord);
                        var sortedReferenceWord = new string(refrenceWord);
                        if (sortedToCheck.Equals(sortedReferenceWord, StringComparison.OrdinalIgnoreCase) &&
                            !(wordToCheck.Equals(dictWord, StringComparison.OrdinalIgnoreCase)))
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