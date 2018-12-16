using System;
using static TheLemonTree.Cmd.Extensions.Utilities;

namespace TheLemonTree.Cmd
{
    class Program
    {
        static void Main(string[] args)
        {
            var MaintainVehiclesMenu = new MaintainVehicles();

            while (MaintainVehiclesMenu.Run()) { }

            TellUser("Thanks for using the application!");
        }
    }
}
