public class SimulationTests
{
    [Fact]
    public void TestRectangleRobot90Simulation()
    {
        Simulation sim = new NoDialogSimulation("rectangle", 4, 4, "robot90", 2, 2, 90);
        int[] commands = { 1, 4, 1, 3, 2, 3, 2, 4, 1 };
        sim.ExecuteCommands(commands);
        Assert.True(sim.CheckRobotInsideField());
        Assert.Equal(0, sim.GetRobot().GetX());
        Assert.Equal(1, sim.GetRobot().GetY());
    }
    [Fact]
    public void TestRightTriangleRobot45Simulation()
    {
        Simulation sim = new NoDialogSimulation("righttriangle", 4, 4, "robot45", 2, 2, 90);
        int[] commands = { 4,1,3,3,1,4,4,1,4,1,4,1 };
        sim.ExecuteCommands(commands);
        Assert.False(sim.CheckRobotInsideField());
        Assert.Equal(-1, sim.GetRobot().GetX());
        Assert.Equal(0, sim.GetRobot().GetY());
    }
}
