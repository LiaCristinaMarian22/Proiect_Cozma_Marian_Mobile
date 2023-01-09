using System;
using Proiect_Cozma_Marian_Mobile.Data;
using System.IO;
namespace Proiect_Cozma_Marian_Mobile;

public partial class App : Application
{
    static MovieListDatabase database;
    public static MovieListDatabase Database
    {
        get
        {
            if (database == null)
            {
                database = new
               MovieListDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MovieList.db3"));
            }
            return database;
        }
    }

    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
