using RobotInstructionSimulator.CachedFactory;
using System.Xml;

public class RobotFactory
{
    public string[] robotList = { "robot45", "robot90" };
    public RobotFactory()
    {

    }

    public Robot Create(string type)
    {
        switch (type)
        {
            case "robot45":
                return new Robot45();
            case "robot90":
                return new Robot90();
            default:
                return null;
        }
    }
    public string List()
    {
        return string.Join(Environment.NewLine, robotList);
    }
    public bool Contains(string type)
    {
        return robotList.Contains(type);
    }
}