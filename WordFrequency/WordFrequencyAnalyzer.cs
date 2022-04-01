
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordFrequency
{
    public interface IWordFrequency
    {
        string Word { get; }
        int Frequency { get; }
    }

    public interface IWordFrequencyAnalyzer
    {
        int CalculateHighestFrequency(string text);
        int CalculateFrequencyForWord(string text, string word);
        IList<IWordFrequency> CalculateMostFrequentNWords(string text, int n);
    }
    public class WordFrequencyAnalyzer : IWordFrequency, IWordFrequencyAnalyzer
    {
        private string _word = string.Empty;
        private int _frequency = 0;
        private string _text = string.Empty;
        Dictionary<string, int> _wordFrequencyList;

        public string Word
        {
            get { return _word; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Word can not be null or empty.");
                }
                _word = value;
            }
        }

        public int Frequency
        {
            get { return _frequency; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Frequency can not be negative.");
                }
                _frequency = value;
            }

        }

        public string Text
        {
            get { return _text; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Text can not be null or empty.");
                }
                _text = value;
            }

        }

        /// <summary>
        /// This method calculates the no of occurances of the word in the given text.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="word"></param>
        /// <returns>rethrns the highest frequency count of the word in the text.</returns>
        public int CalculateFrequencyForWord(string text, string word)
        {
            int _frequencyCount = 0;
            try
            {
                Text = text;
                Word = word;
                
                if (IsAlphabet(Word))
                {
                    foreach (Match match in Regex.Matches(text, Word, RegexOptions.IgnoreCase))
                    {
                        _frequencyCount++;
                    }
                }
                else
                {
                    throw new Exception("Invalid characters found.Only alphabets are allowed in a word.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return _frequencyCount;

        }
        /// <summary>
        /// This method calculates the no of occurances of each word in the given text.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>returns the highest frequency in the given text.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public int CalculateHighestFrequency(string text)
        {
            try
            {
                Text = text;
                GetWordsDictionary(text);

                foreach (KeyValuePair<string, int> item in _wordFrequencyList)
                {
                    if (item.Value.Equals(_wordFrequencyList.Values.Max()))
                        Console.WriteLine($"The word '{item.Key}' found {item.Value} times.");
                }

            }
            catch (Exception ex)
            {
               // Console.WriteLine("Error Details:" + ex.Message);
                throw new Exception(ex.Message);
            }
            if (_wordFrequencyList != null)
                return _wordFrequencyList.Values.Max();
            else
                return 0;

        }


        /// <summary>
        /// This method find the most frequent words from the given text.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="n"></param>
        /// <returns>returns the most frequent n words.</returns>
        public IList<IWordFrequency> CalculateMostFrequentNWords(string text, int n)
        {
            IList<IWordFrequency> wordFrequencies = new List<IWordFrequency>();

            try
            {
                Text = text;
                if (n < 0)
                    throw new Exception("The number can not be negative.");

                GetWordsDictionary(text);

                int _maxCount = _wordFrequencyList.Values.Max();
                for (int i = 0; i < n; i++)
                {
                    var orderList = _wordFrequencyList.OrderBy(x => x.Key);
                    foreach (var item in orderList)
                    {
                        if (item.Value.Equals(_maxCount))
                        {
                            wordFrequencies.Add(new WordFrequencyAnalyzer { Word = item.Key, Frequency = item.Value });
                            Console.WriteLine($"('{item.Key}',{item.Value}) \t ");
                        }
                        if (wordFrequencies.Count == n)
                            return wordFrequencies;

                    }
                    _maxCount--;

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return wordFrequencies;

        }

        /// <summary>
        /// This method creates a dictionary with list of words of the given input text.
        /// </summary>
        /// <param name="text"></param>
        public void GetWordsDictionary(string text)
        {
            try
            {
                _wordFrequencyList = new Dictionary<string, int>();
                int _frequencyCount = 0;
                string[] words = text.ToLower().Split(new char[] { '.', '?', '!', ' ', ';', ':', ',' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var searchWord in words)
                {
                    _frequencyCount = 0;
                    /* It checks whether the word contains only characters from a-z or A-Z */
                    if (IsAlphabet(searchWord))
                    {
                        for (int i = 0; i < words.Length; i++)
                        {
                            if (words[i].Equals(searchWord))
                                _frequencyCount++;

                        }
                        if (!_wordFrequencyList.ContainsKey(searchWord))
                        {
                            _wordFrequencyList.Add(searchWord, _frequencyCount);
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        private bool IsAlphabet(string word)
        {
            return word.All(Char.IsLetter);
        }

        public static void Main()
        {

            int _frequencyCount = 0;

            Console.WriteLine("Enter input text: ");
            string text = "The sun shine over the lake";

            Console.WriteLine("Enter search word:");
            string searchTerm ="the";

            try
            {
                WordFrequencyAnalyzer wordFrequencyAnalyzer = new WordFrequencyAnalyzer();

                Console.WriteLine("CalculateHighestFrequency. \n ");
                _frequencyCount = wordFrequencyAnalyzer.CalculateHighestFrequency(text);
                Console.WriteLine($"The highest frequency count is {_frequencyCount} \n");

                Console.WriteLine("CalculateFrequencyForWord. \n");
                _frequencyCount = wordFrequencyAnalyzer.CalculateFrequencyForWord(text, searchTerm);
                Console.WriteLine($"The word '{searchTerm}' found {_frequencyCount} times. \n");

                Console.WriteLine("CalculateMostFrequentNWords. \n");
                Console.WriteLine("Enter the no of words");
                string wordCount = "3";
                IList<IWordFrequency> wordFrequenciesList = wordFrequencyAnalyzer.CalculateMostFrequentNWords(text, Convert.ToInt32(wordCount));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed Execution." + ex.Message);
            }
        }
    }

  
}
