using Microsoft.VisualBasic.FileIO;
using Xunit;

public class DialogSimulation : Simulation
{
    public DialogSimulation() : base() 
    {
        _field = SetupField();
        _robot = SetupRobot();
    }
    public override void Start()
    {
        Console.WriteLine($"\nSimulation started with: \nField: {_field}\nRobot: {_robot}\nThis robot can do these instructions below. \n{_robot.GetInstructions()}\nWhat instruction do you want the robot to perform?");
        string answer = Console.ReadLine();
        while( answer != "0" )
        {
            _robot.Execute(int.Parse(answer));
            Console.WriteLine($"Current coordinates : [{_robot.GetX()},{_robot.GetY()}]");
            Console.WriteLine($"Inside the {_field}: {_field.CheckInside(_robot.GetX(), _robot.GetY())}\n");
            answer= Console.ReadLine();
        }
        PrintResults();
    }

    protected override Field SetupField()
    {
        FieldFactory fieldFactory = new FieldFactory();
        Console.WriteLine("What field do you want?\n" + fieldFactory.List());
        string answer = Console.ReadLine();
        while (!fieldFactory.Contains(answer))
        {
            Console.WriteLine("Invalid answer. Try again\n");
            answer = Console.ReadLine();
        }
        Field field = fieldFactory.Create(answer);
        Console.WriteLine("How wide do you want the " + field.GetType().ToString());
        answer = Console.ReadLine();
        field.SetWidth(int.Parse(answer));
        Console.WriteLine("How high do you want the " + field.GetType().ToString());
        answer = Console.ReadLine();
        field.SetHeight(int.Parse(answer));
        return field;
    }
    protected override Robot SetupRobot()
    {
        RobotFactory robotFactory = new RobotFactory();
        Console.WriteLine("What robot do you want?\n" + robotFactory.List());
        string answer = Console.ReadLine();
        while (!robotFactory.Contains(answer))
        {
            Console.WriteLine("Invalid answer. Try again\n");
            answer = Console.ReadLine();
        }
        Robot robot = robotFactory.Create(answer);
        Console.WriteLine(robot.GetType().ToString() + "'s starting X position:");
        answer = Console.ReadLine();
        robot.SetX(int.Parse(answer));
        Console.WriteLine(robot.GetType().ToString() + "'s starting Y position:");
        answer = Console.ReadLine();
        robot.SetY(int.Parse(answer));
        Console.WriteLine(robot.GetType().ToString() + "'s starting rotation counter clockwise in degrees (0 is east):");
        answer = Console.ReadLine();
        robot.SetRotation(int.Parse(answer));
        return robot;
    }
    protected override Field SetupField(string fieldType, int width, int height) 
    {
        return SetupField();
    }
    protected override Robot SetupRobot(string robotType, int x, int y, int rotation) 
    {
        return SetupRobot();
    }
}