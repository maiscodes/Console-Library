using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CAB301
{
    /// <summary>
    /// Class representing Members using the library.
    /// </summary>
    public class Member
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public string Password { get; set; }
        public ArrayList Movies { get; set; }
       
        /// <summary>
        /// Constructor method
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="address"></param>
        /// <param name="contactNumber"></param>
        /// <param name="password"></param>
        public Member(string firstName, string surname, string address, string contactNumber, string password)
        {
            this.FirstName = firstName;
            this.Surname = surname;
            this.Address = address;
            this.ContactNumber = contactNumber;
            this.Password = password;
            Movies = new ArrayList();
        }

        /// <summary>
        /// Checks if a user meets constraints to borrow a movie.
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        public bool IsAbleToBorrow(string title)
        {
            bool isUnderLimit = Movies.Count <= 9;
            bool isDuplicate = HasMovie(title);
            return isUnderLimit && !isDuplicate;
        }

        /// <summary>
        /// Adds a movie to a user's possession.
        /// </summary>
        /// <param name="movie"></param>
        public void BorrowMovie(Movie movie)
        {
            Movies.Add(movie);
        }

        /// <summary>
        /// Given a movie, the movie record is removed from the user's possession.
        /// </summary>
        /// <param name="movie"></param>
        public void ReturnsMovie(Movie movie)
        {
            if (Movies.Contains(movie))
            {
                Movies.Remove(movie);
            }
        }

        /// <summary>
        /// Given the title checks if user has already borrowed the movie.
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public bool HasMovie(string title)
        {
            foreach (Movie movie in Movies)
            {
                if (movie.Title == title)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Returns username of member.
        /// </summary>
        /// <returns></returns>
        public string GetUserName()
        {
            return $"{Surname}{FirstName}";
        }
    }
}
