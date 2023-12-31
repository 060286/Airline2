# CLI

1. dotnet new sln -n FormulaAirline

## Creating producers.

2. dotnet new webapi -n "FormulaAirline.API"
3. dotnet sln FormulaAirline.sln add FormulaAirline.API/FormulaAirline.API.csproj
4. dotnet build

# Creating consumers

5. dotnet new console -n "FormulaAirline.TicketProcessing"
6. dotnet sln FormulaAirline.sln add FormulaAirline.TicketProcessing/FormulaAirline.TicketProcessing.csproj

# Docker

7. docker-compose up => trying to download rabbitmq

# RabbitMq

8. UserName/Password: Guess/Guess.
