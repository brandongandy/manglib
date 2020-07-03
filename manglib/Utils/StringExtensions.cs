using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace manglib.Utils
{
  public static class StringExtensions
  {
    //private static CompareInfo comparer = new CultureInfo("en-US").CompareInfo;

    /// <summary>
    /// There's no need to be clever about stripping vowels of their diacritics.
    /// We'll just use a premade list of vowels and their variants.
    /// This list *does* include Y.
    /// Vowel list courtesy of https://gist.github.com/m93a/6ac058040443acb3d3b3da773c673850
    /// </summary>
    public static string vowels = "aeiouyáéíóúýa̋e̋i̋őűàèìòùỳầềồḕṑǜừằȁȅȉȍȕăĕĭŏŭy̆ắằẳẵặḝȃȇȋȏȗǎěǐǒǔy̌a̧ȩə̧ɛ̧i̧ɨ̧o̧u̧âêîôûŷḙṷ"
      + "ẩểổấếốẫễỗậệộäëïöüÿṳḯǘǚṏǟȫǖṻȧėıȯẏǡạẹịọụỵậȩ̇ǡȱảẻỉỏủỷơướứờừởửỡữợựāǣēīōūȳḗṓȭǭąęįǫųy̨åi̊ůḁǻą̊"
      + "ãẽĩõũỹаэыуояеёюийⱥɇɨøɵꝋʉᵿɏөӫұɨαεηιοωυάέήίόώύὰὲὴὶὸὼὺἀἐἠἰὀὠὐἁἑἡἱὁὡὑᾶῆῖῶῦἆἦἶὦὖἇἧἷὧὗᾳῃῳᾷῇῷ"
      + "ᾴῄῴᾲῂῲᾀᾐᾠᾁᾑᾡᾆᾖᾦᾇᾗᾧϊϋΐΰῒῢῗῧἅἕἥἵὅὥὕἄἔἤἴὄὤὔἂἒἢἲὂὢὒἃἓἣἳὃὣὓᾅᾕᾥᾄᾔᾤᾂᾒᾢᾃᾓᾣæɯɪʏʊøɘɤəɛœɜɞʌɔɐɶɑɒιυ";

    /// <summary>
    /// Determines whether the passed in <see cref="char"/> is a vowel or consonant.
    /// </summary>
    /// <param name="character"></param>
    /// <returns>True if the <see cref="char"/> is a vowel.</returns>
    public static bool IsVowel(this char character)
    {
      return IsCharacterVowel(character);
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
    /// Determines whether the given character is a vowel. Treats all non-letter characters as consonants.
    /// </summary>
    /// <param name="character">The char value to check</param>
    /// <returns>True if vowel, false if otherwise</returns>
    private static bool IsCharacterVowel(char character)
    {
      // ew
      var c = character.ToString().ToLowerInvariant().ToCharArray()[0];

      if (!char.IsLetter(c))
      {
        return false;
      }

      return vowels.Contains(c);
    }
  }
}
