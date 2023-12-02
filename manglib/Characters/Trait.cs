using Mang.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mang.Characters
{
  public class Trait
  {
    public string TraitName { get; set; }
    public string Minor { get; set; }
    public string Major { get; set; }
    public string MajorAssociation { get; set; }
    public string MinorAssociation { get; set; }

    public string Dominant => Bit ? Major : Minor;

    public string DominantAssociation => Bit ? MajorAssociation : MinorAssociation;

    public int Stress { get; set; }
    public bool Bit { get; set; }

    public Trait(string traitName, string major, string minor,
      string majorAssociation, string minorAssociation)
    {
      TraitName = traitName;
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

    public override string ToString()
    { 
      return $"({DominantAssociation}) {Dominant}";
    }
  }
}
