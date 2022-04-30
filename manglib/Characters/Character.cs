using System;
using System.Collections.Generic;
using System.Text;

namespace Mang.Characters
{
  public class Character
  {
    public string Name { get; set; }
    public string Gender { get; set; }

    public List<Trait> Traits = new List<Trait>
    {
      new Trait("Guarded", "Optimistic", "T", "F"),
      new Trait("Defiant", "Compliant", "T", "F"),
      new Trait("Carefree", "Worried", "T", "F"),
      new Trait("Decisive", "Ambivalent", "J", "P"),
      new Trait("Intrepid", "Inhibited", "E", "I"),
      new Trait("Leader", "Follower", "E", "I"),
      new Trait("Proactive", "Distractible", "J", "P")
    };

    public List<Trait> Types = new List<Trait>
    {
      new Trait("Extraverted", "Introverted", "E", "I"),
      new Trait("Sensing", "Intuitive", "S", "N"),
      new Trait("Thinking", "Feeling", "T", "F"),
      new Trait("Judging", "Perceiving", "J", "P")
    };

    public List<Trait> Drives = new List<Trait>
    {
      new Trait("Confidence", "Confidence", "X", "X"),
      new Trait("Ambition", "Ambition", "X", "X"),
      new Trait("Dedication", "Dedication", "X", "X")
    };

    public string MBType
    {
      get
      {
        var type = "";

        foreach (var t in Types)
        {
          type += t.DominantAssociation;
        }

        return type;
      }
    }

    public string MBName
    {
      get
      {
        return MBType switch
        {
          "INTJ" => "Architect",
          "INTP" => "Logician",
          "ENTJ" => "Commander",
          "ENTP" => "Debater",
          "INFJ" => "Advocate",
          "INFP" => "Mediator",
          "ENFJ" => "Protagonist",
          "ENFP" => "Campaigner",
          "ISTJ" => "Logistician",
          "ISFJ" => "Defender",
          "ESTJ" => "Executive",
          "ESFJ" => "Consul",
          "ISTP" => "Virtuoso",
          "ISFP" => "Adventurer",
          "ESTP" => "Entrepreneur",
          "ESFP" => "Entertainer",
          _ => "",
        };
      }
    }

    public string MBClass
    {
      get
      {
        switch (MBType)
        {
          case "INTJ":
          case "INTP":
          case "ENTJ":
          case "ENTP":
            return "Analyst";
          case "INFJ":
          case "INFP":
          case "ENFJ":
          case "ENFP":
            return "Diplomat";
          case "ISTJ":
          case "ISFJ":
          case "ESTJ":
          case "ESFJ":
            return "Sentinel";
          case "ISTP":
          case "ISFP":
          case "ESTP":
          case "ESFP":
            return "Explorer";
          default:
            return "";
        }
      }
    }
  }
}
