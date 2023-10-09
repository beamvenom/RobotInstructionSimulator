public class FieldTests
{
    [Fact]
    public void TestRectangle()
    {
        FieldFactory fieldFactory = new FieldFactory();
        Field rectangle = fieldFactory.Create("rectangle");
        Assert.NotNull(rectangle);
        rectangle.SetWidth(4);
        rectangle.SetHeight(4);
        Assert.True(rectangle.CheckInside(2,2));
        Assert.True(rectangle.CheckInside(3, 3));
        Assert.False(rectangle.CheckInside(5, 1));
    }
    [Fact]
    public void TestRightTriangle()
    {
        FieldFactory fieldFactory = new FieldFactory();
        Field rightTriangle = fieldFactory.Create("righttriangle");
        Assert.NotNull(rightTriangle);
        rightTriangle.SetWidth(4);
        rightTriangle.SetHeight(4);
        Assert.True(rightTriangle.CheckInside(2, 2));
        Assert.False(rightTriangle.CheckInside(3, 3));
        Assert.False(rightTriangle.CheckInside(5, 1));
    }
}
