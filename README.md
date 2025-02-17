# OptimalRoute API

## Description

This project implements a REST API that calculates the shortest route between two cities based on a set of road connections. It uses the Dijkstra algorithm to find the optimal route and total travel time between two specified cities.

The API is built using **.NET 6** and follows clean architecture principles, SOLID, and dependency injection.

## Endpoints

The API exposes a single endpoint to calculate the shortest route between two cities:

- **POST** `/api/route/optimal-route`

### Request Body (JSON)

{
  "cities": ["A", "B", "C", "D"],
  "roads": [
    {"from": "A", "to": "B", "time": 10},
    {"from": "B", "to": "C", "time": 15},
    {"from": "A", "to": "C", "time": 30},
    {"from": "C", "to": "D", "time": 5},
    {"from": "B", "to": "D", "time": 25}
  ],
  "origin": "A",
  "destination": "D"
}

### Expected Response (JSON)
{
"route": ["A", "B", "C", "D"],
"totalTime": 30
}

## Technologies Used
ASP.NET Core 6: Framework for building the API.
Dijkstra Algorithm: Algorithm used to calculate the shortest route.
Swagger: For interactive API documentation.
XUnit: Framework used for unit and integration tests.

## Running Intructions 
### Requirements
.NET 6 or later.
Visual Studio 2022 or Visual Studio Code.

### Steps to Run
Clone this repository:
git clone https://github.com/your-username/optimalroute-api.git
cd optimalroute-api
Restore the NuGet packages:
dotnet restore
Run the application:
dotnet run
Open your browser and go to http://localhost:5000 to interact with the API. To view the Swagger documentation, navigate to http://localhost:5000/swagger.

### Running Tests
To run unit tests:
dotnet test

## Challenges and Solutions
### Challenge 1: Dijkstra Algorithm Implementation
One of the main challenges was implementing an efficient Dijkstra algorithm to calculate the shortest route. I created a graph where cities are nodes and road connections are edges, allowing the algorithm to find the shortest path.

Solution: I created Graph, Node, and Edge classes to represent the graph, and used a priority queue to optimize the search for the shortest path.

### Challenge 2: Error Handling and Input Validation
Another challenge was correctly handling API inputs, such as invalid JSON format, roads without weights, and impossible routes.

Solution: I implemented validations at the controller level to ensure the request is valid before processing, returning clear error messages like BadRequest or NotFound.

### Challenge 3: Configuring Swagger
Properly configuring Swagger was essential to document and test the API interactively.

Solution: I used Swashbuckle.AspNetCore to generate and expose the API documentation through an interactive UI accessible via the browser.

# Contributions
Feel free to fork this project and submit a pull request if you'd like to contribute. If you have suggestions or improvements, you can open an issue on GitHub.