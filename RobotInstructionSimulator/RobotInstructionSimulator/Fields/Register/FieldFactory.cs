using RobotInstructionSimulator.CachedFactory;

public class FieldFactory : CachedFactory<Field>
{
    private string[] fieldList = { "rectangle", "righttriangle" };
    public FieldFactory()
    {

    }

    protected override Field CreateInstance(string type)
    {
        //For example for bigger projects if below would be something time/money costly and we only need one. Which is why we are caching it. Benefit of using factories.
        switch (type.ToLower())
        {
            case "rectangle":
                return new Rectangle();
            case "righttriangle":
                return new RightTriangle();
            default:
                return null;
        }
    }
    public string List()
    {
        return string.Join(Environment.NewLine, fieldList);
    }
    public bool Contains(string type)
    {
        return fieldList.Contains(type);
    }
}