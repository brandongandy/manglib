using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Mang
{
  /// <summary>
  /// I wanted a secondary generator so I pulled this one for now:
  /// https://stackoverflow.com/questions/3371829/how-can-i-generate-a-random-english-sounding-word-in-net
  /// TODO: Include original diacritics and recapitalize words.
  /// This is also prone to index out of range exceptions; so that will need to be fixed.
  /// </summary>
  public sealed class PseudoWordGenerator : IMarkovGenerator
  {
    private readonly HashSet<string> enders = new HashSet<string>();
    private readonly List<string> starters = new List<string>();

    private readonly Dictionary<char, List<string>> gramDict =
        Enumerable
            .Range('a', 'z')
            .ToDictionary(a => (char)a, _ => new List<string>());

    public PseudoWordGenerator(IEnumerable<string> words, int gramLen)
    {
      foreach (var word in words.Select(w => w.Trim().ToLower()).Where(w => w.Length > gramLen)
          .Where(w => Regex.IsMatch(w, "^[a-z]+$")))
      {
        starters.Add(word.Substring(0, gramLen));
        enders.Add(word.Substring(word.Length - gramLen, gramLen));
        for (var i = 0; i < word.Length - gramLen; i++)
        {
          var currentLetter = word[i];
          if (!gramDict.TryGetValue(currentLetter, out var grams))
          {
            i = word.Length;
            continue;
          }

          grams.Add(word.Substring(i + 1, gramLen));
        }
      }
    }

    public string GenerateWord(int wordLength)
    {
      var result = new StringBuilder(GetRandomStarter());
      var lastGram = string.Empty;
      while (result.Length < wordLength || !enders.Contains(lastGram))
      {
        lastGram = GetRandomGram(result[result.Length - 1]);
        result.Append(lastGram);
      }

      return result.ToString();
    }

    private string GetRandomStarter() => GetRandomElement(starters);

    private string GetRandomGram(char preceding) =>
      GetRandomElement(gramDict[preceding]);

    private T GetRandomElement<T>(IList<T> collection) =>
      collection[GetRandomUnsigned(collection.Count - 1)];

    private int GetRandomUnsigned(int max)
    {
      return Utils.RandomNumber.Next(max);
    }
  }
}
