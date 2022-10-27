﻿using System;

using Claims.Business.Models;
using Claims.Business.Models.Interfaces;

namespace Claims.App
{
    internal static class Program
    {
        static void Main()
        {
            bool shouldContinueApp = true;
            do
            {
                Console.WriteLine(
                    "Please choose from an option below\n"
                        + "[1] Enter a new Claim\n"
                        + "[2] View an existing Claim\n"
                        + "[3] View information about a Patient\n"
                        + "[4] View information about a Hospital\n"
                        + "[5] View information about a Procedure\n"
                        + "[6] View information about an Insurance Carrier\n"
                );
                Console.Write("Your choice?  ");
                string menuChoice = Console.ReadLine();
                Console.WriteLine();
                switch (menuChoice)
                {
                    case "1":
                        Console.WriteLine("** NEW CLAIM ENTRY **");

                        Console.WriteLine("\n>> Patient Information <<\n");
                        Console.Write("Patient First Name:  ");
                        string patientFirstName = Console.ReadLine();
                        Console.Write("Patient Middle Name:  ");
                        string patientMiddleName = Console.ReadLine();
                        Console.Write("Patient Last Name:  ");
                        string patientLastName = Console.ReadLine();
                        Console.Write("Patient Address:  ");
                        string patientStreet = Console.ReadLine();
                        Console.Write("Patient City:  ");
                        string patientCity = Console.ReadLine();
                        Console.Write("Patient State:  ");
                        string patientState = Console.ReadLine();
                        Console.Write("Patient Zip:  ");
                        string patientZip = Console.ReadLine();
                        Console.Write("Patient Phone Number:  ");
                        string patientPhoneNumber = Console.ReadLine();
                        Console.Write("Patient Email Address:  ");
                        string patientEmailAddress = Console.ReadLine();

                        Console.WriteLine(">> Insurance Information <<");
                        Console.Write("Insurance Carrier Name:  ");
                        string carrierName = Console.ReadLine();
                        Console.Write("Insurance Customer Service Phone Number:  ");
                        string carrierCustomerServicePhoneNumber = Console.ReadLine();

                        Console.WriteLine(">> Hospital Information <<");
                        Console.Write("Hospital Name:  ");
                        string hospitalName = Console.ReadLine();
                        Console.Write("Hospital Address:  ");
                        string hospitalStreet = Console.ReadLine();
                        Console.Write("Hospital City:  ");
                        string hospitalCity = Console.ReadLine();
                        Console.Write("Hospital State:  ");
                        string hospitalState = Console.ReadLine();
                        Console.Write("Hospital Zip:  ");
                        string hospitalZip = Console.ReadLine();

                        Console.WriteLine(">> Procedure Information <<");
                        Console.Write("Procedure Code:  ");
                        string procedureCode = Console.ReadLine();
                        Console.Write("Procedure Name:  ");
                        string procedureName = Console.ReadLine();

                        Console.WriteLine(">> Additional Claim Information <<");
                        Console.Write("Claim Amount Outstanding:  ");
                        string claimOutstandingAmount = Console.ReadLine();
                        Console.Write("Amount Insurance is Responsible For:  ");
                        string claimInsuranceResponsibilityAmount = Console.ReadLine();
                        //Console.Write("Amount Patient is Responsible for:  ");
                        //string claimPatientResponsibilityAmount = Console.ReadLine();

                        IClaimModel claim = new ClaimModel();
                        Console.WriteLine($"** New Claim Created.  Claim ID is {claim.Id} **\n");
                        break;

                    case "2":
                        Console.WriteLine("** VIEW EXISTING CLAIM **");
                        break;

                    case "3":
                        Console.WriteLine("** VIEW EXISTING PATIENT **");
                        break;

                    case "4":
                        Console.WriteLine("** VIEW EXISTING HOSPITAL **");
                        break;

                    case "5":
                        Console.WriteLine("** VIEW EXISTING PROCEDURE **");
                        break;

                    case "6":
                        Console.WriteLine("** VIEW EXISTING INSURANCE CARRIER **");
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
                Console.Write("\nWould you like to [1] Return to the Main Menu or [2] End?  ");
                string continueAppChoice = Console.ReadLine();
                if (continueAppChoice == "2")
                {
                    shouldContinueApp = false;
                }
            } while (shouldContinueApp);
        }
    }
}
