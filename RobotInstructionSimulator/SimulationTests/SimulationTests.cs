using Moq;
using System.Reflection.Metadata.Ecma335;

public class SimulationTests
{
    //Without mocking fieldfactory, a lot of time wasted since CreateAsync is time costly.
    [Fact]
    public async void TestRectangleRobot90Simulation()
    {
        FieldFactory _fieldFactory = new FieldFactory();
        RobotFactory _robotFactory = new RobotFactory();
        Field field = await _fieldFactory.CreateAsync("rectangle");
        field.SetWidth(4);
        field.SetHeight(4);
        
        Robot robot = _robotFactory.Create("robot90");
        robot.SetX(2);
        robot.SetY(2);
        robot.SetRotation(90);

        Simulation sim = new(field, robot);
        int[] commands = { 1, 4, 1, 3, 2, 3, 2, 4, 1 };
        sim.ExecuteCommands(commands);
        Assert.True(sim.CheckRobotInsideField());
        Assert.Equal(0, sim.GetRobot().GetX());
        Assert.Equal(1, sim.GetRobot().GetY());
    }

    //Mocking fieldfactory instead to save time
    [Fact]
    public async void TestRightTriangleRobot45Simulation()
    {
        Mock<FieldFactory> mockFieldFactory = new Mock<FieldFactory>();
        RobotFactory _robotFactory = new RobotFactory();
        mockFieldFactory.Setup(fieldFactory => fieldFactory.CreateAsync("righttriangle")).ReturnsAsync(()=>  new RightTriangle());
        Field field = await mockFieldFactory.Object.CreateAsync("righttriangle");
        field.SetWidth(4);
        field.SetHeight(4);

        Robot robot = _robotFactory.Create("robot45");
        robot.SetX(2);
        robot.SetY(2);
        robot.SetRotation(90);

        Simulation sim = new(field, robot);
        int[] commands = { 4, 1, 3, 3, 1, 4, 4, 1, 4, 1, 4, 1 };
        sim.ExecuteCommands(commands);
        Assert.False(sim.CheckRobotInsideField());
        Assert.Equal(-1, sim.GetRobot().GetX());
        Assert.Equal(0, sim.GetRobot().GetY());
    }
    //Using mock to test very specifically and avoid errors not related to that function. Not needed for this simple function though.
    //Creating a new Field could be time-costing(e.g. field i. Mocking the field then reduces runtime.
    [Fact]
    public void TestCheckRobotInsideFieldFunction()
    {
        Mock<Field> mockField = new();
        Mock<Robot> mockRobot = new();
        mockRobot.Setup(x => x.GetX()).Returns(1);
        mockRobot.Setup(x => x.GetY()).Returns(0);
        mockField.Setup(x => x.CheckInside(1, 0)).Returns(true);
        Simulation sim = new(mockField.Object, mockRobot.Object);
        Assert.True(sim.CheckRobotInsideField());
    }
}
