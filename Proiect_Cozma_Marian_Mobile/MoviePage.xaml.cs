using Proiect_Cozma_Marian_Mobile.Models;

namespace Proiect_Cozma_Marian_Mobile;

public partial class MoviePage : ContentPage
{
    MovieList ml;
    public MoviePage(MovieList mlist)
    {
        InitializeComponent();
        ml = mlist;
    }

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var movie = (Movie)BindingContext;
        await App.Database.SaveMovieAsync(movie);
        listView.ItemsSource = await App.Database.GetMoviesAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var movie = (Movie)BindingContext;
        await App.Database.DeleteMovieAsync(movie);
        listView.ItemsSource = await App.Database.GetMoviesAsync();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetMoviesAsync();
    }

    async void OnAddButtonClicked(object sender, EventArgs e)
    {
        Movie m;
        if (listView.SelectedItem != null)
        {
            m = listView.SelectedItem as Movie;
            var lm = new ListMovie()
            {
                MovieListID = ml.ID,
                MovieID = m.ID
            };
            await App.Database.SaveListMovieAsync(lm);
            m.ListMovies = new List<ListMovie> { lm };
            await Navigation.PopAsync();
        }

    }
}