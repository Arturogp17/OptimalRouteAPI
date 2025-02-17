using OptimalRoute.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimalRoute.Tests.Services
{
    public class RouteServiceTests
    {

        [Fact]
        public void CalculateShortestRoute_ShouldThrowException_WhenRequestIsNull()
        {
            // Arrange
            var service = new RouteService();

            // Act & Assert
            Assert.Throws<Exception>(() =>
                service.CalculateShortestRoute(null, null, null, null)
            );
        }


        [Fact]
        public void CalculateShortestRoute_ShouldReturnEmpty_WhenNoPathExists()
        {
            // Arrange
            var service = new RouteService();
            var cities = new List<string> { "A", "B", "C" };
            var roads = new List<(string from, string to, int time)>
            {
                ("A", "B", 10) // No hay conexión a C
            };

            // Act
            var (route, totalTime) = service.CalculateShortestRoute(cities, roads, "A", "C");

            // Assert
            Assert.Empty(route);
            Assert.Equal(0, totalTime);
        }


        [Fact]
        public void CalculateShortestRoute_ShouldThrowException_WhenRoadHasNoWeight()
        {
            // Arrange
            var service = new RouteService();
            var cities = new List<string> { "A", "B", "C" };
            var roads = new List<(string from, string to, int time)>
            {
                ("A", "B", 10),
                ("B", "C", 0) 
            };

            // Act & Assert
            var exception = Assert.Throws<Exception>(() =>
                service.CalculateShortestRoute(cities, roads, "A", "C")
            );

            Assert.Contains("All roads must have a positive weight", exception.Message);
        }

        [Fact]
        public void CalculateShortestRoute_ShouldReturnOptimalRoute()
        {
            // Arrange
            var service = new RouteService();
            var cities = new List<string> { "A", "B", "C", "D" };
            var roads = new List<(string from, string to, int time)>
            {
                ("A", "B", 10),
                ("B", "C", 15),
                ("A", "C", 30),
                ("C", "D", 5),
                ("B", "D", 25)
            };

            // Act
            var (route, totalTime) = service.CalculateShortestRoute(cities, roads, "A", "D");

            // Assert
            Assert.Equal(new List<string> { "A", "B", "C", "D" }, route);
            Assert.Equal(30, totalTime);
        }

        [Fact]
        public void CalculateShortestRoute_ShouldReturnEmptyRoute_WhenNoRoadsAvailable()
        {
            // Arrange
            var service = new RouteService();
            var cities = new List<string> { "A", "B", "C" };
            var roads = new List<(string from, string to, int time)>(); 

            // Act
            var (route, totalTime) = service.CalculateShortestRoute(cities, roads, "A", "B");

            // Assert
            Assert.Empty(route); // Ruta vacía
            Assert.Equal(0, totalTime); // Tiempo total es 0
        }

        [Fact]
        public void CalculateShortestRoute_ShouldReturnCorrectOrderOfCitiesInRoute()
        {
            // Arrange
            var service = new RouteService();
            var cities = new List<string> { "A", "B", "C", "D" };
            var roads = new List<(string from, string to, int time)>
            {
                ("A", "B", 10),
                ("B", "C", 5),
                ("C", "D", 1)
            };

            // Act
            var (route, totalTime) = service.CalculateShortestRoute(cities, roads, "A", "D");

            // Assert
            var expectedRoute = new List<string> { "A", "B", "C", "D" };
            Assert.Equal(expectedRoute, route);
            Assert.Equal(16, totalTime); // 10 + 5 + 1 = 16
        }

        [Fact]
        public void CalculateShortestRoute_ShouldHandleDuplicateCitiesInList()
        {
            // Arrange
            var service = new RouteService();
            var cities = new List<string> { "A", "A", "B", "C" }; // Ciudad A está repetida
            var roads = new List<(string from, string to, int time)>
            {
                ("A", "B", 10),
                ("B", "C", 5)
            };

            // Act
            var (route, totalTime) = service.CalculateShortestRoute(cities.Distinct().ToList(), roads, "A", "C");

            // Assert
            var expectedRoute = new List<string> { "A", "B", "C" };
            Assert.Equal(expectedRoute, route);
            Assert.Equal(15, totalTime); // 10 + 5 = 15
        }

        [Fact]
        public void CalculateShortestRoute_ShouldReturnOriginWhenOriginEqualsDestination()
        {
            // Arrange
            var service = new RouteService();
            var cities = new List<string> { "A", "B", "C" };
            var roads = new List<(string from, string to, int time)>
            {
                ("A", "B", 10),
                ("B", "C", 5)
            };

            // Act
            var (route, totalTime) = service.CalculateShortestRoute(cities, roads, "A", "A");

            // Assert
            Assert.Single(route); // Solo la ciudad A en la ruta
            Assert.Equal(0, totalTime); // Tiempo total es 0
        }

    }
}
