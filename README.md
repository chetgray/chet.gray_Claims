# Claims

> Create a Claims Console Application.
> 
> - [ ] Client ABC Hospital needs a very basic Claims application.
> - [x] This should be a console application.
> - [ ] The user should be able to View a Claim.
> - [ ] The user should be able to Add a Claim.
> - [ ] The user should be able to View a Hospital by Name
> - [ ] The user should be able to View a Patient by Last Name.
> - [x] A Claim consists of the following fields:
>   - [x] Claim ID (this should be an auto-generated numeric)
>   - [x] Patient ID (numeric)
>   - [x] Patient Last Name
>   - [x] Patient First Name
>   - [x] Patient Middle Name
>   - [x] Patient Address
>   - [x] Patient City
>   - [x] Patient State
>   - [x] Patient Zip
>   - [x] Patient Phone Number
>   - [x] Patient Email Address
>   - [x] Insurance Carrier ID
>   - [x] Insurance Carrier Name
>   - [x] Insurance Carrier Customer Service Phone Number
>   - [x] Hospital ID
>   - [x] Hospital Name
>   - [x] Hospital Address
>   - [x] Hospital City
>   - [x] Hospital State
>   - [x] Hospital Zip
>   - [x] Procedure Code
>   - [x] Procedure Name
>   - [x] Claim Amount Outstanding
>   - [x] Insurance Responsibility Amount
>   - [x] Patient Responsibility Amount
> - [x] Your database tables should be properly normalized
> - [x] All interactions with the database should take place via stored
>   procedures.
> - [x] When the user enters a new claim, walk them through the process
>   like this:
>   - [x] Ask them for information about the patient.
>   - [x] Ask them for information about the hospital.
>   - [x] Ask them for information about the procedure.
>   - [x] Ask them for information about the patient's insurance.
> - [x] Normally we'd call an API or something like that to get the
>   Claim Amount Outstanding, the Insurance Responsibility Amount, and
>   the Patient Responsibility Amount.  But for the purposes of our
>   exercise, just have the user enter that on the screen.
> - [ ] **Important**:
>   - [ ] Ensure that you do not write duplicate entries to your tables.
>     For example, if the user enters "Anthem" as the insurance carrier,
>     and if Anthem is already in the table, don't add it again, but use
>     the one that's there.
>   - [ ] Use Business Logic and Models in your main program - don't
>     interact directly with DTOs in your main program.  So your flow
>     should go: Main Program -> Business Logic (converts Models to DTOs
>     and vice-versa) -> Repository -> DAL.
