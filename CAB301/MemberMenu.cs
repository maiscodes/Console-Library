using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CAB301
{
    /// <summary>
    /// Class to load and 
    /// </summary>
    public class MemberMenu
    {
        public MainMenu MainMenu { get; set; }
        public Member Member { get; set; }
        public MovieCollection Movies { get; set; }
        public readonly string display = @"
================== Member Menu =================
1. Display all movies
2. Borrow a movie DVD
3. Return a movie DVD
4. List current borrowed movie DVDs
5. Display top 10 most popular movies
0. Return to main menu
==============================================";

        public MemberMenu( MovieCollection movies)
        {
            Movies = movies;
        }


        public void Load(Member member)
        {
            this.Member = member;
            Console.WriteLine(display);
            bool isInputValid = false;

            while (!isInputValid)
            {
                
                Console.Write("Please make a selection(1 - 5, or 0 to return to main menu): ");
                string input = Console.ReadLine();

                if (String.Equals(input, "1"))
                {
                    Console.WriteLine("\n=============== All Movies ================");
                    Movies.DisplayAllMovies();
                }
                else if (String.Equals(input, "2"))
                {
                    BorrowMovie();
                }
                else if (String.Equals(input, "3"))
                {
                    ReturnMovie();
                }
                else if (String.Equals(input, "4"))
                {
                    DisplayCurrentlyBorrowedMovies();
                }
                else if (String.Equals(input, "5"))
                {
                    Console.WriteLine("\n============== Top 10 Movies ===============");
                    Movies.DisplayTopTenMovies();
                }
                else if (String.Equals(input, "0"))
                {
                    Console.WriteLine("\nReturning to Main Menu...");
                    ReturnToMainMenu();
                }
            }
        }

        /// <summary>
        /// Returns user to Main Menu screen.
        /// </summary>
        public void ReturnToMainMenu()
        {
            MainMenu.Load();
        }

        /// <summary>
        /// Gets user to enter a movie title to borrow.
        /// </summary>
        public void BorrowMovie()
        {
            Console.Write("\nWhat is the movie title? ");
            string title = Console.ReadLine();

            if (Member.IsAbleToBorrow(title))
            {
                Movie movie = Movies.BorrowMovie(title);
                if (movie != null)
                {
                    Member.BorrowMovie(movie);
                    Console.WriteLine("{0} has successfully borrowed {1}\n", Member.GetUserName(), title);
                }
                else
                {
                    Console.WriteLine("Member cannot borrow {0}. Movie is not available.\n", title);
                }
            }
            else
            {
                Console.WriteLine("Member is already borrowing {0} and cannot borrow another copy.\n", title);
            }
        }

        /// <summary>
        /// Gets user to enter a movie title to return.
        /// </summary>
        public void ReturnMovie()
        {
            Console.Write("\nWhat is the movie title? ");
            string title = Console.ReadLine();

            if (Member.HasMovie(title))
            {
                Movie movie = Movies.ReturnMovie(title);
                Member.ReturnsMovie(movie);
                Console.WriteLine("{0} has successfully returned {1}.\n", Member.GetUserName(), title);
            }
            else
            {
                Console.WriteLine("Movie is not currently being borrowed by member and cannot be returned.\n");
            }

        }

        /// <summary>
        /// Displays to user all movies they are currently borrowing.
        /// </summary>
        public void DisplayCurrentlyBorrowedMovies()
        {
            Console.WriteLine("\n=========== Currently Borrowing ============");
            ArrayList movies = Member.Movies; 
            foreach (Movie movie in movies)
            {
                movie.Show();
            }
        }
    }
}
