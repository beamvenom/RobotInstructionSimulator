using Xunit;
public class SimulationTests
{
    [Fact]
    public void TestRectangleRobot90Simulation()
    {
        Simulation sim = new NoDialogSimulation("rectangle", 4, 4, "robot90", 2, 2);
        int[] commands = { 1, 4, 1, 3, 2, 3, 2, 4, 1 };
        sim.ExecuteCommands(commands);
        Assert.Equal(true, sim.CheckRobotInsideField());
        Assert.Equal(0, sim.GetRobot().GetX());
        Assert.Equal(1, sim.GetRobot().GetY());
    }
    [Fact]
    public void TestRightTriangleRobot45Simulation()
    {
        Simulation sim = new NoDialogSimulation("rectangle", 4, 4, "robot90", 2, 2);
        int[] commands = { 1, 4, 1, 4, 1, 4, 1, 4, 1 };
        sim.ExecuteCommands(commands);
        Assert.Equal(true, sim.CheckRobotInsideField());
        Assert.Equal(0, sim.GetRobot().GetX());
        Assert.Equal(1, sim.GetRobot().GetY());
    }
}
