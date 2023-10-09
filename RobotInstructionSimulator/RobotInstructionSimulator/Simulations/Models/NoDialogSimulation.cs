using Microsoft.VisualBasic.FileIO;
using System.Reflection;

public class NoDialogSimulation : Simulation
{
    public NoDialogSimulation(string fieldType, int width, int height, string robotType, int x, int y, int rotation) : base(fieldType, width, height, robotType, x, y, rotation) { }
    public override void Start(){ }
    protected override Field SetupField(string fieldType, int width,int height)
    {
        FieldFactory fieldFactory = new FieldFactory();
        Field field = fieldFactory.Create(fieldType);
        field.SetWidth(width);
        field.SetHeight(height);
        return field;
    }
    protected override Robot SetupRobot(string robotType, int x, int y, int rotation)
    {
        RobotFactory fieldFactory = new RobotFactory();
        Robot robot = fieldFactory.Create(robotType);
        robot.SetX(x);
        robot.SetY(y);
        robot.SetRotation(rotation);
        return robot;
    }
    protected override Field SetupField()
    {
        throw new InvalidOperationException();
    }
    protected override Robot SetupRobot()
    {
        throw new InvalidOperationException();
    }
}