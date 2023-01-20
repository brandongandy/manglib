using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mang.Utils
{
  internal static class StringExtensions
  {
    //private static CompareInfo comparer = new CultureInfo("en-US").CompareInfo;

    /// <summary>
    /// There's no need to be clever about stripping vowels of their diacritics.
    /// We'll just use a premade list of vowels and their variants.
    /// This list *does* include Y.
    /// Vowel list courtesy of https://gist.github.com/m93a/6ac058040443acb3d3b3da773c673850
    /// </summary>
    private static readonly string vowels = "aeiouyáéíóúýa̋e̋i̋őűàèìòùỳầềồḕṑǜừằȁȅȉȍȕăĕĭŏŭy̆ắằẳẵặḝȃȇȋȏȗǎěǐǒǔy̌a̧ȩə̧ɛ̧i̧ɨ̧o̧u̧âêîôûŷḙṷ"
      + "ẩểổấếốẫễỗậệộäëïöüÿṳḯǘǚṏǟȫǖṻȧėıȯẏǡạẹịọụỵậȩ̇ǡȱảẻỉỏủỷơướứờừởửỡữợựāǣēīōūȳḗṓȭǭąęįǫųy̨åi̊ůḁǻą̊"
      + "ãẽĩõũỹаэыуояеёюийⱥɇɨøɵꝋʉᵿɏөӫұɨαεηιοωυάέήίόώύὰὲὴὶὸὼὺἀἐἠἰὀὠὐἁἑἡἱὁὡὑᾶῆῖῶῦἆἦἶὦὖἇἧἷὧὗᾳῃῳᾷῇῷ"
      + "ᾴῄῴᾲῂῲᾀᾐᾠᾁᾑᾡᾆᾖᾦᾇᾗᾧϊϋΐΰῒῢῗῧἅἕἥἵὅὥὕἄἔἤἴὄὤὔἂἒἢἲὂὢὒἃἓἣἳὃὣὓᾅᾕᾥᾄᾔᾤᾂᾒᾢᾃᾓᾣæɯɪʏʊøɘɤəɛœɜɞʌɔɐɶɑɒιυ";

    /// <summary>
    /// Determines whether the passed in <see cref="char"/> is a vowel or consonant.
    /// Treats all non-letter characters as consonants.
    /// </summary>
    /// <param name="character"></param>
    /// <returns>True if the <see cref="char"/> is a vowel.</returns>
    public static bool IsVowel(this char character)
    {
      var c = character.ToString().ToLowerInvariant().ToCharArray()[0];

      if (!char.IsLetter(c))
      {
        return false;
      }

      return vowels.Contains(c);
    }

    /// <summary>
    /// Behaves like the Delphi Copy function, which is like Substring but is more
    /// lenient with out of bounds exceptions.
    /// </summary>
    /// <param name="input">The source string</param>
    /// <param name="startIndex">The 0-based index of the start position.</param>
    /// <param name="length">The length, or how many characters to extract.</param>
    /// <returns>
    /// A string that is equivalent to the substring of length <paramref name="length"/> that
    /// begins at <paramref name="startIndex"/> in this instance, or <see cref="string.Empty"/>
    /// if the instance is null/empty or startIndex is higher than the input length.
    /// 
    /// If the length is longer than the number of characters in the unput after startIndex, then
    /// just the remaining characters are returned, instead of throwing an exception.
    /// </returns>
    public static string Copy(this string input, int startIndex, int length)
    {
      if (string.IsNullOrEmpty(input) ||
          startIndex > input.Length)
      {
        return string.Empty;
      }

      if (input.Length < startIndex + length)
      {
        length = input.Length - startIndex;
      }

      return input.Substring(startIndex, length);
    }

    /// <summary>
    /// Determines whether the given <see cref="string"/> consists entirely of consonants.
    /// </summary>
    /// <param name="word"></param>
    /// <returns>True if the <see cref="string"/> is all consonants.</returns>
    public static bool IsAllConsonants(this string word)
    {
      for (int i = 0; i < word.Length; i++)
      {
        if (word[i].IsVowel())
        {
          return false;
        }
      }

      return true;
    }

    /// <summary>
    /// Strips the diacritics from the given <paramref name="text"/> and returns a normalized
    /// form of the string.
    /// </summary>
    /// <param name="text">A string that may contain diacritics that need to be removed.</param>
    /// <returns>A normalized string with characters containing diacritics converted to their ASCII-relative form.</returns>
    public static string RemoveDiacritics(this string text)
    {
      var normalizedString = text.Normalize(NormalizationForm.FormD);
      var stringBuilder = new StringBuilder();

      foreach (var c in normalizedString.EnumerateRunes())
      {
        var unicodeCategory = Rune.GetUnicodeCategory(c);
        if (unicodeCategory != UnicodeCategory.NonSpacingMark)
        {
          stringBuilder.Append(c);
        }
      }

      return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
    }
  }
}
