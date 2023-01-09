using Proiect_Cozma_Marian_Mobile.Models;

namespace Proiect_Cozma_Marian_Mobile;

public partial class ListEntryPage : ContentPage
{
	public ListEntryPage()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetMovieListsAsync();
    }
    async void OnMovieListAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ListPage
        {
            BindingContext = new MovieList()
        });
    }
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new ListPage
            {
                BindingContext = e.SelectedItem as MovieList
            });
        }
    }

}