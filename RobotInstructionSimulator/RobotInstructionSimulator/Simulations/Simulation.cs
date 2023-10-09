public class Simulation : iSimulation
{
    private Field _field;
    private Robot _robot;
    public Simulation()
    {
        _field = SetupField();
        _robot = SetupRobot();
    }
    public void Start()
    {
        Console.WriteLine($"\nSimulation started with: \nField: {_field}\nRobot: {_robot}\nThis robot can do these instructions below. \n{_robot.GetInstructions()}\nWhat instruction do you want the robot to perform?");
        string answer = Console.ReadLine();
        while( answer != "0" )
        {
            _robot.Execute(Int32.Parse(answer));
            answer= Console.ReadLine();
        }
    }
    private Field SetupField()
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
        field.SetWidth(Int32.Parse(answer));
        Console.WriteLine("How high do you want the " + field.GetType().ToString());
        answer = Console.ReadLine();
        field.SetHeight(Int32.Parse(answer));
        return field;
    }
    private Robot SetupRobot()
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
        robot.SetX(Int32.Parse(answer));
        Console.WriteLine(robot.GetType().ToString() + "'s starting Y position:");
        answer = Console.ReadLine();
        robot.SetY(Int32.Parse(answer));
        Console.WriteLine(robot.GetType().ToString() + "'s starting rotation in degrees (0 is east):");
        answer = Console.ReadLine();
        robot.SetRotation(Int32.Parse(answer));
        return robot;
    }
    
}