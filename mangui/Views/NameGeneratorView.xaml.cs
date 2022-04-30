using MangUi.ViewModels;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;

namespace MangUi.Views
{
  /// <summary>
  /// Interaction logic for NameGeneratorView.xaml
  /// </summary>
  public partial class NameGeneratorView : UserControl
  {
    public NameGeneratorView()
    {
      InitializeComponent();
      DataContext = new NameGeneratorViewModel();
    }

    private static readonly Regex regex = new Regex("[^0-9.-]+");
    private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
    {
      e.Handled = regex.IsMatch(e.Text);
    }
  }
}
