using Mang.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mang.Characters
{
  public class Trait
  {
    public string Minor { get; set; }
    public string Major { get; set; }
    public string MajorAssociation { get; set; }
    public string MinorAssociation { get; set; }

    public string Dominant
    {
      get => Bit ? Major : Minor;
      set => Bit = !Bit;
    }

    public string DominantAssociation
    {
      get => Bit ? MajorAssociation : MinorAssociation;
      set => Bit = !Bit;
    }

    public int Stress { get; set; }
    public bool Bit { get; set; }

    public Trait(string major, string minor,
      string majorAssociation, string minorAssociation)
    {
      Major = major;
      Minor = minor;
      MajorAssociation = majorAssociation;
      MinorAssociation = minorAssociation;
    }

    public void Randomize()
    {
      Bit = RandomNumber.FlipCoin();
      Stress = RandomNumber.Next(1, 99);
    }
  }
}
