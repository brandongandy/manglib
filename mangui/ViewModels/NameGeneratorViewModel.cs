using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Mang;
using Mang.Utils;

namespace MangUi.ViewModels
{
  public class NameGeneratorViewModel : BindableBase
  {
    private Dictionary<string, List<string>> markovLists;
    private IMarkovGenerator markovGenerator;

    private string selectedSource;
    public string SelectedSource
    {
      get => selectedSource;
      set { selectedSource = value; NotifyPropertyChanged(); }
    }

    private string selectedType;
    public string SelectedType
    {
      get => selectedType;
      set { selectedType = value; NotifyPropertyChanged(); }
    }

    private ObservableCollection<string> generators;
    public ObservableCollection<string> Generators
    {
      get => generators;
      set { generators = value; NotifyPropertyChanged(); }
    }

    private ObservableCollection<string> output;
    public ObservableCollection<string> Output
    {
      get => output;
      set { output = value; NotifyPropertyChanged(); }
    }

    private string selectedGenerator;
    public string SelectedGenerator
    {
      get => selectedGenerator;
      set { selectedGenerator = value; NotifyPropertyChanged(); }
    }

    private int ngramLength;
    public int NgramLength
    {
      get => ngramLength;
      set { ngramLength = value; NotifyPropertyChanged(); }
    }

    private int minWordLength;
    public int MinWordLength
    {
      get => minWordLength;
      set { minWordLength = value; NotifyPropertyChanged(); }
    }

    public NameGeneratorViewModel()
    {
      InitializeMangData();
    }

    private void InitializeMangData()
    {
      Output = new ObservableCollection<string>();

      Generators = new ObservableCollection<string>
      {
        "Mang Default",
        "Pseudo v1"
      };

      NgramLength = 3;
      MinWordLength = 12;

      SelectedSource = "Americas";
      SelectedType = "Aztec Male Names";
      SelectedGenerator = "Pseudo v1";

      markovLists = ReflectionHelper.GetNameDictionary();
    }

    #region Command

    private ICommand clickCommand;
    public ICommand ClickCommand =>
      clickCommand ??= new CommandHandler(() => GenerateNames(), () => true);

    public void GenerateNames()
    {
      var input = DetermineListType();

      if (input == null)
      {
        return;
      }

      Output.Clear();
      for (int i = 0; i < 15; i++)
      {
        Output.Add(GenerateWord(input, NgramLength));
      }
    }

    private IEnumerable<string> DetermineListType()
    {
      var parts = SelectedType.Split(" ");

      if (markovLists.TryGetValue($"{parts[1]}.{parts[2]}", out var myList))
      {
        return myList;
      }

      return null;
    }

    private string GenerateWord(IEnumerable<string> input, int ngramLength)
    {
      markovGenerator = SelectedGenerator switch
      {
        "Mang Default" => new MarkovData(input, ngramLength),
        "Pseudo v1" => new PseudoWordGenerator(input, ngramLength),
        _ => new PseudoWordGenerator(input, ngramLength),
      };
      return markovGenerator?.GenerateWord(MinWordLength);
    }

    #endregion
  }
}
