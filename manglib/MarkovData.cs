using Mang.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mang
{

  public class MarkovData
  {
    /*
      TODO: 
        1. Add Damerau-Levenshtein distance check to ensure output is not
           too close to input.
        2. Add constant, low probability that a random letter from the 
           "input alphabet" is picked, instead of the normal next letter.
        3. Extend name generation to take into account input word "moulds"
           -- CVCCVVC, CVCCVC, etc., to ensure "grammar" is kept intact
           and no complete gibberish is created
    */

    #region Fields

    private readonly int tokenLength;

    #endregion

    #region Properties

    /// <summary>
    /// The list of token/list pairs that constitute the data behind a Markov chain.
    /// </summary>
    public Dictionary<string, List<char>> MarkovChain { get; set; }

    /// <summary>
    /// A list of the sample words used to generate the <see cref="MarkovChain"/> data.
    /// </summary>
    public List<string> Samples { get; private set; }

    /// <summary>
    /// "Grammars" consisting of vowel-consonant pairs, denoted by "A" for vowel and "C" for consonant.
    /// </summary>
    public List<string> Grammars { get; private set; }

    #endregion

    /// <summary>
    /// Creates a new MarkovData object using the supplied parameters.
    /// </summary>
    /// <param name="input">Input data to parse into Markov Data</param>
    /// <param name="tokenLength">The length of the ngram, or token, used to generate Markov chains. When in doubt, use 3.</param>
    /// <param name="isPreformatted">
    /// Specifies whether the <paramref name="input"/> has already been sanitized, or if it needs to be cleaned before use.
    /// </param>
    public MarkovData(IEnumerable<string> input, int tokenLength, bool isPreformatted = false)
    {
      this.tokenLength = tokenLength;

      if (isPreformatted)
      {
        Samples = input.ToList();
      }
      else
      {
        Samples = PopulateSampleList(input);
      }

      Grammars = PopulateGrammars(Samples).ToList();
      MarkovChain = PopulateMarkovChain(Samples);
    }

    public string GetRandomKey()
    {
      return MarkovChain.ElementAt(RandomNumber.Next(MarkovChain.Count)).Key;
    }

    public string GetRandomSampleWord()
    {
      return Samples[RandomNumber.Next(Samples.Count)];
    }

    /// <summary>
    /// Iterates through the input list and adds only valid values to the useable list of Sample strings.
    /// This method accepts "dirty" input that has not already been formatted and splist and separates that input
    /// into an acceptable, usable list of sample words.
    /// </summary>
    /// <param name="rawSampleNameList">A list of names to potentially be used by the Markov chain</param>
    /// <returns>A list of valid entries for the Markov chain</returns>
    private List<string> PopulateSampleList(IEnumerable<string> rawSampleNameList)
    {
      if (rawSampleNameList is null)
      {
        throw new ArgumentNullException(nameof(rawSampleNameList));
      }

      List<string> samples = new List<string>();

      foreach (string line in rawSampleNameList)
      {
        char[] splitChar = new char[] { ',', '\n' };
        string[] tokens = line.Split(splitChar);

        foreach (string word in tokens)
        {
          string upper = word.Trim().ToUpper();
          if (upper.Length >= tokenLength)
          {
            samples.Add(upper);
          }
        }
      }

      return samples;
    }

    /// <summary>
    /// Populates the Markov chain with tokens and values.
    /// </summary>
    /// <param name="sampleNameList">A formatted list of strings to parse through</param>
    private Dictionary<string, List<char>> PopulateMarkovChain(IEnumerable<string> sampleNameList)
    {
      if (sampleNameList is null)
      {
        throw new ArgumentNullException(nameof(sampleNameList));
      }

      Dictionary<string, List<char>> markovChain = new Dictionary<string, List<char>>();

      foreach (string word in sampleNameList)
      {
        for (int letter = 0; letter < word.Length - tokenLength; letter++)
        {
          string token = word.Substring(letter, tokenLength);

          List<char> entry = new List<char>();

          if (markovChain.ContainsKey(token))
          {
            entry = markovChain[token];
          }
          else
          {
            markovChain[token] = entry;
          }

          entry.Add(word[letter + tokenLength]);
        }
      }

      return markovChain;
    }

    private IEnumerable<string> PopulateGrammars(List<string> sampleList)
    {
      if (sampleList is null)
      {
        throw new ArgumentNullException(nameof(sampleList));
      }

      foreach (var word in sampleList)
      {
        yield return ConstructGrammar(word);
      }
    }

    private string ConstructGrammar(string word)
    {
      string str = "";
      for (int i = 0; i < word.Length; i++)
      {
        bool flag = word[i].IsVowel();
        str = flag ? (str + "A") : (str + "C");
      }
      return str;
    }
  }
}
