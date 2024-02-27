using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.Federation.Movies
{
    public class Query
    {
        public IEnumerable<Movie> GetMovies() => new List<Movie>
        {
            new Movie { Id = 1, Title = "The Matrix" },
            new Movie { Id = 2, Title = "Star Wars Episode 1" }
        };
    }

    public class Movie
    {
        public int Id { get; set; }

        public string Title { get; set; }
    }
}
