using MovieApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MovieApp.Controllers
{
    public class MoviesController : ApiController
    {
        public object MoviesByRandom { get; private set; }

        [HttpGet]

        public List<Movie> GetMovies()
        {
            MovieEntities ORM = new MovieEntities();

            return ORM.Movies.ToList();

        }


        [HttpGet]
        public List<Movie> GetMoviesByGenre(string genre)
        {

            MovieEntities ORM = new MovieEntities();

            return ORM.Movies.Where(x => x.Genre.ToLower() == genre.ToLower()).ToList();

            
        }
        [HttpGet]
        public Movie ListRandomMovie()
        {
            MovieEntities ORM = new MovieEntities();

            Random rand = new Random();


            return ORM.Movies.ToList()[rand.Next(ORM.Movies.Count())];
        }

        [HttpGet]
        public Movie ListRandomMoviesFromGenre(string genre)
        {
            MovieEntities ORM = new MovieEntities();

            Random rand = new Random();

            List<Movie> GenreList = ORM.Movies.Where(x => x.Genre.ToLower() == genre.ToLower()).ToList();


            return GenreList[rand.Next(GenreList.Count())];

        }

        public List<Movie> GetRandomMovieList(int length)
        {
            MovieEntities ORM = new MovieEntities();

            Random rand = new Random();

            List<Movie> movieList = ORM.Movies.ToList();
            List<Movie> randomList = new List<Movie>();
            int index = 0;
            while (length > index)
            {
                randomList.Add(movieList[rand.Next(movieList.Count)]);
                index++;
            }
            return randomList;
        }

        
        public List<Movie> ListMovieInfo(string title)
        {
            MovieEntities ORM = new MovieEntities();

            return ORM.Movies.Where(x => x.Info.ToString() == title.ToLower()).ToList();
        }




        /*  [HttpGet]
          public List<Movie> GetMoviesByRandom()
          {

              MovieEntities ORM = new MovieEntities();
              List<Movie> list = ORM.Movies.ToList();

              return list[MoviesByRandom.Next(list.Count)];

          }*/

    }
}
