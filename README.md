# word-frequency-test
Utility to find word frequency  
**word-frequency-test** is simple text processing library written in C#.

## Implemented the three usecases

o **CalculateHighestFrequency** will return the highest frequency in the text (severalwords might actually have this frequency)  
o **CalculateFrequencyForWord** will return the frequency of the specified word. you need to input the word.  
o **CalculateMostFrequentNWords** will return a list of the most frequent „n‟ words in the input text, all the words returned in lower case. If several words 
    have the same frequency, this method will return them in ascendant alphabetical order (for input text “The sun shines over the lake” and n = 3, 
    it should return the list { (“the”, 2), (“lake”, 1), (“over”,1)}
  
 ## How to Test this program
 
 You can download the all C# files to your local computer and run the main class.  
 This would ask you to enter the text and search word. Once you entered the serach word will return the highest frequency of the word and number of occurances of the given word.   At last it will ask you to enter a number to return the most frequent words
