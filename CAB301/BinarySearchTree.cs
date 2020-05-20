using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CAB301
{
    /// <summary>
    /// Binary search tree containing movies ordered by alphabetical order. TODO: FIXX tomorrow/Friday.
    /// </summary>
    class MovieCollection
    {
        public Node Root { get; set; }

        public MovieCollection()
        {
            Root = new Node();
        }

        /// <summary>
        /// Add a new DVD to the library.
        /// </summary>
        /// <param name="movie"></param>
        public void AddNewDVD(Movie movie)
        {
            Node checkNode = Root;

            bool isInserted = false;

            while( !isInserted )
            {
                if ( checkNode.Movie != null )
                {
                    int alphabeticalOrder = string.Compare(movie.Title, checkNode.Movie.Title);

                    if  ( alphabeticalOrder == 0 ) // Already existing title. 
                    {
                        checkNode.Movie.IncrementDVDCount(); 
                    }

                    if ( alphabeticalOrder == -1 ) // Change to sorting by totalBorrowed. movie.TotalBorrowed <= checkNode.Movie.TotalBorrowed
                    {
                        // If total numbers are equal- can still be sorted by alpabet. 
                        //      if alphabet is less then then assing left. 
                        //      if equal: check what's on both sides. 
                                    
                        //      if after then ssing right.

                        if ( checkNode.LeftNode == null ) // Put the movie in the left node or use as base
                        {
                            checkNode.LeftNode = new Node();
                            checkNode.LeftNode.Movie = movie;
                            isInserted = !isInserted;
                        }
                        else
                        {
                            checkNode = checkNode.LeftNode;
                        }

                    }
                    else
                    {
                        if ( checkNode.RightNode == null ) // Put the movie into the right node or use as a base
                        {
                            checkNode.RightNode = new Node();
                            checkNode.RightNode.Movie = movie;
                            isInserted = !isInserted;

                        }
                        else
                        {
                            checkNode = checkNode.RightNode;
                        }

                    }

                }
                else
                {
                    checkNode.Movie = movie;
                    isInserted = !isInserted;
                }

            }

        }

        // RemoveDVD()
        public void RemoveDVD(string title)
        {
            // Get node. 

            // Remove connection. 

            // Traverse through the left node. 

            // Traverse through the righ node. 
            


            // Remove and redistribute all its movies in tree. 
            // 
        }

        /// <summary>
        /// Given the movie title, return the correpsonding node. 
        /// </summary>
        /// <param name="title"></param>
        /// <param name="parent"></param>
        public Node FindNode(Node parent, string title)
        {
            int order = string.Compare(title, parent.Movie.Title);

            if (order == 0) // Title matches.
            {
                return parent;
            }

            if (order == -1) // Means value can be found in left node 
            {
                return FindNode(parent.LeftNode, title);
                
            }

            if (order == 1) // Means value can be found in the right node. 
            {
                return FindNode(parent.RightNode, title);
            }

            return null;
        }
        
        /// <summary>
        /// Given the title of the movie the DVD number is decreased.
        /// TODO: REVISE Move the alpahetical list. IsAvailable could be fixed - once brought together and
        /// worked out how the console works. Alphabetical evertime new movie is added.
        /// </summary>
        /// <param name="movie"></param>
        public void BorrowMovie(string title)
        {
            List<Movie> movies = new List<Movie>();
            movies = this.GetAlphabeticalListOfMovies(Root, movies);
            Movie movie = this.GetMovie(title, movies, 0, movies.Count - 1);

            if (movie.IsAvailable())
            {
                movie.DecreaseDVDCount();
                movie.IncrementBorrowedCount();
            }

        }

        /// <summary>
        /// Given the title of a movie the DVD number is increased.
        /// </summary>
        /// <param name="title"></param>
        public void ReturnMovie(string title)
        {
            List<Movie> movies = new List<Movie>();
            movies = this.GetAlphabeticalListOfMovies(Root, movies);
            Movie movie = this.GetMovie(title, movies, 0, movies.Count - 1);
            movie.IncrementDVDCount();
        }

        /// <summary>
        /// Return movie using binary search. 
        /// </summary>
        /// <param name="title"></param>
        /// <param name="alphabeticalMovies"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        private Movie GetMovie(string title, List<Movie> alphabeticalMovies, int left, int right)
        {
            if ( right >= left )
            {
                int middle = left + (right - 1) / 2;

                if (alphabeticalMovies[middle].Title == title)
                {
                    return alphabeticalMovies[middle];
                }

                int alphabeticalOrder = string.Compare(alphabeticalMovies[middle].Title, title);

                // If title exists before
                if (alphabeticalOrder == -1)
                { 
                    return GetMovie(title, alphabeticalMovies, left, right - 1);
                }

                // If title exists after
                if (alphabeticalOrder == 1)
                {
                    return GetMovie(title, alphabeticalMovies, left + 1, right);
                }
            }

            return null;
            
        }

        /// <summary>
        /// Return the alphabetical order of movies by performing an inorder traversal.
        /// </summary>
        /// <param name="parent"></param>
        public List<Movie> GetAlphabeticalListOfMovies(Node parent, List<Movie> movieList)
        {
            // Return list of ascending order
            if (parent.Movie != null)
            {
                if (parent.LeftNode != null )
                {
                    GetAlphabeticalListOfMovies(parent.LeftNode, movieList);
                }

                movieList.Add(parent.Movie);

                if (parent.RightNode != null)
                {
                    GetAlphabeticalListOfMovies(parent.RightNode, movieList);
                }

            }
            return movieList;
        }


        /// <summary>
        /// Display the information for every movie in the library. Move out. 
        /// </summary>
        public void DisplayAllMovies()
        {
            string titleSeparator = "==================================================";
            List<Movie> movies = new List<Movie>();
            movies = this.GetAlphabeticalListOfMovies(Root, movies);

            Console.WriteLine(titleSeparator);
            Console.WriteLine("All Movies");
            Console.WriteLine(titleSeparator);

            foreach (Movie movie in movies)
            {
                string actorList = "";
                for(int a = 0; a < movie.Actors.Count; a++)
                {
                    actorList += movie.Actors[a];
                    if ( a < movie.Actors.Count - 1 )
                    {
                        actorList += ", ";
                    }
                }
 
                Console.WriteLine("TITLE: {0} (released {1})", movie.Title, movie.ReleaseDate.ToString("MM/dd/yyyy"));
                Console.WriteLine("\tA movie directed by {0}, starring the actors: {1}.", movie.Director, actorList);
                Console.WriteLine("\tGenre: {0}. Classification: {1}. Duration: {2} minutes. DVDs available: {3}.", movie.Genre, movie.Classification, movie.Duration, movie.TotalDvds);
                Console.WriteLine("\n");
            }
        }

        // GetTopTen()
        // Traverse, sort, return information on top 10. 

        // AddDVD
        // Convert binary tree to array 
        // sort array
        // check if array is equal to sorted array 
        // convert sorted array to balanced tree.
        // Find 
        // convert to array 
        // work backwards (most popular)
        // Traverse Whatever order is in highest to lowest. 
        // convert to array. from smallest to biggest.
        // sort
        // work backwards. 
    }
}
