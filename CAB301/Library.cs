using System;
using System.Collections.Generic;
using System.Text;

namespace CAB301
{
    public class Library
    {
        private MovieCollection Movies { get; set; }
        private MemberCollection Members { get; set; }
        private Staff Staff { get; set; }
        private MainMenu MainMenu { get; set; }
        private StaffMenu StaffMenu { get; set; }
        private MemberMenu MemberMenu { get; set; }
 
        public Library()
        {
            Members = new MemberCollection();
            Movies = new MovieCollection();
            Staff = new Staff("staff", "today123");

            MainMenu = new MainMenu(Members, Staff);
            StaffMenu = new StaffMenu(Members, Movies);
            MemberMenu = new MemberMenu(Movies);

            // Connect all pages 
            MainMenu.StaffMenu = StaffMenu;
            MainMenu.MemberMenu = MemberMenu;
            StaffMenu.MainMenu = MainMenu;
            MemberMenu.MainMenu = MainMenu;
        }

        public void PopulateMembers()
        {
            string[] firstNames = new String[] { "Maisie" };
            string[] lastNames = new String[] { "Vuong" };
            string[] addresses = new String[] { "Rockhampton"  };
            string[] contactNumbers = new String[] { "0405866572" };
            string[] passwords = new String[] { "1234" };

            for (int i = 0; i < firstNames.Length; i++)
            {
                Member member = new Member(firstNames[i], lastNames[i], addresses[i], contactNumbers[i], passwords[i]);
                Members.AddNewMember(member);
            }

           
        }

        public void PopulateMovies()
        {
            Movie inuyasha = new Movie("Inuyasha", "Inuyasha and Kagome", "Rumiko Takahashi", 123, Genres.Other, Classification.M, 2019);
            Movie endgame = new Movie("Endgame", "Chris Evans", "Russo Brothers", 300, Genres.Action, Classification.MA, 2019);
            Movies.AddNewDVD(inuyasha);
            Movies.AddNewDVD(endgame);
        }

        public void Run()
        {
            MainMenu.Load();
        }

    }
}
