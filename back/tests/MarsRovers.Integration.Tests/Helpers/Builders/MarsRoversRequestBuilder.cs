using MarsRover.Controllers;

namespace MarsRovers.Integration.Tests.Helpers.Builders
{
    public class MarsRoversRequestBuilder
    {
        public static MarsRoversRequest WithCommands(string commands)
        {
            return new MarsRoversRequest(commands);
        }
    }
}
