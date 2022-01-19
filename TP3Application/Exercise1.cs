using System;
using System.Data.Common;
using System.Linq;
using System.Text.RegularExpressions;
using TP3;

namespace TP3Application
{
    public class Exercise1
    {
        public void launch()
        {
            var mcMovies = new MovieCollection().Movies;
            
            //Display the title of the oldest movie:
            Console.WriteLine("\n-------QUERY 1-------");
            var  query1=  mcMovies.OrderBy( movies => movies.ReleaseDate).First().Title; //Ascending orderBy
            Console.WriteLine(query1);
            
            // Count all movies.
            Console.WriteLine("\n-------QUERY 2-------");
            var query2 = mcMovies.Count();
            Console.WriteLine(query2);
            
            //Count all movies with the letter e. at least once in the title.
            Console.WriteLine("\n-------QUERY 3-------");
            var query3 = mcMovies.Where(movies => movies.Title.Contains("e") || movies.Title.Contains("E")).Count();
            Console.WriteLine(query3);

            //Count how many time the letter f is in all the titles from this list.
            Console.WriteLine("\n-------QUERY 4-------");
            int query4 = 0;
            foreach(var m in mcMovies)
            {
                query4 += m.Title.Count(c => c == 'f');
            }
            Console.WriteLine(query4);
            
            //Display the title of the film with the higher budget.
            Console.WriteLine("\n-------QUERY 5-------");
            var query5 = mcMovies.OrderByDescending(movies => movies.Budget).First().Title; 
            Console.WriteLine(query5);
            
            //Display the title of the movie with the lowest box office.
            Console.WriteLine("\n-------QUERY 6-------");
            var query6 = mcMovies.OrderBy(movies => movies.BoxOffice).First().Title;
            Console.WriteLine(query6);
            
            //Order the movies by reversed alphabetical order and print the first 11 of the list.
            Console.WriteLine("\n-------QUERY 7-------");
            var query7 = mcMovies.OrderByDescending(movies => movies.Title).Take(11);
            int counter = 1;
            foreach (var movie in query7)
            {
                Console.WriteLine(counter + ": " + movie.Title);
                counter++;
            }
            
            //Count all the movies made before 1980.
            Console.WriteLine("\n-------QUERY 8-------");
            DateTime date = new DateTime(1980,12,31);
            var query8 = mcMovies.Where(movies => movies.ReleaseDate < date).Count();
            Console.WriteLine(query8);
            
            //Display the average running time of movies having a vowel as the first letter.
            Console.WriteLine("\n-------QUERY 9-------");
            string vowels = "AEIOUY";
            var CountMovieWithVowel = mcMovies.Where(movies => vowels.Contains(movies.Title[0])).Count();
            var CountMovies = mcMovies.Count();

            var query9 = (CountMovieWithVowel / (float) CountMovies) * 100;
            Console.WriteLine(query9);
            
            // Print all movies with the letter H or W in the title, but not the letter I or T.
            Console.WriteLine("\n-------QUERY 10-------");
            var query10 = mcMovies.Where(movies => ((movies.Title.Contains("H") 
                                                     || movies.Title.Contains("W")) 
                                                     && (!movies.Title.Contains("I") 
                                                         || !movies.Title.Contains("T"))));
            foreach (var movie in query10)
            {
                Console.WriteLine(movie.Title);
            }
            
            //Calculate the mean of all Budget / Box Office of every movie ever
            Console.WriteLine("\n-------QUERY 11-------");
            var query11 = mcMovies.Select(movies => movies.Budget/movies.BoxOffice).Average();
            Console.WriteLine(query11);
            
            //OPTIONAL QUESTIONS
            
            //Group all films by the number of characters in the title screen and print the count of 
            //movies by letter in the film. 
            Console.WriteLine("\n-------QUERY 12-------");
            var query12 = mcMovies.Select(movies => movies).OrderBy(movies => movies.Title.Length).GroupBy(movies => movies.Title.Length);
            
            foreach (var movie in query12)
            {
                var query12bis = mcMovies.Select(movies => movies).Where(movies => movies.Title.Length == movie.Key).Count();
                Console.WriteLine(movie.Key + " : " + query12bis);
            }
            Console.WriteLine(query12);
            
            //Calculate the mean of all Budget / Box Office of every movie grouped by yearly release 
            //date
            Console.WriteLine("\n-------QUERY 13-------");
            var query13 = mcMovies.Select(movies => movies).GroupBy(movies => movies.ReleaseDate.Year);

            foreach (var group in query13)
            {
                var query13bis = mcMovies.Where(movies => movies.ReleaseDate.Year == group.Key).Select(movies => (float?)(movies.Budget / movies.BoxOffice)).Average();
                Console.WriteLine(group.Key + " : " + query13bis);
            }
        }
    }
}