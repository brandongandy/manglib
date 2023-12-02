using Avalonia.Controls;
using MangXp.ViewModels;

namespace MangXp.Views;

public partial class MangView : UserControl
{
    public MangView()
    {
        DataContext = new MangViewModel();
        InitializeComponent();
    }
}