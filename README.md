# FinancialChatChallenge
Financial Chat is a simple browser-based chat application. The chat allow users to get stocks quote by using a simple command and specifying the stock code.

## Introduction
Financial Chat is built using the latest Framework .NET 5. It uses SignalR technology for client-server communication which provides a very good performance.
Also the chat allows by using a command, to get a stock quote using a Bot. The bot uses Stooq service to get the stock inforamtion 
and uses SignalR to send the information back to the user who asked for the information. The stock command is not stored in database.
The chat is stored in database. To store it, I use EF Core with Code first approach, and it is configured to work with SQL Server.

## User Registration
Financial Chat was built in ASP Net Identity Core technology, to allow to register and login users. The user information is persisted in SQL Server DB.
This project is configured to store user information in same database as the Chat information is stored. But it uses different context objects, so that
it can be pointed to a different database if needed just by configuring the context with a new connection string.
ASP NET Identity user definition was modified to handle FirstName and LastName. Also the Login and Register forms were altered to support register by 
userName instead of by email. Confidential information such user credentials are secure.
Email confirmation and password recovery was disabled since this is only a demo. In order to access to the Chat, the user must be logged in.

## Good performance
Since the application is built-in SignalR technology, there is a very good performance.

## Deliverables
All Considerations were taken in account.
Bonus: Authentication was built with ASP NET Identity, and Exceptions that can happen in the chat are nicely handled by the applciation.

## Configuration
This application runs on .NET 5 framework. Open solution on Visual Studio and:

1. Set "FinancialChat.Web" project as start-up project.
2. Go to FinancialChat.Web project and set appsettings.json with proper connection string. (Both asp net identity data and chat data are stored in same db)
3. Open "Package Manager Console", select Web project and execute this command: update-database -Context IdentityContext
4. Open "Package Manager Console", select Repository project and execute this command: update-database -Context FinancialChatContext
