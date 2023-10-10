using Microsoft.VisualBasic.FileIO;
using System.ComponentModel;

public class Simulation
{
    protected Field _field;
    protected Robot _robot;
    public Simulation(){  }
    public Simulation(Field field, Robot robot)
    {
        _field = field;
        _robot = robot;
    }
    public async Task<int[]> DialogStart()
    {
        _field ??= await SetupField();
        _robot ??= SetupRobot();
        Console.WriteLine($"\nSimulation started with: \nField: {_field}\nRobot: {_robot}\nThis robot can do these instructions below. \n{_robot.GetInstructions()}\nWhat instruction do you want the robot to perform?");
        string answer = Console.ReadLine();
        while (answer != "0")
        {
            if (int.TryParse(answer, out int command))
            {
                _robot.Execute(command);
                Console.WriteLine($"Current coordinates and rotation: [{_robot.GetX()},{_robot.GetY()},{_robot.GetRotation()} degrees]");
                Console.WriteLine($"Inside the {_field}: {_field.CheckInside(_robot.GetX(), _robot.GetY())}\n");
            }
            else
            {
                Console.WriteLine($"Invalid command. Only numbers allowed. Please try again");
            }
            answer = Console.ReadLine();
        }
        return await PrintResults();
       
    }
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
    public async Task<int[]> PrintResults()
    {
        Console.WriteLine($"Simulation Over. {_robot}'s final coordinates are [{_robot.GetX()},{_robot.GetY()}]");
        if (CheckRobotInsideField())
        {
            Console.WriteLine($"{_robot} is inside the {_field}");
            return new int[] { _robot.GetX(), _robot.GetY() };
        }
        else
        {
            Console.WriteLine($"{_robot} is NOT inside the {_field}");
            return new int[] { -1, -1};
        }
    }
    public async Task<Field> SetupField()
    {
        FieldFactory fieldFactory = new();
        Console.WriteLine("What field do you want?\n" + fieldFactory.List());
        string answer = Console.ReadLine();
        while (!fieldFactory.Contains(answer))
        {
            Console.WriteLine("Invalid answer. Try again\n");
            answer = Console.ReadLine();
        }
        Field field = await fieldFactory.CreateAsync(answer);
        Console.WriteLine("How many units wide do you want the " + field.GetType().ToString());
        answer = Console.ReadLine();
        field.SetWidth(int.Parse(answer));
        Console.WriteLine("How many units high do you want the " + field.GetType().ToString());
        answer = Console.ReadLine();
        field.SetHeight(int.Parse(answer));
        return field;
    }
    public async Task<Field> SetupField(string fieldType, int width, int height)
    {
        FieldFactory fieldFactory = new();
        Field field = await fieldFactory.CreateAsync(fieldType);
        field.SetWidth(width);
        field.SetHeight(height);
        return field;
    }
    public Robot SetupRobot()
    {
        RobotFactory robotFactory = new();
        Console.WriteLine("What robot do you want?\n" + robotFactory.DescribeList());
        string answer = Console.ReadLine().ToLower();
        while (!robotFactory.Contains(answer))
        {
            Console.WriteLine("Invalid answer. Try again\n");
            Console.WriteLine("What robot do you want?\n" + robotFactory.List());
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
    public Robot SetupRobot(string robotType, int x, int y, int rotation)
    {
        RobotFactory robotFactory = new();
        Robot robot = robotFactory.Create(robotType);
        robot.SetX(x);
        robot.SetY(y);
        robot.SetRotation(rotation);
        return robot;
    }

}