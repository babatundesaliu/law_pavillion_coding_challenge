Task Requirements:

1. Create a small database to hold user details

2. Create a simple registration API to enter users first name and last name, email and
password and any other details you feel like saving.

3. Create a simple Login API for a user to login using email and password only.

4. Once a user has logged in the response should contain first name, last name, email etc.


How to Run:

1. Clone and open solution in Visual Studio

2. Run 'dotnet ef database update -s ..\login_api' to apply database migration, or alternatevely, run the dbscript.sql file located in the login_infrastructore project root.

3. Run the solution.

4. A detailed API documentation is available via swagger at /swagger/index.html
