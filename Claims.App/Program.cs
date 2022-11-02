using System;
using System.Configuration;
using System.Globalization;

using Claims.Business.BLLs;
using Claims.Business.Models;
using Claims.Business.Models.Interfaces;

namespace Claims.App
{
    internal static class Program
    {
        static void Main()
        {
            string connectionString = ConfigurationManager.ConnectionStrings[
                "ClaimsData"
            ].ConnectionString;
            ClaimBLL claimBLL = null;
            HospitalBLL hospitalBLL = null;
            ProcedureBLL procedureBLL = null;
            CarrierBLL carrierBLL = null;
            string query;

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

                        claimBLL = claimBLL ?? new ClaimBLL(connectionString);

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

                        Console.WriteLine("\n>> Insurance Information <<\n");

                        Console.Write("Insurance Carrier Name:  ");
                        string carrierName = Console.ReadLine();
                        Console.Write("Insurance Customer Service Phone Number:  ");
                        string carrierCustomerServicePhoneNumber = Console.ReadLine();

                        Console.WriteLine("\n>> Hospital Information <<\n");

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

                        Console.WriteLine("\n>> Procedure Information <<\n");

                        Console.Write("Procedure Code:  ");
                        string procedureCode = Console.ReadLine();
                        Console.Write("Procedure Name:  ");
                        string procedureName = Console.ReadLine();

                        Console.WriteLine("\n>> Additional Claim Information <<\n");

                        Console.Write("Claim Amount Outstanding:  ");
                        decimal claimOutstandingAmount;
                        while (
                            !decimal.TryParse(
                                Console.ReadLine(),
                                NumberStyles.Currency,
                                CultureInfo.CurrentCulture,
                                out claimOutstandingAmount
                            )
                        )
                        {
                            Console.WriteLine("ERROR:  Please enter a valid amount.");
                            Console.Write("Claim Amount Outstanding:  ");
                        }
                        Console.Write("Amount Insurance is Responsible For:  ");
                        decimal claimInsuranceResponsibilityAmount;
                        while (
                            !decimal.TryParse(
                                Console.ReadLine(),
                                NumberStyles.Currency,
                                CultureInfo.CurrentCulture,
                                out claimInsuranceResponsibilityAmount
                            )
                        )
                        {
                            Console.WriteLine("ERROR:  Please enter a valid amount.");
                            Console.Write("Amount Insurance is Responsible For:  ");
                        }

                        IClaimModel claim = new ClaimModel
                        {
                            Patient = new PatientModel
                            {
                                LastName = patientLastName,
                                FirstName = patientFirstName,
                                MiddleName = patientMiddleName,
                                Street = patientStreet,
                                City = patientCity,
                                State = patientState,
                                Zip = patientZip,
                                PhoneNumber = patientPhoneNumber,
                                EmailAddress = patientEmailAddress,
                            },
                            Carrier = new CarrierModel
                            {
                                Name = carrierName,
                                CustomerServicePhoneNumber = carrierCustomerServicePhoneNumber,
                            },
                            Hospital = new HospitalModel
                            {
                                Name = hospitalName,
                                Street = hospitalStreet,
                                City = hospitalCity,
                                State = hospitalState,
                                Zip = hospitalZip,
                            },
                            Procedure = new ProcedureModel
                            {
                                Code = procedureCode,
                                Name = procedureName,
                            },
                            OutstandingAmount = claimOutstandingAmount,
                            InsuranceResponsibilityAmount = claimInsuranceResponsibilityAmount,
                        };
                        Console.WriteLine(
                            $"Amount Patient is Responsible for:  {claim.PatientResponsibilityAmount:C}"
                        );

                        IClaimModel insertedClaim = claimBLL.Insert(claim);

                        Console.WriteLine(
                            $"\n** New Claim Created.  Claim ID is {insertedClaim.Id} **\n"
                        );

                        break;

                    case "2":
                        Console.WriteLine("** VIEW EXISTING CLAIM **\n");
                        break;

                    case "3":
                        Console.WriteLine("** VIEW EXISTING PATIENT **\n");
                        break;

                    case "4":
                        Console.WriteLine("** VIEW EXISTING HOSPITAL **\n");

                        hospitalBLL = hospitalBLL ?? new HospitalBLL(connectionString);
                        Console.Write("Please enter the Hospital Name:  ");
                        query = Console.ReadLine();
                        IHospitalModel hospital = hospitalBLL.GetByName(query);
                        Console.WriteLine(">> Hospital Information <<\n");

                        if (hospital == null)
                        {
                            Console.WriteLine($"No hospital found with name '{query}'.");
                            break;
                        }
                        Console.WriteLine($"Hospital Name:  {hospital.Name}");
                        Console.WriteLine($"Hospital Address:  {hospital.Street}");
                        Console.WriteLine($"Hospital City:  {hospital.City}");
                        Console.WriteLine($"Hospital State:  {hospital.State}");
                        Console.WriteLine($"Hospital Zip:  {hospital.Zip}");
                        break;

                    case "5":
                        Console.WriteLine("** VIEW EXISTING PROCEDURE **\n");
                        procedureBLL = procedureBLL ?? new ProcedureBLL(connectionString);

                        Console.Write("Please enter the Procedure Code:  ");
                        query = Console.ReadLine();
                        IProcedureModel procedure = procedureBLL.GetByCode(query);
                        Console.WriteLine(">> Procedure Information <<\n");

                        if (procedure is null)
                        {
                            Console.WriteLine($"No Procedure found with code '{query}'");
                            break;
                        }
                        Console.WriteLine($"Procedure Code:  {procedure.Code}");
                        Console.WriteLine($"Procedure Name:  {procedure.Name}");
                        break;

                    case "6":
                        Console.WriteLine("** VIEW EXISTING INSURANCE CARRIER **\n");

                        carrierBLL = carrierBLL ?? new CarrierBLL(connectionString);
                        Console.Write("Please enter the Insurance Carrier Name:  ");
                        query = Console.ReadLine();
                        ICarrierModel carrier = carrierBLL.GetByName(query);
                        Console.WriteLine(">> Insurance Information <<\n");

                        if (carrier is null)
                        {
                            Console.WriteLine($"No Insurance Carrier found with name '{query}'");
                            break;
                        }
                        Console.WriteLine($"Insurance Carrier Name:  {carrier.Name}");
                        Console.WriteLine(
                            $"Insurance Customer Service Phone Number:  {carrier.CustomerServicePhoneNumber}"
                        );
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
