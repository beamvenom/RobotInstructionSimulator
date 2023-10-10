using RobotInstructionSimulator.CachedFactory;
using System.Threading.Tasks;

public class FieldFactory : CachedFactory<Field>
{
    private string[] fieldList = { "rectangle", "righttriangle" };
    public FieldFactory()
    {

    }

    protected async override Task<Field> CreateInstanceAsync(string type)
    {
        //For example for bigger projects if below would be something time/money costly and we only need one. Which is why we are caching it.
        switch (type.ToLower())
        {
            case "rectangle":
                return await TimeConsumingAPICallForRectangle();
            case "righttriangle":
                return await TimeConsumingAPICallForRightTriangle();
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
    private async Task<Rectangle> TimeConsumingAPICallForRectangle()
    {
        var task = Task.Run(async delegate
        {
            Console.WriteLine($"Fetching a Rectangle from the database...");
            await Task.Delay(TimeSpan.FromSeconds(1.5));
            return new Rectangle();
        });
        return task.Result;
    }
    private async Task<RightTriangle> TimeConsumingAPICallForRightTriangle()
    {
        var task = Task.Run(async delegate
        {
            Console.WriteLine($"Fetching a RightTriangle from the database...");
            await Task.Delay(TimeSpan.FromSeconds(1.5));
            return new RightTriangle();
        });
        return task.Result;
    }
}