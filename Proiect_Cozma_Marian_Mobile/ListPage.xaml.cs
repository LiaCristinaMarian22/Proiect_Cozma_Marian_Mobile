using Proiect_Cozma_Marian_Mobile.Models;

namespace Proiect_Cozma_Marian_Mobile;
public partial class ListPage : ContentPage
{
	public ListPage()
	{
		InitializeComponent();
	}
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var mlist = (MovieList)BindingContext;
        mlist.ReleaseDate = DateTime.UtcNow;
        await App.Database.SaveMovieListAsync(mlist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var mlist = (MovieList)BindingContext;
        await App.Database.DeleteMovieListAsync(mlist);
        await Navigation.PopAsync();
    }

    async void OnChooseButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MoviePage((MovieList)
       this.BindingContext)
        {
            BindingContext = new Movie()
        });

    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var moviel = (MovieList)BindingContext;

        listView.ItemsSource = await App.Database.GetListMoviesAsync(moviel.ID);
    }

}