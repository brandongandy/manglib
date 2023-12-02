using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Controls;
using Mang;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ReactiveUI;
using Mang.Utils;

namespace MangXp.ViewModels;

public class MangViewModel : ViewModelBase
{
  private Dictionary<string, List<string>> markovLists;
  private string selectedNameType = string.Empty;

  private object? selectedSource = string.Empty;

  public object? SelectedSource
  {
    get => selectedSource;
    set
    {
      var selectedItem = ((ComboBoxItem)value!).Content as string ?? "";
      ToggleVisibilityFlags(selectedItem);
      this.RaiseAndSetIfChanged(ref selectedSource, value);
    } 
  }

  private object? selectedType;

  public object? SelectedType
  {
    get => selectedType;
    set
    {
      if (value is null)
      {
        // don't update; probably switching comboboxes
        return;
      }
      selectedNameType = ((ComboBoxItem)value!).Content as string ?? "";
      this.RaiseAndSetIfChanged(ref selectedType, value);
    }
  }

  private int ngramLength;

  public int NgramLength
  {
    get => ngramLength;
    set => this.RaiseAndSetIfChanged(ref ngramLength, value);
  }

  private int minimumWordLength;

  public int MinimumWordLength
  {
    get =>  minimumWordLength;
    set => this.RaiseAndSetIfChanged(ref minimumWordLength, value);
  }

  private int wordsToGenerate;

  public int WordsToGenerate
  {
    get => wordsToGenerate;
    set => this.RaiseAndSetIfChanged(ref wordsToGenerate, value);
  }

  private int markovIndex;

  public int MarkovIndex
  {
    get => markovIndex;
    set => this.RaiseAndSetIfChanged(ref markovIndex, value);
  }
  
  private string nameOutput = string.Empty;

  public string NameOutput
  {
    get => nameOutput;
    set => this.RaiseAndSetIfChanged(ref nameOutput, value);
  }

  public ReactiveCommand<Unit, Unit> GenerateCommand { get; }

  #region Visibility Toggles

  private bool isPlaceholderVisible = true;

  public bool IsPlaceholderVisible
  {
    get => isPlaceholderVisible;
    set => this.RaiseAndSetIfChanged(ref isPlaceholderVisible, value);
  }

  private bool isAmericaVisible;
  public bool IsAmericaVisible
  {
    get => isAmericaVisible;
    set => this.RaiseAndSetIfChanged(ref isAmericaVisible, value);
  }

  private bool isAncientWorldVisible;
  public bool IsAncientWorldVisible
  {
    get => isAncientWorldVisible;
    set => this.RaiseAndSetIfChanged(ref isAncientWorldVisible, value);
  }

  private bool isEastAsiaVisible;
  public bool IsEastAsiaVisible
  {
    get => isEastAsiaVisible;
    set => this.RaiseAndSetIfChanged(ref isEastAsiaVisible, value);
  }

  private bool isMedievalEuropeVisible;
  public bool IsMedievalEuropeVisible
  {
    get => isMedievalEuropeVisible;
    set => this.RaiseAndSetIfChanged(ref isMedievalEuropeVisible, value);
  }

  private bool isMiddleEastVisible;
  public bool IsMiddleEastVisible
  {
    get => isMiddleEastVisible;
    set => this.RaiseAndSetIfChanged(ref isMiddleEastVisible, value);
  }

  private bool isPacificVisible;
  public bool IsPacificVisible
  {
    get => isPacificVisible;
    set => this.RaiseAndSetIfChanged(ref isPacificVisible, value);
  }

  private bool isLovecraftVisible;
  public bool IsLovecraftVisible
  {
    get => isLovecraftVisible;
    set => this.RaiseAndSetIfChanged(ref isLovecraftVisible, value);
  }

  private bool isTolkienVisible;
  public bool IsTolkienVisible
  {
    get => isTolkienVisible;
    set => this.RaiseAndSetIfChanged(ref isTolkienVisible, value);
  }

  private void ToggleVisibilityFlags(string input)
  {
    IsPlaceholderVisible = input == "";
    IsAmericaVisible = input == "Americas";
    IsAncientWorldVisible = input == "Ancient World";
    IsEastAsiaVisible = input == "East Asia";
    IsMedievalEuropeVisible = input == "Medieval Europe";
    IsMiddleEastVisible = input == "Middle East";
    IsPacificVisible = input == "Pacific";
    IsLovecraftVisible = input == "Lovecraft";
    IsTolkienVisible = input == "Tolkien";
  }

  #endregion

  public MangViewModel()
  {
    NgramLength = 3;
    MinimumWordLength = 12;
    WordsToGenerate = 15;
    markovLists = ReflectionHelper.GetNameDictionary();
    GenerateCommand = ReactiveCommand.Create(
      GenerateNames);
  }

  public void GenerateNames()
  {
    var nameList = GetNameList();

    if (nameList is null)
    {
      return;
    }

    IMarkovGenerator markovGenerator = MarkovIndex switch
    {
      0 => new MangDefaultGenerator(nameList, NgramLength),
      1 => new MangUpdatedGenerator(nameList, NgramLength),
      _ => new MangUpdatedGenerator(nameList, NgramLength)
    };

    NameOutput = string.Empty;
    var sb = new StringBuilder();

    for (var i = 0; i < WordsToGenerate; i++)
    {
      sb.AppendLine(markovGenerator.GenerateWord(MinimumWordLength));
    }

    NameOutput = sb.ToString();
  }

  private IEnumerable<string>? GetNameList()
  {
    var parts = selectedNameType.Split(" ");

    List<string>? myList = null;

    if (parts.Length > 1)
    {
      _ = markovLists.TryGetValue($"{parts[0]}.{parts[1]}", out myList);
    }
    
    return myList;
  }
}

