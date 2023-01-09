using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;


namespace Proiect_Cozma_Marian_Mobile.Models
{
    public class ListMovie
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [ForeignKey(typeof(MovieList))]
        public int MovieListID { get; set; }
        public int MovieID { get; set; }

    }
}
