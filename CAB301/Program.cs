using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Runtime.CompilerServices;

namespace CAB301
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // Today:
            // Binary tree, balancing out,  testing it, library console application hioerarchy and setup. 
            // Library
            // HomePage just provide functions and the library will control everything?
            // MemberMenuPage(member)
            // StaffMenuPage() just provide functions.
            string[] movieNames = new string[] { "a movie1", "k movie2", "c movie3", "g movie1", "s movie2", "d movie3" };
            string[] directorNames = new string[] { "director1", "director2", "director3", "director1", "director2", "director3" };
            string[] genres = new string[] { Genres.Action, Genres.SciFi, Genres.Drama, Genres.Action, Genres.SciFi, Genres.Drama };
            int[] durations = new int[] { 123, 124, 125, 123, 124, 125 };
            string[] classifications = new string[] { Classifications.General, Classifications.General, Classifications.General, Classifications.General, Classifications.General, Classifications.General };
            DateTime[] releaseDates = new DateTime[] { new DateTime(2019, 06, 23), new DateTime(2019, 06, 23), new DateTime(2019, 06, 23), new DateTime(2019, 06, 23), new DateTime(2019, 06, 23), new DateTime(2019, 06, 23) }; 
            ArrayList[] actorLists = new ArrayList[] { new ArrayList() { "James Cordon", "Shawn Mendes" }, new ArrayList() { "James Cordon", "Shawn Mendes" }, new ArrayList() { "James Cordon", "Shawn Mendes" }, new ArrayList() { "James Cordon", "Shawn Mendes" }, new ArrayList() { "James Cordon", "Shawn Mendes" }, new ArrayList() { "James Cordon", "Shawn Mendes" } };
            ArrayList movies = new ArrayList();

            Movie movie1 = new Movie(movieNames[0], actorLists[0], directorNames[0], durations[0], genres[0], classifications[0], releaseDates[0]);
            Movie movie2 = new Movie(movieNames[1], actorLists[1], directorNames[1], durations[1], genres[1], classifications[1], releaseDates[1]);
            Movie movie3 = new Movie(movieNames[2], actorLists[2], directorNames[2], durations[2], genres[2], classifications[2], releaseDates[2]);
            Movie movie4 = new Movie(movieNames[3], actorLists[3], directorNames[3], durations[3], genres[3], classifications[3], releaseDates[3]);
            Movie movie5 = new Movie(movieNames[4], actorLists[4], directorNames[4], durations[4], genres[4], classifications[4], releaseDates[4]);
            Movie movie6 = new Movie(movieNames[5], actorLists[5], directorNames[5], durations[5], genres[5], classifications[5], releaseDates[5]);

            movies.Add(movie1);
            movies.Add(movie2);
            movies.Add(movie3);
            movies.Add(movie4);
            movies.Add(movie5);
            movies.Add(movie6);

            //for (int i = 0; i < movieNames.Length; i++)
            //{
            //  Movie m = new Movie(movieNames[i], actorLists[i], directorNames[i], durations[i], genres[i], classifications[i], releaseDates[i]);
            //movies.Append(m);
            //}

            // Testing Movie Class

            string movieName = "Example Movie";
            string director = "Mickey Mouse";
            string genre = Genres.Action;
            int duration = 124;
            string classification = Classifications.General;
            DateTime releaseDate = new DateTime(2019, 06, 23);
            ArrayList actors = new ArrayList() { "James Cordon", "Shawn Mendes" };
            Movie movie = new Movie(movieName, actors, director, duration, genre, classification, releaseDate);
            Console.WriteLine("Current Movie Count should be 1: {0} and total borrowed should be {1}", movie.TotalDvds, movie.TotalBorrowed);
            movie.IncrementDVDCount();
            Console.WriteLine("Should now be 2 {0}", movie.TotalDvds);
            movie.DecreaseDVDCount();
            movie.DecreaseDVDCount();
            Console.WriteLine("Movie availability should now be FALSE: {0}", movie.IsAvailable());


            // Testing Member Class
            string firstName = "John";
            string lastName = "Smith";
            string address = "15 Woolly St";
            string contactNumber = "0405852561";
            string password = "1234";
            Member member = new Member(firstName, lastName, address, contactNumber, password);
            Console.WriteLine("Member should be able to borrow movie: TRUE: {0}", member.IsAbleToBorrow(movie));
            member.BorrowMovie(movie);
            movie.DecreaseDVDCount();
            Console.WriteLine("Movie should not be able to borrow movie anymore: FALSE: {0}", member.IsAbleToBorrow(movie));

            // Testing MemberCollections class
            MemberCollection memberList = new MemberCollection();
            memberList.AddNewMember(firstName, lastName, address, contactNumber, password);
            Console.WriteLine("Member count should be 1: {0}", memberList.MemberCount);
            string memberContact = memberList.GetMemberContactDetails("John", "Smith");
            Console.WriteLine("Member number should be 0405852561 {0}", memberContact);
            memberContact = memberList.GetMemberContactDetails("JohnX", "Smith");
            Console.WriteLine("Member number should be nothing {0}", memberContact);

            // Test Binary Tree
            MovieCollection movieCollection = new MovieCollection();

            //movieCollection.AddDVD(movie);
            foreach (Movie moviee in movies)
            {
               movieCollection.AddNewDVD(moviee);
            }

            movieCollection.AddNewDVD(movie1);
            movieCollection.AddNewDVD(movie2);


            List<Movie> alphabeticMovies = new List<Movie>();
            alphabeticMovies = movieCollection.GetAlphabeticalListOfMovies(movieCollection.Root, alphabeticMovies);
            
            foreach (Movie amovie in alphabeticMovies)
            {
                Console.WriteLine(amovie.Title);

            }

            // Test Movie Collection
            movieCollection.DisplayAllMovies();
            movieCollection.BorrowMovie("k movie2");
            movieCollection.DisplayAllMovies();
            movieCollection.ReturnMovie("k movie2");
            movieCollection.DisplayAllMovies();
            //movieCollection.RemoveDVD("k movie2");
            //movieCollection.DisplayAllMovies();
            //movieCollection.RemoveDVD("d movie3");
            //movieCollection.DisplayAllMovies();

            // Test sort function. 
            movieCollection.BorrowMovie("a movie1");
            movieCollection.ReturnMovie("a movie1");
            movieCollection.BorrowMovie("a movie1");
            movieCollection.ReturnMovie("a movie1");
            movieCollection.BorrowMovie("a movie1");
            movieCollection.ReturnMovie("a movie1");
            movieCollection.BorrowMovie("a movie1");
            movieCollection.ReturnMovie("a movie1");
            movieCollection.BorrowMovie("k movie2");
            movieCollection.ReturnMovie("k movie2");
            movieCollection.BorrowMovie("k movie2");
            movieCollection.ReturnMovie("k movie2");
            movieCollection.BorrowMovie("c movie3");
            movieCollection.ReturnMovie("c movie3");
            movieCollection.BorrowMovie("c movie3");
            movieCollection.ReturnMovie("c movie3");
            movieCollection.BorrowMovie("c movie3");
            movieCollection.ReturnMovie("c movie3");
            movieCollection.BorrowMovie("c movie3");
            movieCollection.ReturnMovie("c movie3");
            movieCollection.BorrowMovie("s movie2");
            movieCollection.ReturnMovie("s movie2");
            movieCollection.BorrowMovie("s movie2");
            movieCollection.ReturnMovie("s movie2");
            movieCollection.BorrowMovie("s movie2");
            movieCollection.ReturnMovie("s movie2");
            movieCollection.BorrowMovie("s movie2");
            movieCollection.ReturnMovie("s movie2");
            movieCollection.BorrowMovie("s movie2");
            movieCollection.ReturnMovie("s movie2");
            movieCollection.BorrowMovie("s movie2");
            movieCollection.ReturnMovie("s movie2");
            movieCollection.BorrowMovie("s movie2");
            movieCollection.ReturnMovie("s movie2");
            movieCollection.RemoveDVD("s movie2");
            movieCollection.DisplayTopTenMovies();

            // Test staff and mainmenu 
            Staff staff = new Staff("staff", "today123");
            MemberCollection members = new MemberCollection();
            members.AddNewMember("Maisie", "Vuong", "Dibley", "1234", "1234");

            MainMenu mainMenu = new MainMenu(members, staff);
            mainMenu.Load();

            // TESTCASES for MAINMENU
            // If anything else than 1,2,0 then repeat loop

            // If correct staff then print 
            // if incorrect staff, say and then repeat loop 

            //if correct member then print, 
            // if incorrect member, say and then repeat loop




            Console.WriteLine("Hello World!");
        }
    }
}
