using Avalonia.Controls;
using MangXp.ViewModels;

namespace MangXp.Views;

public partial class CharacterView : UserControl
{
    public CharacterView()
    {
        DataContext = new CharacterViewModel();
        InitializeComponent();
    }
}