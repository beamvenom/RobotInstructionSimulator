using RobotInstructionSimulator.CachedFactory;
using System.Xml;

public class RobotFactory
{
    public string[] robotList = { "robot45", "robot90" };
    public string[] robotDescriptionList = { "Robot45 - A robot that turns 45 degrees at a time!", "Robot90 - A robot that turns 90 degrees at a time!" };
    public RobotFactory()
    {

    }

    public Robot Create(string type)
    {
        switch (type.ToLower())
        {
            case "robot45":
                return new Robot45();
            case "robot90":
                return new Robot90();
            default:
                return null;
        }
    }
    public string DescribeList()
    {
        return string.Join(Environment.NewLine, robotDescriptionList);
    }
    public string List()
    {
        return string.Join(Environment.NewLine, robotList);
    }
    public bool Contains(string type)
    {
        return robotList.Contains(type.ToLower());
    }
}