using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Words.Test.Unit
{
    [TestClass]
    public class WordMatcherTest
    {
        private readonly WordMatcher _wordMatcher = new WordMatcher();
        [TestMethod]
        public void ScrambledWordMatchesGivenWordInTheList()
        {
            List<string> words = new List<string>{ "cat", "table", "more" };
            string[] scrambledWord = { "omre" };

            var matchedWords = _wordMatcher.Matches(scrambledWord, words);

            Assert.IsTrue(matchedWords.Count == 1);
            Assert.IsTrue(matchedWords[0].UnscrambledWord.Equals("omre"));
            Assert.IsTrue(matchedWords[0].Word.Equals("more"));

        }

        [TestMethod]
        public void ScrambledWordsMatchGivenWordsInTheList()
        {
            List<string> words = new List<string> { "karamba", "table", "more" };
            string[] scrambledWord = { "omre", "rakamba" };

            var matchedWords = _wordMatcher.Matches(scrambledWord, words);

            Assert.IsTrue(matchedWords.Count == 2);
            Assert.IsTrue(matchedWords[0].UnscrambledWord.Equals("omre"));
            Assert.IsTrue(matchedWords[0].Word.Equals("more"));
            Assert.IsTrue(matchedWords[1].UnscrambledWord.Equals("rakamba"));
            Assert.IsTrue(matchedWords[1].Word.Equals("karamba"));

        }
    }
}
