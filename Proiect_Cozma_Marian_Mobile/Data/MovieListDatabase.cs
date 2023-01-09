using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proiect_Cozma_Marian_Mobile.Models;

namespace Proiect_Cozma_Marian_Mobile.Data
{
    public class MovieListDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public MovieListDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<MovieList>().Wait();
            _database.CreateTableAsync<Movie>().Wait();
            _database.CreateTableAsync<ListMovie>().Wait();
        }
        public Task<List<MovieList>> GetMovieListsAsync()
        {
            return _database.Table<MovieList>().ToListAsync();
        }
        public Task<MovieList> GetMovieListAsync(int id)
        {
            return _database.Table<MovieList>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveMovieListAsync(MovieList mlist)
        {
            if (mlist.ID != 0)
            {
                return _database.UpdateAsync(mlist);
            }
            else
            {
                return _database.InsertAsync(mlist);
            }
        }
        public Task<int> DeleteMovieListAsync(MovieList mlist)
        {
            return _database.DeleteAsync(mlist);
        }

        public Task<int> SaveMovieAsync(Movie movie)
        {
            if (movie.ID != 0)
            {
                return _database.UpdateAsync(movie);
            }
            else
            {
                return _database.InsertAsync(movie);
            }
        }
        public Task<int> DeleteMovieAsync(Movie movie)
        {
            return _database.DeleteAsync(movie);
        }
        public Task<List<Movie>> GetMoviesAsync()
        {
            return _database.Table<Movie>().ToListAsync();
        }

        public Task<int> SaveListMovieAsync(ListMovie listm)
        {
            if (listm.ID != 0)
            {
                return _database.UpdateAsync(listm);
            }
            else
            {
                return _database.InsertAsync(listm);
            }
        }
        public Task<List<Movie>> GetListMoviesAsync(int movielistid)
        {
            return _database.QueryAsync<Movie>(
            "select M.ID, M.Description from Movie M"
            + " inner join ListMovie LM"
            + " on M.ID = LM.MovieID where LM.MovieListID = ?",
            movielistid);
        }
    }
}
    

