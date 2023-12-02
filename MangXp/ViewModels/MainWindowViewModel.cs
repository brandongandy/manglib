using System;
using System.Reactive.Linq;
using Avalonia.Controls;
using MangXp.Models;
using MangXp.Services;
using MangXp.Views;
using ReactiveUI;

namespace MangXp.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
  private ViewModelBase contentViewModel;

  public MangViewModel MangView { get; set; }

  public ViewModelBase ContentViewModel
  {
    get => contentViewModel;
    private set => this.RaiseAndSetIfChanged(ref contentViewModel, value);
    
  }

  public MainWindowViewModel()
  {
    //MangView = new MangViewModel();
    //contentViewModel = MangView;
  }

  public void SourceCombo_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
  {
    Console.WriteLine("foo");
  }

  //public void AddItem()
  //{
  //  AddItemViewModel addItemViewModel = new();

  //  _ = Observable.Merge(
  //      addItemViewModel.OkCommand,
  //      addItemViewModel.CancelCommand.Select(_ => (ToDoItem?)null))
  //    .Take(1)
  //    .Subscribe(newItem =>
  //    {
  //      if (newItem != null)
  //      {
  //        ToDoList.ListItems.Add(newItem);
  //      }
  //      ContentViewModel = ToDoList;
  //    });

  //  ContentViewModel = addItemViewModel;
  //}
}

