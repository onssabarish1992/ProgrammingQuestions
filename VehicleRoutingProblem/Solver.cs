using Google.OrTools.ConstraintSolver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleRoutingProblem
{
    public class Solver: ISolve
    {
        /// <summary>
        /// Solver
        /// </summary>
        void ISolve.Solve()
        {
            // Instantiate the data problem.
            DataModel data = new DataModel();

            // Create Routing Index Manager
            RoutingIndexManager manager =
                new RoutingIndexManager(data.DistanceMatrix.GetLength(0), data.VehicleNumber, data.Depot);


            // Create Routing Model.
            RoutingModel routing = new RoutingModel(manager);

            // Create and register a transit callback.
            int transitCallbackIndex = routing.RegisterTransitCallback((long fromIndex, long toIndex) =>
            {
                // Convert from routing variable Index to
                // distance matrix NodeIndex.
                var fromNode = manager.IndexToNode(fromIndex);
                var toNode = manager.IndexToNode(toIndex);
                return data.DistanceMatrix[fromNode, toNode];
            });

            // Define cost of each arc.
            routing.SetArcCostEvaluatorOfAllVehicles(transitCallbackIndex);

            // Add Distance constraint.
            routing.AddDimension(transitCallbackIndex, 0, 3000,
                                 true, // start cumul to zero
                                 "Distance");

            RoutingDimension distanceDimension = routing.GetMutableDimension("Distance");
            distanceDimension.SetGlobalSpanCostCoefficient(100);

            // Setting first solution heuristic.
            RoutingSearchParameters searchParameters =
                operations_research_constraint_solver.DefaultRoutingSearchParameters();
            searchParameters.FirstSolutionStrategy = FirstSolutionStrategy.Types.Value.PathCheapestArc;

            // Solve the problem.
            Assignment solution = routing.SolveWithParameters(searchParameters);

            // Print solution on console.
            PrintSolution(data, routing, manager, solution);
        }
        
        /// <summary>
        /// Display the solution
        /// </summary>
        /// <param name="data"></param>
        /// <param name="routing"></param>
        /// <param name="manager"></param>
        /// <param name="solution"></param>
        static void PrintSolution(in DataModel data, in RoutingModel routing, in RoutingIndexManager manager,
                              in Assignment solution)
        {
            Console.WriteLine($"Objective {solution.ObjectiveValue()}:");
            long maxRouteDistance = 0;

            for (int i = 0; i < data.VehicleNumber; ++i)
            {
                Console.WriteLine("Route for Vehicle {0}:", i);
                long routeDistance = 0;
                var index = routing.Start(i);
                while (routing.IsEnd(index) == false)
                {
                    Console.Write("{0} -> ", manager.IndexToNode((int)index));
                    var previousIndex = index;
                    index = solution.Value(routing.NextVar(index));
                    routeDistance += routing.GetArcCostForVehicle(previousIndex, index, 0);
                }
                Console.WriteLine("{0}", manager.IndexToNode((int)index));
                Console.WriteLine("Distance of the route: {0}m", routeDistance);
                maxRouteDistance = Math.Max(routeDistance, maxRouteDistance);
            }
            Console.WriteLine("Maximum distance of the routes: {0}m", maxRouteDistance);
        }
    }
}
