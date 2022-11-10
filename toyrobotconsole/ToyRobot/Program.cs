using System;
using ToyRobot.Services;

namespace ToyRobot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(DrawGrid.Start());

            //var input = Console.ReadLine();

            Console.WriteLine(DrawGrid.Draw(1,1, Enums.Facing.NORTH));
            Console.WriteLine(DrawGrid.Draw(2,2,Enums.Facing.SOUTH));
            Console.WriteLine(DrawGrid.Draw(3,3,Enums.Facing.WEST));
            Console.WriteLine(DrawGrid.Draw(4,4,Enums.Facing.EAST));
            Console.WriteLine(DrawGrid.Draw(5,5,Enums.Facing.NORTH));

            
            //ToyCommand(input!);
        }

        static void ToyCommand(string input) 
        {
            Console.WriteLine(input);
            input = Console.ReadLine();
            ToyCommand(input);
        }
    }
}