using System.Diagnostics;
public class CachedFactoryTests
{
    //Without mocking fieldfactory, a lot of time wasted since CreateAsync is time costly.
    //Since the catch works with a static MemoryCache, run these tests separately. Or else they might fail.
    FieldFactory fieldFactory = new();
    [Fact]
    public async Task CachingWhenRepeatCreation()
    {
        FieldFactory.ClearCache();
        Stopwatch watch = new();
        watch.Start();
        await fieldFactory.CreateAsync("rectangle");
        await fieldFactory.CreateAsync("rectangle");
        await fieldFactory.CreateAsync("rectangle");
        watch.Stop();
        Assert.True(watch.ElapsedMilliseconds < 2000);
    }

    [Fact]
    public async Task NotCachingWhenNotRepeatCreation()
    {
        FieldFactory.ClearCache();
        Stopwatch watch = new ();
        watch.Start();

        var rectangle = await fieldFactory.CreateAsync("rectangle");
        Assert.Equal("Rectangle", rectangle.GetType().ToString());
        var rightTriangle = await fieldFactory.CreateAsync("righttriangle");
        Assert.Equal("RightTriangle", rightTriangle.GetType().ToString());

        watch.Stop();
        Assert.True(watch.ElapsedMilliseconds > 2900);
        Assert.True(watch.ElapsedMilliseconds < 3500);
    }
    [Fact]
    public async Task CachingReturningSameObject()
    {
        FieldFactory.ClearCache();
        var rectangle = await fieldFactory.CreateAsync("rectangle");
        rectangle.SetWidth(100);
        var rectangle2 = await fieldFactory.CreateAsync("rectangle");

        Assert.Equal(rectangle2.GetWidth(),rectangle.GetWidth());

    }
    [Fact]
    public async Task CachingReturningSameObjectWhenMixed()
    {
        FieldFactory.ClearCache();
        Stopwatch watch = new();
        watch.Start();

        var rectangle = await fieldFactory.CreateAsync("rectangle");
        Assert.Equal("Rectangle", rectangle.GetType().ToString());
        rectangle.SetWidth(100);

        var rightTriangle = await fieldFactory.CreateAsync("righttriangle");
        Assert.Equal("RightTriangle", rightTriangle.GetType().ToString());

        var rectangle2 = await fieldFactory.CreateAsync("rectangle");

        Assert.Equal(rectangle2.GetWidth(), rectangle.GetWidth());

        watch.Stop();
        Assert.True(watch.ElapsedMilliseconds > 2900);
        Assert.True(watch.ElapsedMilliseconds < 3500);
    }
}
