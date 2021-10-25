using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SE214L22.Contract.DTOs
{
    public abstract class BaseDto : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string property = null, string value = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
