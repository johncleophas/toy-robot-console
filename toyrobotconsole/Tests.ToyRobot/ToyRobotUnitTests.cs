using Xunit;
using ToyRobot.Services;
using ToyRobot.Models;
using ToyRobot.Enums;
using ToyRobot.Constants;

namespace Tests.ToyRobot
{
    public class ToyRobotUnitTests
    {
        [Theory]
        [InlineData("PLACE", 0,0, Facing.NORTH)]
        [InlineData("PLACE", 1,1, Facing.NORTH)]
        [InlineData("PLACE", 2,2, Facing.NORTH)]
        [InlineData("PLACE", 3,3, Facing.NORTH)]
        [InlineData("PLACE", 4,4, Facing.NORTH)]

        public void PlacePositive(string command, int x, int y, Facing f)
        {

            var input = $"{command} {x}, {y}, {f}";
            
            var robot = CommandService.Execute(input, new Robot());

            Assert.True(robot.CanMove);

            robot = CommandService.Execute("report", robot);

            Assert.True(robot.Message == $"Output: {x},{y},{f}");
        }

        [Theory]
        [InlineData("PLACE", 0, 5, Facing.NORTH)]
        [InlineData("PLACE", 1, 5, Facing.NORTH)]
        [InlineData("PLACE", 0, 6, Facing.NORTH)]
        [InlineData("PLACE", 5, 0, Facing.NORTH)]
        [InlineData("PLACE", 6, 5, Facing.NORTH)]

        public void PlaceNegative(string command, int x, int y, Facing f)
        {

            var input = $"{command} {x}, {y}, {f}";

            var robot = CommandService.Execute(input, new Robot());

            Assert.False(robot.CanMove);
            Assert.True(robot.Message == ToyRobotConstants.PleaseTryAgain);

            robot = CommandService.Execute("report", robot);

            Assert.True(robot.Message == ToyRobotConstants.NothingToReport);
        }

        [Theory]
        [InlineData("PLACE", 0, 0, Facing.NORTH)]
        [InlineData("PLACE", 1, 1, Facing.SOUTH)]
        [InlineData("PLACE", 2, 2, Facing.EAST)]
        [InlineData("PLACE", 3, 3, Facing.WEST)]

        public void TurnLeft(string command, int x, int y, Facing f)
        {
            var input = $"{command} {x}, {y}, {f}";

            var robot = CommandService.Execute(input, new Robot());

            Assert.True(robot.CanMove);

            var nextF = Facing.NORTH;

            switch (robot.CurrentF)
            {
                case Facing.NORTH:

                    nextF = Facing.WEST;
                    break;

                case Facing.SOUTH:

                    nextF = Facing.EAST;
                    break;

                case Facing.WEST:

                    nextF = Facing.SOUTH;
                    break;

                case Facing.EAST:
                    nextF = Facing.NORTH;
                    break;
            }

            robot = CommandService.Execute("left", robot);

            Assert.True(robot.NextF == nextF);
        }

        [Theory]
        [InlineData("PLACE", 0, 0, Facing.NORTH)]
        [InlineData("PLACE", 1, 1, Facing.SOUTH)]
        [InlineData("PLACE", 2, 2, Facing.EAST)]
        [InlineData("PLACE", 3, 3, Facing.WEST)]

        public void TurnRight(string command, int x, int y, Facing f)
        {
            var input = $"{command} {x}, {y}, {f}";

            var robot = CommandService.Execute(input, new Robot());

            Assert.True(robot.CanMove);

            var nextF = Facing.NORTH;

            switch (robot.CurrentF)
            {
                case Facing.NORTH:

                    nextF = Facing.EAST;
                    break;

                case Facing.SOUTH:

                    nextF = Facing.WEST;
                    break;

                case Facing.WEST:

                    nextF = Facing.NORTH;
                    break;

                case Facing.EAST:

                    nextF = Facing.SOUTH;
                    break;
            }

            robot = CommandService.Execute("right", robot);

            Assert.True(robot.NextF == nextF);
        }

        [Theory]
        [InlineData("PLACE", 0, 0, Facing.NORTH)]
        [InlineData("PLACE", 1, 1, Facing.SOUTH)]
        [InlineData("PLACE", 2, 2, Facing.EAST)]
        [InlineData("PLACE", 3, 3, Facing.WEST)]

        public void MovePositive(string command, int x, int y, Facing f)
        {
            var input = $"{command} {x}, {y}, {f}";

            var robot = CommandService.Execute(input, new Robot());

            Assert.True(robot.CanMove);

            robot = CommandService.Execute("move", robot);

            Assert.True(robot.CanMove);
            Assert.True( string.IsNullOrEmpty(robot.Message));
        }

        [Theory]
        [InlineData("PLACE", 0, 0, Facing.SOUTH)]
        [InlineData("PLACE", 1, 4, Facing.NORTH)]
        [InlineData("PLACE", 4, 4, Facing.EAST)]
        [InlineData("PLACE", 0, 4, Facing.WEST)]

        public void MoveNegative(string command, int x, int y, Facing f)
        {
            var input = $"{command} {x}, {y}, {f}";

            var robot = CommandService.Execute(input, new Robot());

            Assert.True(robot.CanMove);

            robot = CommandService.Execute("move", robot);

            Assert.False(robot.CanMove);
            Assert.True(robot.Message == ToyRobotConstants.CantMove);
        }

        [Theory]
        [InlineData("PLACE", 0, 0, Facing.NORTH)]
        [InlineData("PLACE", 1, 1, Facing.NORTH)]
        [InlineData("PLACE", 2, 2, Facing.NORTH)]
        [InlineData("PLACE", 3, 3, Facing.NORTH)]
        [InlineData("PLACE", 4, 4, Facing.NORTH)]

        public void Report(string command, int x, int y, Facing f)
        {

            var input = $"{command} {x}, {y}, {f}";

            var robot = CommandService.Execute(input, new Robot());

            Assert.True(robot.CanMove);

            robot = CommandService.Execute("report", robot);

            Assert.True(robot.Message == $"Output: {x},{y},{f}");

            robot = CommandService.Execute("move", robot);

            if (!robot.CanMove) 
            {
                Assert.True(robot.CurrentX == x);
                Assert.True(robot.CurrentY == y);
                Assert.True(robot.CurrentF == f);
            }
        }
    }
}