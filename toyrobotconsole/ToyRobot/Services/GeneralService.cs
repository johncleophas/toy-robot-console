using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobot.Services
{
    static class GeneralService
    {
        public static string Welcome() 
        { 
            var sb = new StringBuilder();

            sb.AppendLine("Welcome to Toy Robot!");
            sb.AppendLine("");
            sb.AppendLine("Begin by using the PLACE command. The PLACE command has 3 arguments, namely X which is the x coordinate, Y which is the y coordinate and F which is the facing direction.");
            sb.AppendLine("");
            sb.AppendLine("Valid values for X and Y are numbers from 0 to 4.");
            sb.AppendLine("Valid valies for F are NORTH, SOUTH, EAST and WEST.");
            sb.AppendLine("");
            sb.AppendLine("You can move the robot by using the MOVE command. MOVE will move the robot by 1 square in the direction it is facing.");
            sb.AppendLine("");
            sb.AppendLine("You can the robot by using the following commands: LEFT and RIGHT");
            sb.AppendLine("");
            sb.AppendLine("LEFT will turn the robot by 90 degrees to the left.");
            sb.AppendLine("RIGHT will turn the robot by 90 degrees to the right.");
            sb.AppendLine("");
            sb.AppendLine("At any time you can use the REPORT command to tell you the location of the robot.");
            sb.AppendLine("");
            sb.AppendLine("Below are examples of the commands");
            sb.AppendLine("");
            sb.AppendLine("PLACE 0,1,NORTH");
            sb.AppendLine("");
            sb.AppendLine("MOVE");
            sb.AppendLine("");
            sb.AppendLine("LEFT");
            sb.AppendLine("");
            sb.AppendLine("RIGHT");
            sb.AppendLine("");
            sb.AppendLine("REPORT");
            sb.AppendLine("");
            sb.AppendLine("Go ahead and try by entering a command! Begin by using the PLACE command.");

            return sb.ToString();
        }
    }
}
