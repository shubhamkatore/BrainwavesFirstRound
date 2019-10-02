# BrainwavesFirstRound
Brainwaves online round

Fronted :
Frontend is developed using Vue 2.
Steps to Deploy :
1. Npm install
2. Npm run build
3. Npm run serve (To view locally)
4. Dist folder will be created in root directory that can be deployed on any server.
Fronted is deployed on https://sdkbrainwave.azurewebsites.net/ its deployed on Azure.


Backend
Backend is developed using ASP.NET CORE 2
Steps to Deploy :
1. Open given solution.
2. Restore nuget packages.
3. Build the solution.
4. Deploy.
Backend is deployed on https://brainwaveshackathon.azurewebsites.net again its deployed on azure.

Backend is exposing below endpoints
1. api/Stock (For Home Page getting top 5 and last 5 stocks)
2. api/Stock/names(For Binding data to autocomplete)
3. api/Stock/names/{stock}(Getting stock by symbol)
4. api/Stock/date/{date}(Getting stock by date)

Database
Database is SQL Server

Tables
1. companydetails
2. stock

Stored Procedures :
• getstockbysymbol
• getstockbydate
• getsymbolnames
• gettopfive
• getlastfive