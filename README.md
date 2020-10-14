# Purposefully

Purposefully is an application designed to provide users with an interface to store their goals as well as providing an online journal. It has three primary database tables in addition to the user data. The main profile table houses the user's first, last, and full name as well as their personal motivation to empower their goal progress. The goal table contains the user's goals by housing a goal title, content, time span, and if it has been completed. The third main data table is the journal entries which has a title, entry content, date created, and aan option to connect it to a goal. 

This is written in C# and JavaScript, an object-oriented programming language from Microsoft designed to work with their .Net platform. 



## Installation

Feel free to clone and explore the application:
Use the package manager [GitHub](https://github.com/KateLockhart/Purposefully.git) to install the application. Follow instructions on their page for various ways to clone this project or simply use your command prompt/terminal to navigate to the folder you wish to house the program and enter the line below.

Use Git or checkout with SVN using the web URL:
```bash
$ git clone https://github.com/KateLockhart/Purposefully.git
```



## Usage Directions

For the best experience using Purposefully we recommend opening the program in the IDE or code editor of your choice, we utilize [Visual Studio Code]( https://code.visualstudio.com/). 

Next, run the program according to your IDE which will open the application Home Page within your designated web browser.

If you choose to use an outside client to test the database and the HTTP/s requests and responses. Our team enjoys the platform [Postman]( https://www.postman.com/) offers for navigation and testing.

Utilize the base API address: https://localhost:44326 along with the endpoints listed below.

Explore the database itself or the deployed application at: https://purposefully.azurewebsites.net


## Purposefully Database Endpoints

**Base Address:** https://localhost:44326

**Profile** 

1) /Profile -- 'POST' -- Create a profile
2) /Profile -- 'GET' -- Returns all profiles and their corresponding data
3) /Profile/{id} -- 'GET' -- Returns a singular profile, utilized for the Profile Detail
4) /Profile -- 'PUT' -- Updates the profile information
5) /Profile/{id} -- 'DELETE' -- Deletes the profile specified by the ProfileId

**Goal** 

6) /goal -- 'POST' -- Create a goal
7) /goal -- 'GET' -- Returns all goals in the database
8) /goal/{id} -- 'GET' -- Returns a singular goal and its data
9) /goal -- 'PUT' -- Updates the goal's information
10) /goal/{id} -- 'DELETE' -- Delete goal by the GoalId


**Entry**

11) /Entry -- 'POST' -- Create a journal entry
12) /Entry -- 'GET' -- Get all entries
13) /Entry/{id} -- 'GET' -- Get a singular entry
14) /Entry -- 'PUT' -- Update a journal entry's data
15) /Entry/{id} -- 'DELETE' -- Delete an entry by EntryId



## Contributing
Pull requests are always welcome. For major changes to the API, please open an issue beforehand to discuss the changes you intend to make or feel the application needs.
Wiki repository being developed for more detailed documentation.


## Authors of Purposefully

* **Kate Lockhart**
A recent [Eleven Fifty Academy]( https://elevenfifty.org/) front end web development graduate, continuing her education with their software development program.
  On the search for any Software or Front End Web Dev job opportunities and experience. 
  **LinkedIn:** [Kate Lockhart](https://www.linkedin.com/in/katelynlockhart/)   **Portfolio:** [Kate Lockhart](https://katelockhart.github.io/MyPortfolio/)


