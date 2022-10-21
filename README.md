# Claims

Create a Claims Console Application.

- [ ] Client ABC Hospital needs a very basic Claims application.
- [x] This should be a console application.
- [ ] The user should be able to View a Claim.
- [ ] The user should be able to Add a Claim.
- [ ] The user should be able to View a Hospital by Name
- [ ] The user should be able to View a Patient by Last Name.
- [ ] A Claim consists of the following fields:
  - [ ] Claim ID (this should be an auto-generated numeric)
  - [ ] Patient ID (numeric)
  - [ ] Patient Last Name
  - [ ] Patient First Name
  - [ ] Patient Middle Name
  - [ ] Patient Address
  - [ ] Patient City
  - [ ] Patient State
  - [ ] Patient Zip
  - [ ] Patient Phone Number
  - [ ] Patient Email Address
  - [ ] Insurance Carrier ID
  - [ ] Insurance Carrier Name
  - [ ] Insurance Carrier Customer Service Phone Number
  - [ ] Hospital ID
  - [ ] Hospital Name
  - [ ] Hospital Address
  - [ ] Hospital City
  - [ ] Hospital State
  - [ ] Hospital Zip
  - [ ] Procedure Code
  - [ ] Procedure Name
  - [ ] Claim Amount Outstanding
  - [ ] Insurance Responsibility Amount
  - [ ] Patient Responsibility Amount
- [ ] Your database tables should be properly normalized
- [ ] All interactions with the database should take place via stored
  procedures.
- [ ] When the user enters a new claim, walk them through the process
  like this:
  - [ ] Ask them for information about the patient.
  - [ ] Ask them for information about the hospital.
  - [ ] Ask them for information about the procedure.
  - [ ] Ask them for information about the patient's insurance.
- [ ] Normally we'd call an API or something like that to get the Claim
  Amount Outstanding, the Insurance Responsibility Amount, and the Patient
  Responsibility Amount.  But for the purposes of our exercise, just have
  the user enter that on the screen.
- [ ] **Important**:
  - [ ] Ensure that you do not write duplicate entries to your tables.
    For example, if the user enters "Anthem" as the insurance carrier,
    and if Anthem is already in the table, don't add it again, but use
    the one that's there.
  - [ ] Use Business Logic and Models in your main program - don't interact
    directly with DTOs in your main program.  So your flow should go:
    Main Program -> Business Logic (converts Models to DTOs and
    vice-versa) -> Repository -> DAL.
