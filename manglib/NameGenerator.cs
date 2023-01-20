using Mang.Data.Names;
using Mang.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Mang
{
  public class NameGenerator
  {
    #region Fields

    private MangDefaultGenerator markovData;

    private int listSize = 20;

    #endregion

    #region Properties

    public List<string> NameList { get; private set; }

    public int ListSize
    {
      get
      {
        return listSize;
      }
      set
      {
        listSize = Math.Clamp(value, 1, 100);
      }
    }

    #endregion

    /// <summary>
    /// Default constructor; defaults to use <see cref="Aztec.Female"/> names with a token length of 3.
    /// </summary>
    public NameGenerator()
    {
      markovData = new MangDefaultGenerator(Aztec.Female, tokenLength: 3, true);
      NameList = new List<string>();
    }

    /// <summary>
    /// Creates a new instance of the name generator with the specified "source" and token length.
    /// </summary>
    /// <param name="input">
    /// A non-empty list of strings; if empty or null then the <see cref="markovData"/>
    /// is not updated.</param>
    /// <param name="tokenLength">The length of the ngram used to generate new names. When in doubt, use 3.</param>
    public NameGenerator(IEnumerable<string> input, int tokenLength)
    {
      markovData = new MangDefaultGenerator(input, tokenLength);
      NameList = new List<string>();
    }

    #region Public Methods

    /// <summary>
    /// Generates a list of distinct names based on the available <see cref="MangDefaultGenerator"/>. Does not use names that
    /// have already been generated during the lifetime of the current Name Source. Call <see cref="ClearNameList"/>
    /// to clear the list of previously used names.
    /// </summary>
    /// <returns>A list of names no longer than the set <see cref="ListSize"/></returns>
    public List<string> GenerateWordList()
    {
      List<string> names = new List<string>();

      int i = 0;
      while (i < ListSize)
      {
        var nextName = GenerateWord();
        if (!NameList.Contains(nextName))
        {
          NameList.Add(nextName);
          names.Add(nextName);
          i++;
        }
      }

      return names;
    }

    /// <summary>
    /// Returns a single name with no regard for how many times that name may have been generated before.
    /// </summary>
    /// <returns>A single Markov-generated name</returns>
    public string GenerateWord()
    {
      return markovData.GenerateWord();
    }

    /// <summary>
    /// Repopulates the <see cref="MangDefaultGenerator"/> instance with new data using values from the
    /// <see cref="Data.Names"/> namespace or your own input, with the option of setting <paramref name="tokenLength"/>
    /// and <paramref name="isPreformatted"/>. Clears the <see cref="NameList"/> on switching.
    /// </summary>
    /// <param name="nameSource">
    /// A non-empty list of strings; if empty or null then the <see cref="markovData"/>
    /// is not updated.</param>
    /// <param name="tokenLength">The length of the ngram used to generate new names. When in doubt, use 3.</param>
    /// <param name="isPreformatted">
    /// Determines whether the MarkovData constructor will sanitize the input before populating all its data.
    /// </param>
    public void SwitchSource(List<string> nameSource, int tokenLength, bool isPreformatted)
    {
      if (nameSource is null ||
          !nameSource.Any())
      {
        return;
      }

      markovData = new MangDefaultGenerator(nameSource, tokenLength, isPreformatted);
      NameList.Clear();
    }

    /// <summary>
    /// Repopulates the <see cref="MangDefaultGenerator"/> instance with new data using values from the
    /// <see cref="Data.Names"/> namespace, with the option of setting <paramref name="tokenLength"/>.
    /// Use only with sanitized input (a clean list of strings).
    /// </summary>
    /// <param name="nameSource">
    /// A non-empty list of strings; if empty or null then the <see cref="markovData"/>
    /// is not updated.</param>
    /// <param name="tokenLength">The length of the ngram used to generate new names. When in doubt, use 3.</param>
    public void SwitchSource(List<string> nameSource, int tokenLength)
    {
      SwitchSource(nameSource, tokenLength, isPreformatted: true);
    }

    /// <summary>
    /// Repopulates the <see cref="MangDefaultGenerator"/> instance with new data using values from the
    /// <see cref="Data.Names"/> namespace. Uses a default token length of 3, and assumes sanitized input.
    /// </summary>
    /// <param name="nameSource">
    /// A non-empty list of strings; if empty or null then the <see cref="markovData"/>
    /// is not updated.</param>
    public void SwitchSource(List<string> nameSource)
    {
      SwitchSource(nameSource, tokenLength: 3, isPreformatted: true);
    }

    public void ClearNameList()
    {
      NameList.Clear();
    }

    #endregion

    #region Private Methods

    #endregion
  }
}
