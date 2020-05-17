using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CAB301
{
    /// <summary>
    /// Class representing Member using library.
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
        /// Method to check if a member meets constraints to borrow a movie.
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        public bool IsAbleToBorrow(Movie movie)
        {
            return (Movies.Count <= 9 && !Movies.Contains(movie));
        }

        /// <summary>
        /// Method to add movie record to member's possession.
        /// </summary>
        /// <param name="movie"></param>
        public void BorrowMovie(Movie movie)
        {
            Movies.Add(movie);
        }

        /// <summary>
        /// Method to remove movie record from member's possession.
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
        /// Method to return username. 
        /// </summary>
        /// <returns></returns>
        public string GetUserName()
        {
            return $"{Surname}{FirstName}";
        }

    }
}
