//

namespace DataLibrary.PersistenceModel
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using DataLibraryCore.Interfaces;

    public class BaseModel : IBaseModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}