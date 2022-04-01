using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using WordFrequency;
namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CalculateHighestFrequency_WithValidText_HighestFrequency()
        {
            //Arrange
            int expected = 2;
            string text = "The sun shine over the lake.";

            //Act
            WordFrequencyAnalyzer obj = new WordFrequencyAnalyzer();
            int actual = obj.CalculateHighestFrequency(text);

            //Assert
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void CalculateHighestFrequency_WithEmptyText_ShouldThrowException()
        {
            WordFrequencyAnalyzer obj = new WordFrequencyAnalyzer();
            try
            {
                obj.CalculateHighestFrequency("");
            }
            catch (Exception e)
            {
                StringAssert.Contains(e.Message, "Text can not be null or empty.");
                return;
            }
            Assert.Fail("The expected exception was not thrown.");

        }
        [TestMethod]
        public void CalculateHighestFrequency_TextWithInvalidCharacters_HighestFrequency()
        {
            //Arrange
            int expected = 2;
            string txt = "1.This method calculates frequency of each word in the given text.2.This method retuns the highest frequency.";

            //Act
            WordFrequencyAnalyzer obj = new WordFrequencyAnalyzer();
            int actual = obj.CalculateHighestFrequency(txt);

            //Actual
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void CalculateFrequencyForWord_WithValidTextAndWord_HighestFrequencyOfWord()
        {
            //Arrange
            int expected = 2;
            string text = "The sun shines over the lake";
            string word = "the";

            //Act
            WordFrequencyAnalyzer obj = new WordFrequencyAnalyzer();
            int actual = obj.CalculateFrequencyForWord(text, word);

            //Assert
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void CalculateFrequencyForWord_WithValidTextAndEmptyWord_ShouldThrowException()
        {
            //Arrange
            string text = "The sun shines over the lake";

            //Act
            WordFrequencyAnalyzer obj = new WordFrequencyAnalyzer();
            try
            {
                int actual = obj.CalculateFrequencyForWord(text, "");
            }
            catch (Exception e)
            {
                StringAssert.Contains(e.Message, "Word can not be null or empty.");
                return;
            }
            Assert.Fail("The expected exception was not thrown.");
        }

        [TestMethod]
        public void CalculateFrequencyForWord_WithValidTextAndInvalidWord_ShouldThrowException()
        {
            //Arrange
            string text = "The sun shines over the lake";

            //Act
            WordFrequencyAnalyzer obj = new WordFrequencyAnalyzer();
            try
            {
                obj.CalculateFrequencyForWord(text, "the6");
            }
            catch (Exception e)
            {
                //Assert
                StringAssert.Contains(e.Message, "Invalid characters found.");
                return;
            }
            Assert.Fail("The expected exception was not thrown.");
        }



        [TestMethod]
        public void CalculateMostFrequentNWords_WithValidTextAndNumber_FrequentWordsList()
        {
            //Arrange
            IList<IWordFrequency> expectedWordFrequencies = new List<IWordFrequency>();
            expectedWordFrequencies.Add(new WordFrequencyAnalyzer { Word = "the", Frequency = 2 });
            expectedWordFrequencies.Add(new WordFrequencyAnalyzer { Word = "lake", Frequency = 1 });
            expectedWordFrequencies.Add(new WordFrequencyAnalyzer { Word = "over", Frequency = 1 });

            string text = "The sun shine over the lake";
            int n = 3;

            //Act
            WordFrequencyAnalyzer obj = new WordFrequencyAnalyzer();
            IList<IWordFrequency> actualWordFrequencies = obj.CalculateMostFrequentNWords(text, n);

            //Assert
            Assert.AreEqual(expectedWordFrequencies[0].Frequency, actualWordFrequencies[0].Frequency);
            Assert.AreEqual(expectedWordFrequencies[0].Word, actualWordFrequencies[0].Word);

            Assert.AreEqual(expectedWordFrequencies[1].Frequency, actualWordFrequencies[1].Frequency);
            Assert.AreEqual(expectedWordFrequencies[1].Word, actualWordFrequencies[1].Word);

            Assert.AreEqual(expectedWordFrequencies[2].Frequency, actualWordFrequencies[2].Frequency);
            Assert.AreEqual(expectedWordFrequencies[2].Word, actualWordFrequencies[2].Word);

        }
        [TestMethod]
        public void CalculateMostFrequentNWords_WithValidTextAndNegativeNumber_ShouldThrowException()
        {
            string text = "The sun shine over the lake";
            int n = -3;
            WordFrequencyAnalyzer obj = new WordFrequencyAnalyzer();
            try
            {

                obj.CalculateMostFrequentNWords(text, n);
            }
            catch (Exception e)
            {
                StringAssert.Contains(e.Message, "The number can not be negative.");
                return;
            }
            Assert.Fail("The expected exception was not thrown.");

        }
    }
}