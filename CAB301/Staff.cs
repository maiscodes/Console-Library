using System;
using System.Collections.Generic;
using System.Text;

namespace CAB301
{
    /// <summary>
    /// Class to store valid staff login details.
    /// </summary>
    public class Staff
    {
        public string Username { get; set; }
        public string Password { get; set; }
       
        /// <summary>
        /// Constructor method. 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public Staff(string username, string password)
        {
            Username = username;
            Password = password;
        }

        /// <summary>
        /// Check given username and password matches a Staff.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool IsValid(string username, string password)
        {
            return (String.Equals(Username, username) && String.Equals(Password, password));
        }
    }
}
