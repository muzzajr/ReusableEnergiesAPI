# Renewable Energies API

This project is a RESTful API for managing and analyzing data related to renewable energies. It is built using ASP.NET Core and Entity Framework Core with a SQLite database.

## Table of Contents

- [Features](#features)
- [Technologies](#technologies)
- [Setup](#setup)
- [Usage](#usage)
- [API Endpoints](#api-endpoints)
- [Database](#database)
- [Logging](#logging)

## Features

- Fetch top ten records from the database.
- Calculate average installed capacity for specific or all types of renewable energy.
- Calculate average initial investment and GHG emission reduction for all types of renewable energy.
- Paginated list of records with optional filtering and sorting.

## Technologies

- .NET 8
- ASP.NET Core
- Entity Framework Core
- SQLite
- CsvHelper
- Swagger for API documentation

## Setup

1. **Clone the repository:**
`git clone https://github.com/your-repo/renewable-energies-api.git cd renewable-energies-api`

2. **Build the project:**
`dotnet build`

3. **Run the project:**
`dotnet run`


### Swagger UI

For easy testing and exploration of the API, Swagger UI is available at `{BASE_URL}/swagger`.

## API Endpoints

### RenewableEnergiesDataController

- **Get Top Ten Records**
  - `GET /api/RenewableEnergiesData/get-top-ten-records`
  - Fetches the top ten records from the database.

- **Get Average Installed Capacity**
  - `GET /api/RenewableEnergiesData/average-installed-capacity/{energyType}`
  - Calculates the average installed capacity for a specific type of renewable energy.

- **Get All Average Installed Capacity**
  - `GET /api/RenewableEnergiesData/all-average-installed-capacity`
  - Calculates the average installed capacity for all types of renewable energy.

- **Get Investment and Emission Reduction**
  - `GET /api/RenewableEnergiesData/investment-and-emission-reduction`
  - Calculates the average initial investment and GHG emission reduction for all types of renewable energy.

- **Get Records**
  - `GET /api/RenewableEnergiesData/get-records`
  - Gets a paginated list of records, optionally filtered by energy type and sorted by a specified field.

## Database

The database is created and populated with data from a CSV file (`energy_dataset_.csv`) located in the `DB` folder. The `DbUtilities` class handles the creation and population of the database.

### RenewableEnergiesData Model

The `RenewableEnergiesData` model represents the data structure for renewable energy records. It includes properties such as `TypeOfRenewableEnergy`, `InstalledCapacityMW`, `EnergyProductionMWh`, `InitialInvestmentUSD`, and more.

## Logging

Logging is configured to use console and debug providers. Log messages are generated for various operations within the API to help with debugging and monitoring.