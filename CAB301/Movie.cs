using System;
using System.Collections;
using System.IO;

namespace CAB301
{
    /// <summary>
    /// Class representing a Movie stored in the library. 
    /// </summary>
    public class Movie
    {
        public string Title { get; set; }
        public ArrayList Actors { get; set; }
        public string Director { get; set; }
        public int Duration { get; set; }
        public string Genre { get; set; }
        public string Classification { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int TotalDvds { get; set; }
        public int TotalBorrowed { get; set; }

       /// <summary>
       /// Constructor method.
       /// </summary>
       /// <param name="title"></param>
       /// <param name="actors"></param>
       /// <param name="director"></param>
       /// <param name="duration"></param>
       /// <param name="genre"></param>
       /// <param name="classification"></param>
       /// <param name="releaseDate"></param>
        public Movie(string title, ArrayList actors, string director, int duration, string genre, string classification, DateTime releaseDate)
        {
            this.Title = title;
            this.Actors = actors;
            this.Director = director;
            this.Duration = duration;
            this.Genre = genre;
            this.Classification = classification; ;
            this.ReleaseDate = releaseDate;
            TotalDvds = 1;
            TotalBorrowed = 0;
        }

        /// <summary>
        /// Method to add to DVD Count.
        /// </summary>
        public void IncrementDVDCount()
        {
            TotalDvds += 1;
        }

        /// <summary>
        /// Method to remove DVD count when it is borrowed.
        /// </summary>
        public void DecreaseDVDCount()
        {
            if (TotalDvds >= 1)
            {
                TotalDvds -= 1;
            }
            
        }

        /// <summary>
        /// Method to check Movie availability.
        /// </summary>
        /// <returns>Boolean</returns>
        public bool IsAvailable()
        {
            if (TotalDvds >= 1)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Method to increase number of times a Movie has been borrowed.
        /// </summary>
        public void IncrementBorrowedCount()
        {
            TotalDvds += 1;
        }


    }
}
