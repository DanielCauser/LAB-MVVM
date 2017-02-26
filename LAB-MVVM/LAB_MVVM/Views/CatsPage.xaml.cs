
using LAB_MVVM.Models;
using Xamarin.Forms;

namespace LAB_MVVM.Views
{
    public partial class CatsPage : ContentPage
    {
        public CatsPage()
        {
            InitializeComponent();
            ListViewCats.ItemSelected += ListViewCats_ItemSelected;
        }

        private async void ListViewCats_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var SelectedCat = (Cat)e.SelectedItem;
            if (SelectedCat != null)
            {
                await Navigation.PushAsync(new Views.DetailsPage(SelectedCat));
                ListViewCats.SelectedItem = null;
            }
        }
    }
}
