using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MangUi
{
  public class BindableBase : INotifyPropertyChanged
  {
    #region INotify Impl

    public event PropertyChangedEventHandler PropertyChanged;

    public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    #endregion
  }
}
