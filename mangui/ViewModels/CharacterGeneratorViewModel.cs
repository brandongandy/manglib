using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace MangUi.ViewModels
{
  public class CharacterGeneratorViewModel : BindableBase
  {
    private string gender;
    public string Gender
    {
      get => gender;
      set { gender = value; NotifyPropertyChanged(); }
    }

    private string guardedOptimistic;
    public string GuardedOptimistic
    {
      get => guardedOptimistic;
      set { guardedOptimistic = value; NotifyPropertyChanged(); }
    }

    private string defiantCompliant;
    public string DefiantCompliant
    {
      get => defiantCompliant;
      set { defiantCompliant = value; NotifyPropertyChanged(); }
    }

    private string carefreeWorried;
    public string CarefreeWorried
    {
      get => carefreeWorried;
      set { carefreeWorried = value; NotifyPropertyChanged(); }
    }

    private string decisiveAmbivalent;
    public string DecisiveAmbivalent
    {
      get => decisiveAmbivalent;
      set { decisiveAmbivalent = value; NotifyPropertyChanged(); }
    }

    private string intrepidInhibited;
    public string IntrepidInhibited
    {
      get => intrepidInhibited;
      set { intrepidInhibited = value; NotifyPropertyChanged(); }
    }

    private string leaderFollower;
    public string LeaderFollower
    {
      get => leaderFollower;
      set { leaderFollower = value; NotifyPropertyChanged(); }
    }

    private string proactiveDistractible;
    public string ProactiveDistractible
    {
      get => proactiveDistractible;
      set { proactiveDistractible = value; NotifyPropertyChanged(); }
    }

    private string intuitivePlanner;
    public string IntuitivePlanner
    {
      get => intuitivePlanner;
      set { intuitivePlanner = value; NotifyPropertyChanged(); }
    }

    private string introExtroverted;
    public string IntroExtroverted
    {
      get => introExtroverted;
      set { introExtroverted = value; NotifyPropertyChanged(); }
    }

    private int confidenceLevel;
    public int ConfidenceLevel
    {
      get => confidenceLevel;
      set { confidenceLevel = value; NotifyPropertyChanged(); }
    }

    private int dedicationLevel;
    public int DedicationLevel
    {
      get => dedicationLevel;
      set { dedicationLevel = value; NotifyPropertyChanged(); }
    }

    private int ambitionLevel;
    public int AmbitionLevel
    {
      get => ambitionLevel;
      set { ambitionLevel = value; NotifyPropertyChanged(); }
    }

    private int guardStress;
    public int OpennessStress
    {
      get => guardStress;
      set { guardStress = value; NotifyPropertyChanged(); }
    }

    private int yieldStress;
    public int YieldStress
    {
      get => yieldStress;
      set { yieldStress = value; NotifyPropertyChanged(); }
    }

    private int anxietyStress;
    public int AnxietyStress
    {
      get => anxietyStress;
      set { anxietyStress = value; NotifyPropertyChanged(); }
    }

    private int opinionStress;
    public int OpinionStress
    {
      get => opinionStress;
      set { opinionStress = value; NotifyPropertyChanged(); }
    }

    private int braveryStress;
    public int BraveryStress
    {
      get => braveryStress;
      set { braveryStress = value; NotifyPropertyChanged(); }
    }

    private int leadershipStress;
    public int LeadershipStress
    {
      get => leadershipStress;
      set { leadershipStress = value; NotifyPropertyChanged(); }
    }

    private int mindsetStress;
    public int MindsetStress
    {
      get => mindsetStress;
      set { mindsetStress = value; NotifyPropertyChanged(); }
    }

    private int figuringStress;
    public int ThinkingStress
    {
      get => figuringStress;
      set { figuringStress = value; NotifyPropertyChanged(); }
    }

    private int externalStress;
    public int ExternalStress
    {
      get => externalStress;
      set { externalStress = value; NotifyPropertyChanged(); }
    }

    private bool cisgenderOnly = true;
    public bool CisgenderOnly
    {
      get => cisgenderOnly;
      set { cisgenderOnly = value; NotifyPropertyChanged(); }
    }

    public CharacterGeneratorViewModel()
    {
      GenerateCharacter();
    }

    private ICommand generateCharacterCommand;
    public ICommand GenerateCharacterCommand =>
      generateCharacterCommand ??= new CommandHandler(() => GenerateCharacter(), () => true);

    private void GenerateCharacter()
    {
      GenerateCharacterName();
      GenerateCharacterTraits();
    }

    private void GenerateCharacterName()
    {
      // TODO
    }

    private void GenerateCharacterTraits()
    {
      var tempCisgenderOnly = cisgenderOnly;
      if (!tempCisgenderOnly && FlipCoin())
      {
        var val = Mang.Utils.RandomNumber.Next(0, 10);
        if (val > 9)
        {
          Gender = "Androgyne";
        }
        else if (val > 7)
        {
          Gender = "Nonbinary";
        }
        else if (val > 5)
        {
          Gender = "Trans Male";
        }
        else if (val > 3)
        {
          Gender = "Trans Female";
        }
        else
        {
          tempCisgenderOnly = !tempCisgenderOnly;
        }
      }
      else
      {
        tempCisgenderOnly = !tempCisgenderOnly;
      }

      if (tempCisgenderOnly)
      {
        if (FlipCoin())
        {
          Gender = "Male";
        }
        else
        {
          Gender = "Female";
        }
      }
      Gender = FlipCoin() ? "Cisgender" : "Female";

      GuardedOptimistic = FlipCoin() ? "Guarded" : "Optimistic";
      DefiantCompliant = FlipCoin() ? "Defiant" : "Compliant";
      CarefreeWorried = FlipCoin() ? "Carefree" : "Worried";
      DecisiveAmbivalent = FlipCoin() ? "Decisive" : "Ambivalent";
      IntrepidInhibited = FlipCoin() ? "Intrepid" : "Inhibited";
      LeaderFollower = FlipCoin() ? "Leader" : "Follower";
      ProactiveDistractible = FlipCoin() ? "Proactive" : "Distractible";
      IntuitivePlanner = FlipCoin() ? "Intuitive" : "Planner";
      IntroExtroverted = FlipCoin() ? "Introverted" : "Extroverted";

      OpennessStress = Mang.Utils.RandomNumber.Next(0, 10);
      YieldStress = Mang.Utils.RandomNumber.Next(0, 10);
      AnxietyStress = Mang.Utils.RandomNumber.Next(0, 10);
      OpinionStress = Mang.Utils.RandomNumber.Next(0, 10);
      BraveryStress = Mang.Utils.RandomNumber.Next(0, 10);
      LeadershipStress = Mang.Utils.RandomNumber.Next(0, 10);
      MindsetStress = Mang.Utils.RandomNumber.Next(0, 10);
      ThinkingStress = Mang.Utils.RandomNumber.Next(0, 10);
      ExternalStress = Mang.Utils.RandomNumber.Next(0, 10);

      ConfidenceLevel = Mang.Utils.RandomNumber.Next(0, 10);
      DedicationLevel = Mang.Utils.RandomNumber.Next(0, 10);
      AmbitionLevel = Mang.Utils.RandomNumber.Next(0, 10);
    }

    private bool FlipCoin()
    {
      return Mang.Utils.RandomNumber.NextDouble() > 0.5;
    }
  }
}
