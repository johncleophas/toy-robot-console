using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.Enums;

namespace ToyRobot.Models
{
    public class Robot
    {
        public int? CurrentX { get; set; }

        public int? CurrentY { get; set; }

        public Facing CurrentF { get; set; }

        public string Message { get; set; }

        public Commands Command { get; set; }

        public int? NextX { get; set; }

        public int? NextY { get; set; }

        public Facing NextF { get; set; }

        public bool CanMove { get; set; }

    }
}
