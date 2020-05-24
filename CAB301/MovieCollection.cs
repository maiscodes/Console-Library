using System;
using System.Collections.Generic;

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
                        isInserted = !isInserted;
                    }

                    if ( alphabeticalOrder == -1 ) // Change to sorting by totalBorrowed. movie.TotalBorrowed <= checkNode.Movie.TotalBorrowed
                    {
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
                    
                    if (alphabeticalOrder == 1)
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

        /// <summary>
        /// Given a child node, the parent node it belongs to is returned.
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="node"></param>
        /// <returns></returns>
        public Node FindParentNode(Node parent, Node node)
        {
            int alphabeticalOrder = string.Compare(node.Movie.Title, parent.Movie.Title);

            if (alphabeticalOrder == -1) // Means if parent then should be on the leftnode. 
            {
                if (parent.LeftNode == node)
                {
                    return parent;
                }
                else
                {
                    return FindParentNode(parent.LeftNode, node);
                }
            }

            if (alphabeticalOrder == 1) // Means if parent then should be on the rightnode. 
            {
                if (parent.RightNode == node)
                {
                    return parent;
                }
                else
                {
                    return FindParentNode(parent.RightNode, node);
                }
            }

            return null;

        }

        /// <summary>
        /// Given a parent node and its child node, the left or right pointer is removed.
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="node"></param>
        /// <returns></returns>
        public Node RemoveParentPointer(Node parent, Node node)
        {

            if (parent == null) // Means Root
            {
                return new Node();
            }

            int alphabeticalOrder = string.Compare(node.Movie.Title, parent.Movie.Title);

            if (alphabeticalOrder == -1) // Means if parent then should be on the leftnode. 
            {
               
                parent.LeftNode = null;
            }

            if (alphabeticalOrder == 1) // Means if parent then should be on the rightnode. 
            {
                parent.RightNode = null;
            }
          
            return parent;

        }
        public Node RemoveDVD(string title)
        {
            // Get node
            Node node = this.FindNode(Root, title);
            Node parent = this.FindParentNode(Root, node);

            List<Movie> displacedLeftMovies = new List<Movie>();
            if (node.LeftNode != null)
            {
                displacedLeftMovies = this.GetAlphabeticalListOfMovies(node.LeftNode, displacedLeftMovies);
            }
           
            List<Movie> displacedRightMovies = new List<Movie>();
            if (node.RightNode != null)
            {
                displacedRightMovies = this.GetAlphabeticalListOfMovies(node.RightNode, displacedRightMovies);
            }

            // Remove pointer 
            this.RemoveParentPointer(parent, node);

            // Traverse through the left node. 
            foreach (Movie movie in displacedLeftMovies)
            {
                this.AddNewDVD(movie);
            }

            // Traverse through the right node. 
            foreach (Movie movie in displacedRightMovies)
            {
                this.AddNewDVD(movie);
            }

            return Root;
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
            Movie movie = this.FindNode(Root, title).Movie;
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
            Movie movie = this.FindNode(Root, title).Movie; 
            movie.IncrementDVDCount();
        }

        /// <summary>
        /// Return the alphabetical order of movies by performing an inorder traversal. Make into aray.
        /// </summary>
        /// <param name="parent"></param>
        public List<Movie> GetAlphabeticalListOfMovies(Node parent, List<Movie> movieList)
        {
            if (parent.Movie != null) // Node has a movie and possibly movies in the left and/or right node
            {
                if (parent.LeftNode != null ) 
                {
                    GetAlphabeticalListOfMovies(parent.LeftNode, movieList);
                }

                movieList.Add(parent.Movie); // Add each movie to the list

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
                movie.ToString();
            }
        }

        /// <summary>
        /// Given the movie list to sort and the number of movies to return. 
        /// </summary>
        /// <param name="movieList"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public Movie[] GetTopMovies(List<Movie> movieList, int max)
        {
            Movie[] movieArray = movieList.ToArray();

            movieArray = MergeSort(movieArray);

            Movie[] topMovies = new Movie[max];

            for (int m = 0; m < movieArray.Length; m++)
            {
                topMovies[m] = movieArray[m];
            }

            return topMovies;
        }


        public Movie[] MergeSort(Movie[] unsorted)
        {
            if (unsorted.Length <= 1)
            {
                return unsorted;
            }

            int middle = unsorted.Length / 2;
            Movie[] leftMovies = new Movie[middle];
            Movie[] rightMovies = new Movie[unsorted.Length - middle];

            for (int m = 0; m < middle; m++)
            {
                leftMovies[m] = unsorted[m];
            }

            for (int m = 0; m < unsorted.Length - middle; m++)
            {
                rightMovies[m] = unsorted[m + middle];
            }

            leftMovies = MergeSort(leftMovies);
            rightMovies = MergeSort(rightMovies);
            return Merge(leftMovies, rightMovies);
           
        }

        public Movie[] Merge(Movie[] left, Movie[] right)
        {
            int leftStart = 0;
            int rightStart = 0;
            int mergedStart = 0;
            Movie[] sortedMovies = new Movie[left.Length + right.Length];

            while (leftStart < left.Length && rightStart < right.Length)
            {
                if (left[leftStart] != null && right[rightStart] != null)
                {
                    if (left[leftStart].TotalBorrowed >= right[rightStart].TotalBorrowed)
                    {
                        sortedMovies[mergedStart] = left[leftStart];
                        leftStart++;
                    }
                    else
                    {
                        sortedMovies[mergedStart] = right[rightStart];
                        rightStart++;
                    }
                    mergedStart++;
                }
                else
                {
                    if (right[rightStart] != null) 
                    {
                        sortedMovies[mergedStart] = right[rightStart];
                        mergedStart++;
                    }

                    else if (left[leftStart] != null) 
                    {
                        sortedMovies[mergedStart] = left[leftStart];
                        mergedStart++;
                    }
                    leftStart++;
                    rightStart++;
                }
            }

            if (leftStart < left.Length) // Add remaining movies.
            {
                for (int m = leftStart; m < left.Length; m ++)
                {
                    sortedMovies[mergedStart] = left[m];
                    mergedStart++;
                }
            }

            if (rightStart < right.Length)
            {
                for (int m = rightStart; m < right.Length; m++)
                {
                    sortedMovies[mergedStart] = right[m];
                    mergedStart++;
                }
            }
           
            return sortedMovies;
        }

        /// <summary>
        /// Write movie rankings to console. 
        /// </summary>
        /// <param name="movieList"></param>
        public void DisplayRankedMovies(Movie[] movieList)
        {
            int count = 1;
            foreach (Movie movie in movieList)
            {
                if (movie != null)
                {
                    Console.WriteLine("{0}. {1}", count, movie.Title);
                }
                else
                {
                    Console.WriteLine("{0}. ", count);
                }
                count++;
            }
        }

        /// <summary>
        /// Write the top ten movies on console.
        /// </summary>
        public void DisplayTopTenMovies()
        {
            List<Movie> allMovies = new List<Movie>();

            // Get all the movies into an array. 
            allMovies = GetAlphabeticalListOfMovies(Root, allMovies);

            Movie[] topMovies = GetTopMovies(allMovies, 10);

            DisplayRankedMovies(topMovies);
        }

    }
}
