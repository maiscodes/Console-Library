using System;
using System.Collections.Generic;
using System.Globalization;
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
                Console.Write("Please make a selection(1 - 4, or 0 to return to main menu): ");
                string input = Console.ReadLine();

                if (String.Equals(input, "1"))
                {
                    TryAddNewMovie();
                }
                else if (String.Equals(input, "2"))
                {
                    TryRemoveMovie();
                }
                else if (String.Equals(input, "3"))
                {
                    
                    TryRegisteringMember();
                }
                else if (String.Equals(input, "4"))
                {
                    TryFindMemberPhoneDetails();
                }
                else if (String.Equals(input, "0"))
                {
                    Console.WriteLine("\nReturning to Main Menu...");
                    ReturnToMainMenu();
                }
            }
        }

        /// <summary>
        /// Read and add a new movie to Movies.
        /// </summary>
        public void TryAddNewMovie()
        {
            Console.Write("\nWhat is the name of the movie? "); // Movie name
            string name = Console.ReadLine();

            Console.Write("Who is starred in this movie? "); // Actors
            string actors = Console.ReadLine();

            Console.Write("Who is the director(s) for this movie? "); // Director
            string directors = Console.ReadLine();

            bool isValidInput = false;
            int duration = 0;
            while (!isValidInput)
            {
                Console.Write("How long does this movie go for in minutes? "); // Duration
                string inputDuration = Console.ReadLine();
                isValidInput = int.TryParse(inputDuration, out duration);

            }

            // Now get Genre
            isValidInput = false;
            int inputGenreNumber = 0;
            string genre = "";
            while (!isValidInput) // Ensure a number between 1 and 9 is returned
            {
                Console.WriteLine("What genre is this movie?\nPlease make a selection between 1-9: ");
                Console.WriteLine("1. Adventure \n2. Animated \n3. Action \n4. Comedy \n5. Drama \n6. Family \n7. Other \n8. Sci-Fi \n9. Thriller");
                string inputGenre = Console.ReadLine();
                isValidInput = int.TryParse(inputGenre, out inputGenreNumber);
                if (isValidInput)
                {
                    isValidInput = inputGenreNumber >= 1 && inputGenreNumber <= 9;
                }
            }
            
            switch(inputGenreNumber) // Now convert the selection into a Genre
            {
                case 1:
                    genre = Genres.Adventure;
                    break;
                case 2:
                    genre = Genres.Animated;
                    break;
                case 3:
                    genre = Genres.Action;
                    break;
                case 4:
                    genre = Genres.Comedy;
                    break;
                case 5:
                    genre = Genres.Drama;
                    break;
                case 6:
                    genre = Genres.Family;
                    break;
                case 7:
                    genre = Genres.Other;
                    break;
                case 8:
                    genre = Genres.SciFi;
                    break;
                case 9:
                    genre = Genres.Thriller;
                    break;
            }

            // Now get classification
            isValidInput = false;
            string inputClassification = "";
            Classification classification = Classification.G;
            while (!isValidInput) 
            {

                Console.Write("What classification is this movie?\nPlease enter G, PG, M or MA: ");
                inputClassification = Console.ReadLine();

                isValidInput = (inputClassification == "G" || inputClassification == "PG" || inputClassification == "M" || inputClassification == "MA");
            }

            switch (inputClassification) // Now convert the selection into a Classification
            {
                case "G":
                    classification = Classification.G;
                    break;
                case "PG":
                    classification = Classification.PG;
                    break;
                case "M":
                    classification = Classification.M;
                    break;
                case "MA":
                    classification = Classification.MA;
                    break;

            }

            // Get release year
            isValidInput = false;
            int releaseDate = 0;
            while (!isValidInput)
            {
                Console.Write("What year was this movie released? ");
                string inputReleaseDate = Console.ReadLine();
                isValidInput = int.TryParse(inputReleaseDate, out releaseDate);
                if (isValidInput)
                {
                    isValidInput = releaseDate >= 1900 && releaseDate <= 3000;
                }
            }

            // Get number of copies 
            isValidInput = false;
            int copies = 1;
            while (!isValidInput)
            {
                Console.Write("Copies to be added: ");
                string inputReleaseDate = Console.ReadLine();
                isValidInput = int.TryParse(inputReleaseDate, out copies) && copies >= 1;
            }

            Movie movie = new Movie(name, actors, directors, duration, genre, classification, releaseDate, copies);
            Movies.AddNewDVD(movie);
            Console.WriteLine("{0} has been added to the system.", movie.Title);
        }

        public void ReturnToMainMenu()
        {
            MainMenu.Load();
        }

        /// <summary>
        /// Read and remove title from Movies.
        /// </summary>
        public void TryRemoveMovie()
        {
            Console.Write("\nWhat is the name of the movie you want to remove? ");
            string title = Console.ReadLine();
            try
            {
                bool isRemoved = Movies.RemoveDVD(title);
                if (isRemoved)
                {
                    Console.WriteLine("{0} removed from system.", title);
                }
                else
                {
                    Console.WriteLine("{0} could not be removed from system. Are you sure the movie title exists?", title);
                }
            }
            catch
            {
                Console.WriteLine("{0} could not be removed from system. Are you sure the movie title exists?", title);
            }
        }

        /// <summary>
        /// Read input to add a new member to MemberCollections.
        /// </summary>
        public void TryRegisteringMember()
        {
            Console.Write("\nWhat is this person's first name? "); 
            string firstName = Console.ReadLine();

            Console.Write("What is this person's last name? "); 
            string lastName = Console.ReadLine();

            Console.Write("Where does this person live? ");
            string address = Console.ReadLine();

            bool isValidInput = false;
            string contactNumber = "";
            while (!isValidInput)
            {
                Console.Write("What is this person's contact number? "); 
                contactNumber = Console.ReadLine();
                isValidInput = int.TryParse(contactNumber, out int mobileInteger);
            }

            isValidInput = false;
            string password = "";
            while (!isValidInput)
            {
                Console.Write("What is this person's password? "); // Movie name
                password = Console.ReadLine();
                isValidInput = int.TryParse(password, out int passwordInteger) && password.Length == 4;
            }

            Member member = new Member(firstName, lastName, address, contactNumber, password);
            bool isAdded = Members.AddNewMember(member);

            if (isAdded)
            {
                Console.WriteLine("{0} successfully added to the system.", member.GetUserName());
            }
            else
            {
                Console.WriteLine("{0} could not be added to the system. Are the number of members exceeding 10?", member.GetUserName());
            }
        }

        /// <summary>
        /// Display a member's contact details after the full name is entered.
        /// </summary>
        public void TryFindMemberPhoneDetails()
        {
            try
            {
                Console.Write("\nWhat is this person's full name? ");
                string fullName = Console.ReadLine();
                string[] names = fullName.Split(" ");
                string contactDetails = Members.GetMemberContactDetails(names[0], names[1]);
                if (contactDetails.Length > 0)
                {
                    Console.WriteLine("This member's mobile number is {0}", contactDetails);
                }
                else
                {
                    Console.WriteLine("Members contact details could not be found. Are you sure this member exists?");
                }
            }
            catch
            {
               Console.WriteLine("Invalid name provided. Please provide the fullname as the firstname and lastname separated by a space.");
            }

        }
    }

   

}
