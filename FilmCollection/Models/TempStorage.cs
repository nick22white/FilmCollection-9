using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmCollection.Models
{
    public class TempStorage
    {
        //Creates list of movies
        private static List<NewMovie> movies = new List<NewMovie>();

        //Iteration
        public static IEnumerable<NewMovie> Movies => movies;

        //Adds movie object to the list
        public static void AddApplication(NewMovie movie)
        {
            movies.Add(movie);
        }
    }
}
