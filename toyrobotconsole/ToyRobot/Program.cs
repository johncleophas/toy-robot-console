using System;
using System.ComponentModel.DataAnnotations;
using ToyRobot.Models;
using ToyRobot.Services;

namespace ToyRobot
{
    internal class Program
    {

        static void Main(string[] args)
        {

            var robot = new Robot();

            Console.WriteLine(GeneralService.Welcome());

            var input = Console.ReadLine();
            
            ToyCommand(input, robot);
        }

        static Robot ToyCommand(string input, Robot robot)
        {
            robot.Message = string.Empty;

            robot = CommandService.Execute(input, robot);

            if (!string.IsNullOrEmpty(robot.Message)) 
            {
                Console.WriteLine(robot.Message);
            }

            input = Console.ReadLine();

            return ToyCommand(input, robot);
        }
    }
}