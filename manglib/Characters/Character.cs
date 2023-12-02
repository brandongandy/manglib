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
      new Trait("Openness", "Guarded", "Optimistic", "T", "F"),
      new Trait("Yield", "Defiant", "Compliant", "T", "F"),
      new Trait("Anxiety", "Carefree", "Worried", "T", "F"),
      new Trait("Opinion", "Decisive", "Ambivalent", "J", "P"),
      new Trait("Bravery", "Intrepid", "Inhibited", "E", "I"),
      new Trait("Leadership", "Leader", "Follower", "E", "I"),
      new Trait("Mindset", "Proactive", "Distractible", "J", "P")
    };

    public string Openness => Traits[0].ToString();
    public string Yield => Traits[1].ToString();
    public string Anxiety => Traits[2].ToString();
    public string Opinion => Traits[3].ToString();
    public string Bravery => Traits[4].ToString();
    public string Leadership => Traits[5].ToString();
    public string Mindset => Traits[6].ToString();

    public List<Trait> Types = new List<Trait>
    {
      new Trait("Energy", "Extraverted", "Introverted", "E", "I"),
      new Trait("Mind", "Sensing", "Intuitive", "S", "N"),
      new Trait("Nature", "Thinking", "Feeling", "T", "F"),
      new Trait("Tactics", "Judging", "Prospecting", "J", "P")
    };

    public string Energy => Types[0].ToString();
    public string Mind => Types[1].ToString();
    public string Nature => Types[2].ToString();
    public string Tactics => Types[3].ToString();

    public List<Trait> Drives = new List<Trait>
    {
      new Trait("Confidence", "Confidence", "Confidence", "X", "X"),
      new Trait("Ambition", "Ambition", "Ambition", "X", "X"),
      new Trait("Dedication", "Dedication", "Dedication", "X", "X")
    };

    public string MeyersBriggsType
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

    public string MeyersBriggsName
    {
      get
      {
        return MeyersBriggsType switch
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

    public string MeyersBriggsClass
    {
      get
      {
        return MeyersBriggsType switch
        {
          "INTJ" or "INTP" or "ENTJ" or "ENTP" => "Analyst",
          "INFJ" or "INFP" or "ENFJ" or "ENFP" => "Diplomat",
          "ISTJ" or "ISFJ" or "ESTJ" or "ESFJ" => "Sentinel",
          "ISTP" or "ISFP" or "ESTP" or "ESFP" => "Explorer",
          _ => "",
        };
      }
    }

    public string MeyersBriggsClassAndName => $"{MeyersBriggsClass} - {MeyersBriggsName}";
  }
}
