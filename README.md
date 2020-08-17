# <h1 align = "center"> Message Board API

## <h3 align = "center"> Entity Framework in ASP.NET API

## <h3 align = "center"> By:
## <h4 align = "center"> James Henager
## <h4 align = "center"> Micheal Hansen
## <h4 align = "center"> Ian Scott

## <h2 align = "center"> About

<p align = "center"> This API application manages a message board database, with multiple endpoints to return Board(s), Thread(s), Post(s), and User(s), as well as all nested relationships. Model Hierarchy is: Board -> Thread -> Post, with one-many relationships between Users - Threads, and Users - Posts.

## **✅REQUIREMENTS**
* Install [Git v2.62.2+](https://git-scm.com/downloads/)
* Install [.NET version 3.1 SDK v2.2+](https://dotnet.microsoft.com/download/dotnet-core/2.2)
* Install [Visual Studio Code](https://code.visualstudio.com/)
* Install [MySql Workbench](https://www.mysql.com/products/workbench/)

## **💻SETUP**
* to clone this content, copy the url provided by the 'clone or download' button in GitHub
* in command line use the command 'git clone (GitHub url)'
* open the program in a code editor
* In appsettings.JSON, adjust the portion that reads, 'uid=root;pwd=epicodus' to reflect your own MySQL username and password; 'root' and 'epicodus' respectively.
* In the command line enter 'dotnet ef database update'
* navigate to the MessageBoard directory and type dotnet build in the command line to compile the code
* type dotnet run in the command line to run the program
__

## User Stories

* As a user, I want to be able to GET all messages related to a specific group.
* As a user, I want to be able to POST messages to a specific group.
* As a user, I want to be able to see a list of all groups.
* As a user, I want to input date parameters and retrieve only messages posted during that timeframe.
* As a user, I want to be able to PUT and DELETE messages, but only if I wrote them. 


## Known Bugs

_There are currently no known bugs!_

## Support and contact details

Contact : James Henager (jameschenager@gmail.com) with any questions or concerns

## Technologies Used

* C#
* ASP.NET MVC
* Entity Framework
* MySQL
* RESTful routing
* 


## **📘 License**
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)