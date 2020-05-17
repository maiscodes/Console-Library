using System;
using System.Collections;
using System.Resources;
using System.Runtime.CompilerServices;

namespace CAB301
{
    class Program
    {
        static void Main(string[] args)
        {


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
            memberList.AddNewMember(member);
            Console.WriteLine("Member count should be 1: {0}", memberList.memberCount);
            string memberContact = memberList.GetMemberContactDetails("John", "Smith");
            Console.WriteLine("Member number should be 0405852561 {0}", memberContact);
            memberContact = memberList.GetMemberContactDetails("JohnX", "Smith");
            Console.WriteLine("Member number should be nothing {0}", memberContact);


            Console.WriteLine("Hello World!");
        }
    }
}
