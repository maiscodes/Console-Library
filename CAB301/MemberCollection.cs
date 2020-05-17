using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace CAB301
{
    /// <summary>
    /// Class containing collection of members using the library.
    /// </summary>
    public class MemberCollection
    {
        public Member[] Members { get; set; }
        public int memberCount { get; set; }

        public MemberCollection()
        {
            Members = new Member[10];
            memberCount = 0;
        }

        /// <summary>
        /// Method to add new member to collections.
        /// TODO: Add alphabetically so can perform binary search.
        /// </summary>
        /// <param name="member"></param>
        public void AddNewMember(Member member)
        {            
            if (this.memberCount < 10)
            {
                Members[this.memberCount] = member;
                this.memberCount++;
            }
 
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
      
            for (int member = 0; member < memberCount; member++)
            {
                if (String.Equals(Members[member].FirstName, firstName) && string.Equals(Members[member].Surname, surname))
                {
                    contactDetails = Members[member].ContactNumber; 
                }
            }

            return contactDetails; 
        }

        
    }
}
