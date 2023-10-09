using Microsoft.VisualBasic.FileIO;

public abstract class Simulation
{
    protected Field _field;
    protected Robot _robot;
    public Simulation() { }
    public Simulation(string fieldType, int width, int height, string robotType, int x, int y, int rotation)
    {
        _field = SetupField(fieldType,width,height);
        _robot = SetupRobot(robotType,x,y,rotation);
    }
    public abstract void Start();
    public Field GetField() { return _field; }
    public Robot GetRobot() { return _robot; }

    public void ExecuteCommands(int[] commands)
    {
        foreach (int command in commands)
        {
            _robot.Execute(command);
        }
    }
    public bool CheckRobotInsideField()
    {
        return _field.CheckInside(_robot.GetX(), _robot.GetY());
    }
    public void PrintResults()
    {
        Console.WriteLine($"Simulation Over. {_robot}'s final coordinates are [{_robot.GetX()},{_robot.GetY()}]");
        if (CheckRobotInsideField())
        {
            Console.WriteLine($"{_robot} is inside the {_field}");
        }
        else
        {
            Console.WriteLine($"{_robot} is NOT inside the {_field}");
        }
    }
    protected abstract Field SetupField();
    protected abstract Field SetupField(string fieldType, int width, int height);
    protected abstract Robot SetupRobot();
    protected abstract Robot SetupRobot(string robotType, int x, int y, int rotation);

}