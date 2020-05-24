using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace CAB301
{
    /// <summary>
    /// Class to load and 
    /// </summary>
    public class MainMenu : Page
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

        public override void Load()
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

        public bool TryStaffLogin()
        {
            bool isInputValid = false;
            // Enter username
            Console.Write("Enter staff username: ");
            string inputUsername = Console.ReadLine();

            // Enter password
            Console.Write("Enter staff password: ");
            string inputPassword = Console.ReadLine();

            // Perform staff credential validation
            if (Staff.IsValid(inputUsername, inputPassword))
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

        public bool TryMemberLogin()
        {
            bool isInputValid = false;
            // Enter username
            Console.Write("Enter member username: ");
            string inputUsername = Console.ReadLine();

            // Enter password
            Console.Write("Enter member password: ");
            string inputPassword = Console.ReadLine();

            // Perform member credential validation
            Member member = Members.LoginMember(inputUsername, inputPassword);

            if (member != null)
            {
                isInputValid = !isInputValid;
                Console.WriteLine("LOAD MEMBER MENU WITH FOCUS MEMBER: {0}", member.FirstName);
                // TODO:

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
