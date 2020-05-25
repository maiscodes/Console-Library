using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace CAB301
{
    /// <summary>
    /// Class to display and process Main Menu actions.
    /// </summary>
    public class MainMenu
    {
        public StaffMenu StaffMenu { get; set; }
        public MemberMenu MemberMenu { get; set; }
        public MemberCollection Members  { get; set; }
        public Staff Staff { get; set; }
        public readonly string display = @"
Welcome to the Community Library
================== Main Menu =================
1. Staff Login 
2. Member Login
0. Exit
==============================================";

        public MainMenu(MemberCollection members, Staff staff)
        {
            this.Members = members;
            this.Staff = staff;
        }

        public void Load()
        {
            Console.WriteLine(display);

            bool isInputValid = false; 
            
            while (!isInputValid)
            {
                Console.Write("Please make a selection(1 - 2, or 0 to exit): ");
                string input = Console.ReadLine();

                if (String.Equals(input, "1"))
                {
                    isInputValid = TryStaffLogin();
                } 
                else if (String.Equals(input, "2"))
                {
                    isInputValid = TryMemberLogin();
                }
                else if (String.Equals(input, "0"))
                {
                    Exit();
                }

            }

        }

        /// <summary>
        /// Reads input from console to perform staff credential authentication, 
        /// only loading the staff menu screen if matching records are found.
        /// </summary>
        /// <returns></returns>
        public bool TryStaffLogin()
        {
            bool isInputValid = false;
            
            Console.Write("Enter staff username: "); // Enter username
            string inputUsername = Console.ReadLine();

            Console.Write("Enter staff password: "); // Enter password
            string inputPassword = Console.ReadLine();

            if (Staff.IsValid(inputUsername, inputPassword)) // Perform credential validation
            {
                isInputValid = !isInputValid;
                Console.WriteLine("\nSuccessful login! Transferring you to Staff Menu");
                StaffMenu.Load();
            }
            else
            {
                Console.WriteLine("Staff username and password does not match.");
            }
            return isInputValid;
        }

        /// <summary>
        ///  Reads input from console to perform member credential authentication, 
        /// only loading the member menu screen if matching records are found.
        /// </summary>
        /// <returns></returns>
        public bool TryMemberLogin()
        {
            bool isInputValid = false;

            Console.Write("Enter member username: "); // Enter username
            string inputUsername = Console.ReadLine();

            Console.Write("Enter member password: "); // Enter password
            string inputPassword = Console.ReadLine();

            Member member = Members.LoginMember(inputUsername, inputPassword); // Perform credential validation

            if (member != null)
            {
                isInputValid = !isInputValid;
                Console.WriteLine("\nSuccessful Authentication! Logging in as {0}", member.GetUserName());
                MemberMenu.Load(member);
            }
            else
            {
                Console.WriteLine("Member username and password does not exist.");
            }
            return isInputValid;
        }

        public void Exit()
        {
            Console.WriteLine("Exiting program...");
            Environment.Exit(0);
        }
    }
}
