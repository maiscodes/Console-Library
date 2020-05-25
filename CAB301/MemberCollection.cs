using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace CAB301
{
    /// <summary>
    /// Class containing collection of members using the library. Edit the array.
    /// </summary>
    public class MemberCollection
    {
        public Member[] Members { get; set; }
        public int MemberCount { get; set; }

        public MemberCollection()
        {
            Members = new Member[10];
            MemberCount = 0;
        }

        /// <summary>
        /// Add a new member to the collecions class.
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        public bool AddNewMember(Member member)
        {
            bool isAdded = false;
            if (this.MemberCount < 10)
            {
                
                Members[this.MemberCount] = member;
                this.MemberCount++;
                isAdded = true;
            }
            return isAdded;
        }

        /// <summary>
        /// Method to return contact details given first and surname of a member.
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="surname"></param>
        /// <returns></returns>
        public string GetMemberContactDetails(string firstName, string surname)
        {
            string contactDetails = "";
      
            for (int member = 0; member < MemberCount; member++)
            {
                if (String.Equals(Members[member].FirstName, firstName) && string.Equals(Members[member].Surname, surname))
                {
                    contactDetails = Members[member].ContactNumber; 
                }
            }

            return contactDetails; 
        }

        /// <summary>
        /// Given username and password tries to find and return a matching member. 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Member LoginMember(string username, string password)
        { 
            foreach (Member member in Members)
            {
                if (member != null)
                {
                    if (String.Equals(member.GetUserName(), username) && String.Equals(member.Password, password))
                    {
                        return member;
                    }
                }
            }
            return null;
        }
        
    }
}
