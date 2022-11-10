using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.Enums;

namespace ToyRobot.Services
{
    static class DrawGrid
    {

        public static string Start()
        {
            var grid = new StringBuilder();

            
            for (int r = 1; r < 6; r++)
            {
                grid.AppendLine("|¯¯¯¯¯|¯¯¯¯¯|¯¯¯¯¯|¯¯¯¯¯|¯¯¯¯¯|");
                grid.AppendLine("|     |     |     |     |     |");
                grid.AppendLine("|_____|_____|_____|_____|_____|");
            }

            return grid.ToString();
        }

        public static string Draw(int x, int y, Facing facing) 
        {
            var grid = new StringBuilder();

            for (int r = 1; r < 6; r++)
            {
                grid.AppendLine("|¯¯¯¯¯|¯¯¯¯¯|¯¯¯¯¯|¯¯¯¯¯|¯¯¯¯¯|");

                if (r == x)
                {
                    switch (x)
                    {
                        case 1:
                            grid.AppendLine(DrawRow(y, facing));
                            break;
                        case 2:
                            grid.AppendLine(DrawRow(y, facing));
                            break;
                        case 3:
                            grid.AppendLine(DrawRow(y, facing));
                            break;
                        case 4:
                            grid.AppendLine(DrawRow(y, facing));
                            break;
                        case 5:
                            grid.AppendLine(DrawRow(y, facing));
                            break;
                    }
                }
                else 
                {
                    grid.AppendLine($"|     |     |     |     |     |").ToString();
                }

                grid.AppendLine("|_____|_____|_____|_____|_____|");
            }

            return grid.ToString();
        }

        private static string DrawRow(int pos, Facing facing) 
        {

            var facingString = string.Empty;

            switch (facing)
            {
                case Facing.NORTH:
                    facingString = "^";
                    break;
                case Facing.SOUTH:
                    facingString = "v";
                    break;
                case Facing.WEST:
                    facingString = "<";
                    break;
                case Facing.EAST:
                    facingString = ">";
                    break;
                default:
                    break;
            }

            switch (pos)
            {
                case 1:
                    return $"|  {facingString}  |     |     |     |     |";
                case 2:
                    return $"|     |  {facingString}  |     |     |     |";
                case 3:
                    return $"|     |     |  {facingString}  |     |     |";
                case 4:
                    return $"|     |     |     |  {facingString}  |     |";
                case 5:
                    return $"|     |     |     |     |  {facingString}  |";
            }

            return string.Empty;
        }
    }
}
