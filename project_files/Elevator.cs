//Cole Mueller (coleaaronmueller@gmail.com) 12/2/2023

public class Elevator
{
    private readonly uint travel_time = 10;
    private uint totalTravelTime = 0;
    private uint currentFloor;
    private List<uint> floorsToVisit;
    private List<uint> visitedFloors = new List<uint>();
    public Elevator(uint starting_floor, List<uint> floors_to_visit)
    {
        visitedFloors.Add(starting_floor);
        currentFloor = starting_floor;
        floorsToVisit = floors_to_visit;
    }

    public void Start()
    {
        foreach(uint destination_floor in floorsToVisit)
        {
            if(destination_floor == currentFloor) continue;

            uint traveled = destination_floor > currentFloor ? (destination_floor - currentFloor) : (currentFloor - destination_floor);

            totalTravelTime += travel_time * traveled;

            visitedFloors.Add(destination_floor);
            currentFloor = destination_floor;
        }

        Print();
    }

    private void Print()
    {
        Console.WriteLine("\nElevator Trip Complete!");
        Console.WriteLine("Total Travel Time: " + totalTravelTime);
        string floorsOutput = "Floors Visited In Order: " + visitedFloors[0];
        for(int i = 1; i < visitedFloors.Count; i++)
        {
            floorsOutput += ", " + visitedFloors[i];
        }
        Console.WriteLine(floorsOutput);

        Console.WriteLine("\n\nPress enter to close...");
        Console.ReadLine();
    }

}