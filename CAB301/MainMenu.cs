using System;
using System.Collections.Generic;
using System.Text;

namespace CAB301
{
    /// <summary>
    /// Class to load and 
    /// </summary>
    public class MainMenu : Page
    {
        public StaffMenu staffMenu { get; set; }
        public MemberMenu memberMenu { get; set; }
        public readonly string display = @"Welcome to the Community Library
        ================== Main Menu =================
        1. Staff Login 
        2. Member Login
        0. Exit
        ==============================================

        Please make a selection (1-2, or 0 to exit):";

        public MainMenu()
        {

        }

        public override void Load()
        {
            Console.WriteLine(display);

            // Read line 

            // If Staff is selected 
            // Check login details 

            // If member is selected
            // Check member details

            // If exit is selected 



        }
    }
}
