# Lab 2 - Airplanes (API + MVC)

This project implements a REST API and an MVC web app that consumes the API.

## Projects
- Lab2.Airplanes.Api (ASP.NET Core Web API)
- Lab2.Airplanes.Mvc (ASP.NET Core MVC)

## Requirements covered
- Airplanes module (All): List, Details, Create, Edit
- Active Airplanes module: List + Inactivate
- Inactive Airplanes module: List + Activate
- Status: 1 = Active, 2 = Inactive

## How to run (Visual Studio 2022)
1. Open `Lab2.Airplanes.sln`
2. Right click Solution -> Properties
3. Select **Multiple startup projects**
   - Lab2.Airplanes.Api = Start
   - Lab2.Airplanes.Mvc = Start
4. Run

## API Base URL
MVC reads the API URL from:
`Lab2.Airplanes.Mvc/appsettings.json`

Current value:
`https://localhost:7250/`

## API Endpoints (Swagger)
- GET    /api/airplanes
- GET    /api/airplanes/active
- GET    /api/airplanes/inactive
- GET    /api/airplanes/{id}
- POST   /api/airplanes
- PUT    /api/airplanes/{id}
- PATCH  /api/airplanes/{id}/inactivate
- PATCH  /api/airplanes/{id}/activate

## Notes
- Data storage is In-Memory (no database required).
