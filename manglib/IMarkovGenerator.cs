using System;
using System.Collections.Generic;
using System.Text;

namespace Mang
{
  public interface IMarkovGenerator
  {
    string GenerateWord(int wordLength);
  }
}
