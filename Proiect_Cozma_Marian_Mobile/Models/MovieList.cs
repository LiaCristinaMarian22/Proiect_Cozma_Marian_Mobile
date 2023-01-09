using System;
using System.Collections.Generic;
using System.Linq;
using SQLite;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_Cozma_Marian_Mobile.Models
{
    public class MovieList
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string   Name { get; set; }
        public string Director { get; set; }
        public string Actor { get; set; }
        [MaxLength(250), Unique]
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }

    }
}
