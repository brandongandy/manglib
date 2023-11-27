using Mang.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Mang
{
  /// <summary>
  /// A more "strict" Markov generator, in which the previous full token determines the next character chosen.
  /// </summary>
  public class MangDefaultGenerator : IMarkovGenerator
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


    private static readonly TextInfo TextInfo = new CultureInfo("en-US", false).TextInfo;
    private readonly int tokenLength;

    #endregion

    #region Properties

    /// <summary>
    /// The list of token/list pairs that constitute the data behind a Markov chain.
    /// </summary>
    private Dictionary<string, List<char>> MarkovChain { get; }

    /// <summary>
    /// A list of the sample words used to generate the <see cref="MarkovChain"/> data.
    /// </summary>
    private readonly List<string> samples;

    /// <summary>
    /// "Grammars" consisting of vowel-consonant pairs, denoted by "A" for vowel and "C" for consonant.
    /// </summary>
    private List<string> grammars;

    #endregion

    #region Constructor

    /// <summary>
    /// Creates a new MarkovData object using the supplied parameters.
    /// </summary>
    /// <param name="input">Input data to parse into Markov Data</param>
    /// <param name="tokenLength">The length of the ngram, or token, used to generate Markov chains. When in doubt, use 3.</param>
    /// <param name="isPreformatted">
    /// Specifies whether the <paramref name="input"/> has already been sanitized, or if it needs to be cleaned before use.
    /// </param>
    public MangDefaultGenerator(IEnumerable<string> input, int tokenLength, bool isPreformatted = false)
    {
      this.tokenLength = Math.Clamp(tokenLength, 1, 5);

      if (isPreformatted)
      {
        samples = input.ToList();
      }
      else
      {
        samples = PopulateSampleList(input);
      }

      grammars = PopulateGrammars(samples).ToList();
      MarkovChain = PopulateMarkovChain(samples);
    }

    #endregion

    #region Public Methods

    /// <summary>
    /// Returns a single name with no regard for how many times that name may have been generated before.
    /// </summary>
    /// <returns>A single Markov-generated name</returns>
    public string GenerateWord(int wordLength = 0)
    {
      var nextName = new StringBuilder(GetRandomKey());

      // get a random name from the input samples
      // then generate a word length to aim at
      var minLength = tokenLength + nextName.Length;
      var nameLength = wordLength;
      var numberOfTries = 0;
      
      if (wordLength <= 0)
      {
        wordLength = RandomNumber.Next(minLength + tokenLength, GetRandomSampleWord().Length + minLength);
        nameLength = RandomNumber.Next(minLength, wordLength);
      }

      // generate the next name: a random substring of the random sample name
      // then get a random next letter based on the previous ngram

      while (nextName.Length < nameLength &&
             numberOfTries < 100)
      {
        var token = nextName.ToString().Substring(nextName.Length - tokenLength, tokenLength);
        if (MarkovChain.ContainsKey(token))
        {
          nextName.Append(NextLetter(token));
        }
        else
        {
          nextName.Append(GetRandomKey());
        }

        numberOfTries++;
      }

      return TextInfo.ToTitleCase(nextName.ToString().ToLower());
    }

    #endregion

    #region Private Methods

    private string GetRandomKey()
    {
      return MarkovChain.ElementAt(RandomNumber.Next(MarkovChain.Count)).Key;
    }

    private string GetRandomSampleWord()
    {
      return samples[RandomNumber.Next(samples.Count)];
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

      var sanitizedSamples = new List<string>();

      foreach (var line in rawSampleNameList)
      {
        var splitChar = new char[] { ',', '\n' };
        var tokens = line.Split(splitChar);

        foreach (var word in tokens)
        {
          if (word.Trim().ToUpper().Length >= tokenLength)
          {
            sanitizedSamples.Add(word);
          }
        }
      }

      return sanitizedSamples;
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

      var markovChain = new Dictionary<string, List<char>>();

      foreach (var word in sampleNameList)
      {
        for (var letter = 0; letter < word.Length - tokenLength; letter++)
        {
          var token = word.Substring(letter, tokenLength);

          if (!markovChain.TryGetValue(token, out var ngrams))
          {
            ngrams = new List<char>();
            markovChain.Add(token, ngrams);
          }

          ngrams.Add(word[letter + tokenLength]);
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
      var str = "";
      for (var i = 0; i < word.Length; i++)
      {
        var flag = word[i].IsVowel();
        str = flag ? (str + "A") : (str + "C");
      }
      return str;
    }

    private char NextLetter(string token)
    {
      List<char> letters;
      // get all the letters that come after the passed-in token
      // then pick a random one and return it
      if (RandomNumber.NextDouble() > 0.05)
      {
        letters = MarkovChain[token];
      }
      else
      {
        letters = MarkovChain[GetRandomKey()];
      }

      var nextLetter = RandomNumber.Next(letters.Count);

      var c = letters[nextLetter];

      while (token.IsAllConsonants())
      {
        if (c.IsVowel())
        {
          return c;
        }
        else
        {
          c = NextLetter(token);
        }
      }

      return c;
    }

    #endregion
  }
}
