/* 
Cole Mueller (coleaaronmueller@gmail.com) 12/2/2023

Parameters: 
    * Provide code that simulates an elevator. You are free to use any language.
    * Upload the completed project to GitHub for discussion during interview.
    * Document all assumptions and any features that weren’t implemented.
    * The result should be an executable, or script, that can be run with the following inputs and generate the following outputs.
    
        Inputs: [list of floors to visit] (e.g. elevator start=12 floor=2,9,1,32)
        Outputs: [total travel time, floors visited in order] (e.g. 560 12,2,9,1,32)
        Program Constants: Single floor travel time: 10

Assumptions:
    * Working with whole numbers only
        * I'm calling floor 1 the ground floor, so 0 is considered invalid
    * I'm assuming time as seconds
    * Const travel time for 1 floor (10s)
    * Input as ints (uint) (start floor, floors to visit separated by commas)
        * Can't have negative floors, input maxes out at uint max value (4,294,967,295)
        * If a value in the input list is invalid, I'm excluding it and still visiting the valid floors rather than asking for a whole new input.
    * Every floor in a valid input exists and will be visited
    * From the example input/output provided, I'm making the assumption that the elevator visits floor in the order they were input - I'm not trying to optimize the floor visit order to get the shortest travel time (i.e. sort the list and visit floors in order so as to not pass a floor I want to vist on the way to another floor, then have to return later). I am strictly visiting floors in the order they were input.

Non-implemented Features:
    * If this was in a run-time environment with graphics (unity/unreal/etc), these are features I'd want to add

        * Ability to stop and start the elevator
        * If this had real-time visuals, animation triggering and saving the floor data at real-time
        * Ability to add floor to the queue as it's running
*/

namespace ElevatorSimulation
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("\nCole Mueller - Outside Analytics Coding Project");
            Console.WriteLine("_______________________________________________\n");

            uint starting_floor = 0;
            List<uint> floors_to_visit = new List<uint>();

            //Get starting floor input
            while(starting_floor == 0)
            {
                Console.WriteLine("\nElevator Starting Floor: ");
                if(uint.TryParse(Console.ReadLine(), out starting_floor))
                {
                    if(starting_floor != 0) break;
                }
                
                Console.WriteLine("Invalid starting floor. Please enter a valid floor number.");   
            }

            //Get floor to visit input as comma separated
            while(floors_to_visit.Count == 0)
            {
                Console.WriteLine("\nInput list of floors to visit separated by commas (e.g. 1,2,3,etc): ");
                string? input = Console.ReadLine();
                if(input == null || input == "") continue;

                string[] input_list = input.Split(',');
                foreach(string floor_str in input_list)
                {
                    uint floor_num;
                    if(floor_str != "0" && uint.TryParse(floor_str, out floor_num))
                    {
                        floors_to_visit.Add(floor_num);
                    }
                    else
                    {
                        Console.WriteLine("Input \"" + floor_str + "\" is invalid. It will be excluded from the floors to be visited.");
                    }
                }
                
                if(floors_to_visit.Count ==0) Console.WriteLine("Input contained no valid floor numbers. Please try again.");   
            }

            //Decided to make Elevator it's own class so that the program could be extended to support multiple elevators running at once if needed
            Elevator elevator = new Elevator(starting_floor, floors_to_visit);
            elevator.Start();
        }
    }
}






