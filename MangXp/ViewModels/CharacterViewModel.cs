using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using Mang.Characters;
using ReactiveUI;

namespace MangXp.ViewModels;

public class CharacterViewModel : ViewModelBase
{
  public CharacterGenerator CharacterGenerator { get; set; }

  public ReactiveCommand<Unit, Unit> GenerateCharacterCommand { get; }

  private Character character = new();

  public Character Character
  {
    get => character;
    set => this.RaiseAndSetIfChanged(ref character, value);
  }

  public CharacterViewModel()
  {
    CharacterGenerator = new();
    Character = CharacterGenerator.GenerateCharacter();

    GenerateCharacterCommand = ReactiveCommand.Create(RegenerateCharacter);
  }

  private void RegenerateCharacter()
  {
    Character = CharacterGenerator.GenerateCharacter();
  }
}

