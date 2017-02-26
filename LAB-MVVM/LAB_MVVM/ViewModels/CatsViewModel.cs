using LAB_MVVM.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LAB_MVVM.ViewModels
{
    public class CatsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(
                [System.Runtime.CompilerServices.CallerMemberName]
                string propertyName = null) =>
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private bool Busy;
        public bool IsBusy
        {
            get
            {
                return Busy;
            }
            set
            {
                Busy = value;
                OnPropertyChanged();
                GetCatsCommand.ChangeCanExecute();
            }
        }
        public ObservableCollection<Cat> Cats { get; set; }
        public Command GetCatsCommand { get; set; }

        public CatsViewModel()
        {
            Cats = new ObservableCollection<Cat>();
            GetCatsCommand = new Command(async () => await GetCats(), () => !IsBusy);
        }
        async Task GetCats()
        {
            if(!IsBusy)
            {
                Exception Error = null;
                try
                {
                    IsBusy = true;
                    var repo = new Repository();
                    var items = await repo.GetCats();

                    Cats.Clear();
                    foreach (var item in items)
                    {
                        Cats.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    Error = ex;
                }
                finally
                {
                    IsBusy = false;
                }
                if (Error != null)
                {
                    await Xamarin.Forms.Application.Current.MainPage.DisplayAlert(
                    "Error!", Error.Message, "OK");
                }
            }
            return;
        }
    }
}
