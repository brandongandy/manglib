using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Mang.Utils
{

  public static class RandomNumber
  {
    // Thanks to: https://scottlilly.com/create-better-random-numbers-in-c/
    private static RNGCryptoServiceProvider Rand = new RNGCryptoServiceProvider();

    /// <summary>
    /// Returns a "better" random number within the specified range.
    /// </summary>
    /// <param name="minValue">The the inclusive lower bound of the random number to be generated.</param>
    /// <param name="maxValue">The exclusive upper bound of the random number to be generated.</param>
    /// <returns>A random integer that is greater than or equal to the minValue, and less than the maxValue.</returns>
    public static int Next(int minValue, int maxValue)
    {
      byte[] randomNumber = new byte[1];
      Rand.GetBytes(randomNumber);

      double asciiValueOfRandomCharacter = Convert.ToDouble(randomNumber[0]);

      // Ensure the multiplier will always be between 0.0 and *just* under 1.0.
      double multiplier = Math.Max(0, (asciiValueOfRandomCharacter / 255d) - 0.00000000001d);

      // Add 1 to the range to allow for the rounding done in Math.Floor
      int range = maxValue - minValue + 1;

      double randomValueInRange = Math.Floor(multiplier * range);

      return (int)(minValue + randomValueInRange);
    }

    /// <summary>
    /// Returns a "better" random number less than the specified maximum.
    /// </summary>
    /// <param name="maxValue">The exclusive upper bound of the random number to be generated.</param>
    /// <returns></returns>
    public static int Next(int maxValue)
    {
      return Next(0, maxValue - 1);
    }

    /// <summary>
    /// Use when you want a "true" random double -- unseeded.
    /// </summary>
    /// <returns>Value between 0.0 and 1.0, inclusive.</returns>
    public static double NextDouble()
    {
      double minValue = 0.0;
      double maxValue = 1.0;
      byte[] randomNumber = new byte[1];
      Rand.GetBytes(randomNumber);

      double asciiValueOfRandomCharacter = Convert.ToDouble(randomNumber[0]);

      // Ensure the multiplier will always be between 0.0 and *just* under 1.0.
      double multiplier = Math.Max(0, (asciiValueOfRandomCharacter / 255d) - 0.00000000001d);

      // Add 1 to the range to allow for the rounding done in Math.Floor
      double range = maxValue - minValue + 1;

      double randomValueInRange = Math.Floor(multiplier * range);

      return (minValue + randomValueInRange);
    }
  }
}
