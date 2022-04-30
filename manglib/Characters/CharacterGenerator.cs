using Mang.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mang.Characters
{
  public class CharacterGenerator
  {
    public Character Character { get; set; }

    public CharacterGenerator()
    {
      Character = new Character();
      RegenerateCharacter();
    }

    public void RegenerateCharacter()
    {
      foreach (var trait in Character.Traits)
      {
        trait.Randomize();
      }

      foreach (var trait in Character.Types)
      {
        trait.Randomize();
      }

      foreach (var drive in Character.Drives)
      {
        drive.Randomize();
      }
    }
  }
}
