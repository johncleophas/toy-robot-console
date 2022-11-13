using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.Constants;
using ToyRobot.Enums;
using ToyRobot.Models;

namespace ToyRobot.Services
{
    public static class CommandService
    {
        public const string Place = "PLACE";
        public const string Move = "MOVE";
        public const string Left = "LEFT";
        public const string Right = "RIGHT";
        public const string Report = "REPORT";

        public static Robot Execute(string input, Robot robot)
        {
            robot.CanMove = false;

            robot = ResolveCommand(input, robot);

            if (robot.CanMove)
            {
                robot = MoveRobot(robot);
            }

            return robot;
        }

        private static Robot ResolveCommand(string command, Robot robot)
        {
            if (command.Equals(Move, StringComparison.OrdinalIgnoreCase))
            {
                robot = ValidateCommand(robot, Commands.MOVE);

                return robot;
            }

            if (command.Equals(Left, StringComparison.OrdinalIgnoreCase))
            {
                return TurnLeft(robot);
            }

            if (command.Equals(Right, StringComparison.OrdinalIgnoreCase))
            {
                return TurnRight(robot);
            }

            if (command.Equals(Report, StringComparison.OrdinalIgnoreCase))
            {
                return ReportCommand(robot);
            }

            if (command.Contains(Place, StringComparison.OrdinalIgnoreCase))
            {
                command = command.Replace(Place, "").Trim();

                var arguments = command.Split(",");

                robot = ValidateCommand(robot, Commands.PLACE, arguments);

                return robot;
            }

            return robot;
        }

        private static Robot ReportCommand(Robot robot)
        {
            robot.CanMove = false;

            var message = $"Output: {robot.CurrentX},{robot.CurrentY},{robot.CurrentF}";

            if (!robot.CurrentX.HasValue || !robot.CurrentY.HasValue) 
            {
                message = ToyRobotConstants.NothingToReport;
            }

            robot.Message = message;

            return robot;
        }

        private static Robot TurnLeft(Robot robot)
        {
            robot.CanMove = true;

            switch (robot.CurrentF)
            {
                case Facing.NORTH:

                    robot.NextF = Facing.WEST;
                    return robot;

                case Facing.SOUTH:

                    robot.NextF = Facing.EAST;
                    return robot;

                case Facing.WEST:

                    robot.NextF = Facing.SOUTH;
                    return robot;

                case Facing.EAST:
                    robot.NextF = Facing.NORTH;
                    return robot;
            }

            return robot;
        }

        private static Robot TurnRight(Robot robot)
        {
            robot.CanMove = true;

            switch (robot.CurrentF)
            {
                case Facing.NORTH:

                    robot.NextF = Facing.EAST;
                    return robot;

                case Facing.SOUTH:

                    robot.NextF = Facing.WEST;
                    return robot;

                case Facing.WEST:

                    robot.NextF = Facing.NORTH;
                    return robot;

                case Facing.EAST:

                    robot.NextF = Facing.SOUTH;
                    return robot;
            }

            return robot;
        }

        private static Robot ValidateCommand(Robot robot, Commands command, string[] arguments = null)
        {
            return command switch
            {
                Commands.PLACE => ValidatePlace(robot, arguments),
                Commands.MOVE => ValidateMove(robot),
                _ => robot,
            };
        }

        private static Robot ValidatePlace(Robot robot, string[] arguments)
        {

            if (arguments is null || arguments.Length != 3)
            {
                robot.Message = ToyRobotConstants.PleaseTryAgain;
                return robot;
            }

            var x = arguments[0].Trim();

            if (int.TryParse(x, out int intX))
            {
                if (intX >= 0 && intX <= 4)
                {
                    robot.NextX = intX;
                }
                else
                {
                    robot.Message = ToyRobotConstants.PleaseTryAgain;
                    robot.CanMove = false;

                    return robot;
                }
            }
            else
            {
                robot.Message = ToyRobotConstants.PleaseTryAgain;
                robot.CanMove = false;

                return robot;
            }

            var y = arguments[1].Trim();

            if (int.TryParse(y, out int intY))
            {
                if (intY >= 0 && intY <= 4)
                {
                    robot.NextY = intY;
                }
                else
                {
                    robot.Message = ToyRobotConstants.PleaseTryAgain;
                    robot.CanMove = false;

                    return robot;
                }
            }
            else
            {
                robot.Message = ToyRobotConstants.PleaseTryAgain;
                robot.CanMove = false;

                return robot;
            }

            var f = arguments[2].Trim();

            if (Enum.TryParse(f, true, out Facing facing))
            {
                robot.NextF = facing;
            }
            else
            {
                robot.Message = ToyRobotConstants.PleaseTryAgain;
                robot.CanMove = false;

                return robot;
            };

            robot.CanMove = true;

            return robot;
        }

        private static Robot ValidateMove(Robot robot)
        {
            switch (robot.CurrentF)
            {
                case Facing.NORTH:

                    if (robot.CurrentY == ToyRobotConstants.RowCount - 1)
                    {
                        robot.CanMove = false;
                        robot.Message = ToyRobotConstants.CantMove;
                    }
                    else
                    {
                        robot.CanMove = true;
                        robot.NextY = robot.CurrentY + 1;
                    }

                    return robot;

                case Facing.SOUTH:
                    if (robot.CurrentY == 0)
                    {
                        robot.CanMove = false;
                        robot.Message = ToyRobotConstants.CantMove;

                        return robot;
                    }
                    else
                    {
                        robot.CanMove = true;
                        robot.NextY = robot.CurrentY - 1;
                    }

                    return robot;
                case Facing.WEST:
                    if (robot.CurrentX == 0)
                    {
                        robot.CanMove = false;
                        robot.Message = ToyRobotConstants.CantMove;

                        return robot;
                    }
                    else
                    {
                        robot.CanMove = true;
                        robot.NextX = robot.CurrentX - 1;
                    }

                    return robot;
                case Facing.EAST:
                    if (robot.CurrentX == ToyRobotConstants.ColumnCount - 1)
                    {
                        robot.CanMove = false;
                        robot.Message = ToyRobotConstants.CantMove;

                        return robot;
                    }
                    else
                    {
                        robot.CanMove = true;
                        robot.NextX = robot.CurrentX + 1;
                    }

                    return robot;
            }

            robot.CanMove = true;

            return robot;
        }

        private static Robot MoveRobot(Robot robot)
        {
            robot.CurrentX = robot.NextX;
            robot.CurrentY = robot.NextY;
            robot.CurrentF = robot.NextF;

            Console.WriteLine(DrawGridService.Draw(robot.CurrentX, robot.CurrentY, robot.CurrentF));
            return robot;
        }
    }
}
