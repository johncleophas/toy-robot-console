using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.Constants;
using ToyRobot.Enums;

namespace ToyRobot.Services
{
    static class DrawGridService
    {
        public static string Draw(int? x, int? y, Facing facing = Facing.NORTH)
        {
            y = (ToyRobotConstants.ColumnCount - 1) - y;

            var grid = new StringBuilder();

            grid.AppendLine("");

            for (int r = 0; r <= ToyRobotConstants.RowCount - 1; r++)
            {
                grid.AppendLine(DrawTopOrBottomRow(true));

                if (r == y)
                {
                    grid.AppendLine(DrawRow(x, facing));
                }
                else
                {
                    grid.AppendLine(DrawRow());
                }

                grid.AppendLine(DrawTopOrBottomRow(false));
            }

            return grid.ToString();
        }

        private static string DrawTopOrBottomRow(bool isTop)
        {
            var sb = new StringBuilder();

            string segment;

            if (isTop)
            {
                segment = "|¯¯¯¯¯|";
            }
            else
            {
                segment = "|_____|";
            }

            for (int i = 0; i <= ToyRobotConstants.ColumnCount - 1; i++)
            {
                sb.Append(segment);
            }

            return sb.ToString();
        }

        private static string DrawRow()
        {
            var sb = new StringBuilder();

            for (int i = 0; i <= ToyRobotConstants.ColumnCount - 1; i++)
            {
                sb.Append($"|     |");
            }

            return sb.ToString();
        }

        private static string DrawRow(int? pos, Facing facing)
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

            var sb = new StringBuilder();

            for (int i = 0; i <= ToyRobotConstants.ColumnCount - 1; i++)
            {
                if (i == pos)
                {
                    sb.Append($"|  {facingString}  |");
                }
                else
                {
                    sb.Append($"|     |");
                }
            }

            return sb.ToString();
        }
    }
}
