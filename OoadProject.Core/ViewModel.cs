
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace OoadProject.Core
{
    public class ViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string property = null, string value = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
