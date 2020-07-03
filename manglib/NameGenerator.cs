using manglib.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace manglib
{
  public class NameGenerator
  {
    #region Fields

    private MarkovData markovData;
    private readonly int listSize = 20;
    private List<string> stringsUsed = new List<string>();

    private readonly int tokenLength;
    private readonly TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

    private List<string> usedGrammars = new List<string>();

    #endregion

    #region Properties

    public List<string> NameList { get; set; }

    public int ListSize
    {
      get { return listSize; }
    }

    #endregion

    public NameGenerator(IEnumerable<string> input, int tokenLength)
    {
      this.tokenLength = tokenLength;

      markovData = new MarkovData(input, tokenLength);
      NameList = GetNameList(listSize);
    }

    /// <summary>
    /// Generates a list of distinct names based on the given Markov data
    /// </summary>
    /// <param name="listSize">How many names to generate at once</param>
    /// <returns></returns>
    public List<string> GetNameList(int listSize)
    {
      List<string> names = new List<string>();
      for (int i = 0; i < listSize; i++)
      {
        string nextName = GetNextName();
        if (names.Contains(nextName))
        {
          i--;
          continue;
        }
        else
        {
          names.Add(nextName);
        }
      }
      return names;
    }

    /// <summary>
    /// Returns a single name with no regard for how many times that name may have been generated before.
    /// </summary>
    /// <returns>A single Markov-generated name</returns>
    public string GetNextName()
    {
      string nextName = markovData.GetRandomKey();

      // get a random name from the input samples
      // then generate a word length to aim at

      int minLength = tokenLength + nextName.Length;
      int maxLength = RandomNumber.Next(minLength + tokenLength, markovData.GetRandomSampleWord().Length + minLength);
      int nameLength = RandomNumber.Next(minLength, maxLength);

      // generate the next name: a random substring of the random sample name
      // then get a random next letter based on the previous ngram

      while (nextName.Length < nameLength)
      {
        string token = nextName.Substring(nextName.Length - tokenLength, tokenLength);
        if (markovData.MarkovChain.ContainsKey(token))
        {
          nextName += NextLetter(token);
        }
        else
        {
          break;
        }
      }

      nextName = textInfo.ToTitleCase(nextName.ToLower());

      return nextName;
    }

    private char NextLetter(string token)
    {
      List<char> letters;
      // get all the letters that come after the passed-in token
      // then pick a random one and return it
      if (RandomNumber.NextDouble() > 0.05)
      {
        letters = markovData.MarkovChain[token];
      }
      else
      {
        letters = markovData.MarkovChain[markovData.GetRandomKey()];
      }

      int nextLetter = RandomNumber.Next(letters.Count);

      var c = letters[nextLetter];

      while (token.IsAllConsonants())
      {
        if (c.IsVowel())
        {
          return c;
        }
        else
        {
          c = letters[RandomNumber.Next(letters.Count)];
        }
      }

      return c;
    }
  }
}
