using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Mang.Utils;

namespace Mang
{
  /// <summary>
  /// I wanted a secondary generator so I pulled this one for now:
  /// https://stackoverflow.com/questions/3371829/how-can-i-generate-a-random-english-sounding-word-in-net
  /// TODO: Include original diacritics and recapitalize words.
  /// </summary>
  public sealed class MangUpdatedGenerator : IMarkovGenerator
  {
    #region Fields

    private static readonly TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

    private readonly List<string> starters = new List<string>();
    private readonly HashSet<string> enders = new HashSet<string>();

    private readonly Dictionary<char, List<string>> gramDict = 
      new Dictionary<char, List<string>>();

    #endregion

    #region Constructor

    public MangUpdatedGenerator(IEnumerable<string> words, int gramLen)
    {
      foreach (var word in words.Select(w => w.Trim().ToLower()).Where(w => w.Length > gramLen))
      {
        starters.Add(word[..gramLen]);
        enders.Add(word.Substring(word.Length - gramLen, gramLen));
        for (var i = 0; i < word.Length - gramLen; i++)
        {
          var currentLetter = word[i];
          if (!gramDict.TryGetValue(currentLetter, out var grams))
          {
            grams = new List<string>();
            gramDict.Add(currentLetter, grams);
          }

          grams.Add(word.Substring(i + 1, gramLen));
        }
      }
    }

    #endregion

    #region Public Methods

    public string GenerateWord(int wordLength)
    {
      var result = new StringBuilder(GetRandomStarter());
      var lastGram = string.Empty;
      var numberOfTries = 0;

      while ((result.Length < wordLength || enders.Contains(lastGram)) &&
        numberOfTries < 100)
      {
        try
        {
          lastGram = GetRandomGram(result[^1]);
          result.Append(GetRandomGram(result[^1]));
        }
        catch
        {
          // If the gram has no following characters,
          // restart the randomization with a new starter.
          lastGram = GetRandomStarter();
          result.Append(lastGram);
        }
        numberOfTries++;
      }

      while (result[^2] == ' ' || result[^2] == '-')
      {
        result = result.Remove(result.Length - 2, 2);
      }

      while (result[^1] == '-')
      {
        result = result.Remove(result.Length - 1, 1);
      }

      return textInfo.ToTitleCase(result.ToString());
    }

    #endregion

    #region Private Methods

    private string GetRandomStarter() => GetRandomElement(starters);

    private string GetRandomGram(char preceding)
    {
      return GetRandomElement(gramDict[preceding]);
    }

    private static T GetRandomElement<T>(IList<T> collection)
    {
      return collection[GetRandomUnsigned(collection.Count - 1)];
    }

    private static int GetRandomUnsigned(int max)
    {
      return RandomNumber.Next(max);
    }

    #endregion
  }
}
