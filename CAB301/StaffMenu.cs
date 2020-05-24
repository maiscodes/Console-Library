using System;
using System.Collections.Generic;
using System.Text;

namespace CAB301
{
    /// <summary>
    /// Class to load the Staff Menu.
    /// </summary>
    public class StaffMenu : Page
    {
        public MainMenu MainMenu { get; set; }
        public MemberCollection Members { get; set; }
        public MovieCollection Movies { get; set; }
        public readonly string display = @"
================== Staff Menu =================
1. Add a new movie DVD
2. Remove a movie DVD
3. Register a new Member
4. Find a registered member's phone number
0. Return to main menu
==============================================";

        public StaffMenu(MemberCollection members, MovieCollection movies)
        {
            Members = members;
            Movies = movies;
        }


        public override void Load()
        {
            Console.WriteLine(display);

            bool isInputValid = false;

            while (!isInputValid)
            {
                Console.Write("Please make a selection(1 - 5, or 0 to return to main menu): ");
                string input = Console.ReadLine();

                if (String.Equals(input, "1"))
                {
                    TryAddNewMovie();
                    //isInputValid = 
                }
                else if (String.Equals(input, "2"))
                {
                    //isInputValid = TryRemoveMovie();
                }
                else if (String.Equals(input, "3"))
                {
                    //isInputValid = TryRegisteringMmeber();
                }
                else if (String.Equals(input, "4"))
                {
                    //isInputValid = TryFindMemberPhoneDetails();
                }
                else if (String.Equals(input, "0"))
                {
                    Console.WriteLine("\nReturning to Main Menu...");
                    ReturnToMainMenu();
                }
            }
        }

        public void TryAddNewMovie()
        {
            //bool isInputValid = false;
            Console.Write("\nWhat is the name of the movie? "); // Movie name
            string inputMovieName = Console.ReadLine();

            Console.Write("Who is starred in this movie? "); // Actors
            string inputActors = Console.ReadLine();

            Console.Write("Who is the director(s) for this movie? "); // Director
            string inputDirectors = Console.ReadLine();

            bool isDurationValid = false;
            int duration = 0;
            while (!isDurationValid)
            {
                Console.Write("How long does this movie go for in minutes? "); // Duration
                string inputDuration = Console.ReadLine();
                isDurationValid = int.TryParse(inputDuration, out duration);

            }

            Console.WriteLine("What genre is this movie?\n Please make a selection between 1-9: ");
            Console.WriteLine("1. Adventure \n2. Animated \n3. Action \n4. Comedy \n5. Drama \n6. Family \n7. Other \n8. Sci-Fi \n9. Thriller");
            bool isGenreValid = false;
            int inputGenreNumber = 0;

            while (!isGenreValid)
            {
                Console.Write("How long does this movie go for in minutes? "); // Duration
                string inputGenre = Console.ReadLine();
                isGenreValid = int.TryParse(inputGenre, out inputGenreNumber);
                if (isGenreValid)
                {
                    isGenreValid = inputGenreNumber >= 1 && inputGenreNumber <= 9;
                }
            }


            //Movie movie1 = new Movie(movieNames[0], actorLists[0], directorNames[0], durations[0], genres[0], classifications[0], releaseDates[0]);

        }

        public void ReturnToMainMenu()
        {
            MainMenu.Load();
        }
    }

}
