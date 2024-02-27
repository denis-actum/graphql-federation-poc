namespace GraphQL.Federation.Persons
{
    public class Query
    {
        private static readonly IReadOnlyDictionary<int, List<Person>> _movieActors = new Dictionary<int, List<Person>>
        {
            [1] = new() { new Person() { Id = 101, Name = "Keanu Reeves" }, new Person() { Id = 102, Name = "Laurence Fishborn" } },
            [2] = new() { new Person() { Id = 101, Name = "Natalie Portman" }, new Person() { Id = 102, Name = "Yuen McGregor" } },
        };


        public MovieActors GetMovieActors(int movieId) => _movieActors.ContainsKey(movieId)
            ? new MovieActors { MovieId = movieId, Actors = _movieActors[movieId] }
            : new MovieActors { MovieId = movieId, Actors = [] };
    }

    public class MovieActors
    {
        public int MovieId { get; set; }

        public List<Person> Actors { get; set; }
    }

    public class Person
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
