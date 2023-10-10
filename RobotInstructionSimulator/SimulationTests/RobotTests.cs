public class RobotTests
{
    [Fact]
    public void TestRobot90()
    {
        RobotFactory robotFactory = new();
        Robot robot = robotFactory.Create("robot90");
        Assert.NotNull(robot);
        robot.SetX(1);
        robot.SetY(1);
        robot.SetRotation(90);
        robot.Execute(1);
        Assert.Equal(1, robot.GetX());
        Assert.Equal(0, robot.GetY());
        robot.Execute(4);
        robot.Execute(1);
        Assert.Equal(0, robot.GetX());
        Assert.Equal(0, robot.GetY());
    }
    [Fact]
    public void TestRobot45()
    {
        RobotFactory robotFactory = new();
        Robot robot = robotFactory.Create("robot45");
        Assert.NotNull(robot);
        robot.SetX(1);
        robot.SetY(1);
        robot.SetRotation(90);
        robot.Execute(1);
        Assert.Equal(1, robot.GetX());
        Assert.Equal(0, robot.GetY());
        robot.Execute(4);
        robot.Execute(1);
        Assert.Equal(0, robot.GetX());
        Assert.Equal(-1, robot.GetY());
    }
}
