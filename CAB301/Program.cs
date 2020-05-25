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
            /*
             // Create the Data Structures
            
             Staff staff = new Staff("staff", "today123");
             MemberCollection members = new MemberCollection();
             Member member = new Member("Maisie", "Vuong", "Dibley", "1234", "1234");
             members.AddNewMember(member);
             MovieCollection movieCollection = new MovieCollection();
             Movie inuyasha = new Movie("Inuyasha", "Inuyasha and Kagome", "Rumiko Takahashi", 123, Genres.Other, Classification.M, 2019);
             Movie endgame = new Movie("Endgame", "Chris Evans", "Russo Brothers", 300, Genres.Action, Classification.MA, 2019);
             movieCollection.AddNewDVD(inuyasha);
             movieCollection.AddNewDVD(endgame);


             // Create the console GUI
             MainMenu mainMenu = new MainMenu(members, staff);
             StaffMenu staffMenu = new StaffMenu(members, movieCollection);
             MemberMenu memberMenu = new MemberMenu(movieCollection);

             // Connect all pages 
             mainMenu.StaffMenu = staffMenu;
             mainMenu.MemberMenu = memberMenu;
             staffMenu.MainMenu = mainMenu;
             memberMenu.MainMenu = mainMenu;
             mainMenu.Load();

             // TESTCASES for MAINMENU
             // If anything else than 1,2,0 then repeat loop

             // If correct staff then print 
             // if incorrect staff, say and then repeat loop 

             //if correct member then print, 
             // if incorrect member, say and then repeat loop

             // Test cases for StaffMENU
             // Creating movie, invalid inputs. Display
             */
             /*
            MovieCollection movieCollection = new MovieCollection();
            Movie inuyasha = new Movie("Inuyasha", "Inuyasha and Kagome", "Rumiko Takahashi", 123, Genres.Other, Classification.M, 2019);
            Movie sessh = new Movie("Sessh", "Inuyasha and Kagome", "Rumiko Takahashi", 123, Genres.Other, Classification.M, 2019);
            Movie endgame = new Movie("Endgame", "Chris Evans", "Russo Brothers", 300, Genres.Action, Classification.MA, 2019);
            Movie endgame3 = new Movie("Endgame 3", "Chris Evans", "Russo Brothers", 300, Genres.Action, Classification.MA, 2019);
            movieCollection.AddNewDVD(inuyasha);
            movieCollection.AddNewDVD(endgame);
            movieCollection.AddNewDVD(endgame3);
            movieCollection.AddNewDVD(sessh);
            Console.WriteLine("Beforeremoval");
            movieCollection.DisplayAllMovies();
            movieCollection.RemoveDVD("Inuyasha");
            Console.WriteLine("AfterRemoval");
            movieCollection.DisplayAllMovies();
            */

            Library library = new Library();
            library.PopulateMembers();
            library.PopulateMovies();
            library.Run();
            //Console.WriteLine("Hello World!");
        }
    }
}
