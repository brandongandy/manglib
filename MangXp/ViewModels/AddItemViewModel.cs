using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using MangXp.Models;
using ReactiveUI;

namespace MangXp.ViewModels;

public class AddItemViewModel : ViewModelBase
{
  private string description = string.Empty;

  public string Description
  {
    get => description;
    set => this.RaiseAndSetIfChanged(ref description, value);
  }

  public ReactiveCommand<Unit, ToDoItem> OkCommand { get; }

  public ReactiveCommand<Unit, Unit> CancelCommand { get; }

  public AddItemViewModel()
  {
    var isValidObservable = this.WhenAnyValue(
      x => x.Description,
      x => !string.IsNullOrWhiteSpace(x));

    OkCommand = ReactiveCommand.Create(
      () => new ToDoItem() { Description = Description }, isValidObservable);

    CancelCommand = ReactiveCommand.Create(() => { });
  }
}
