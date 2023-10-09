public abstract class Field
{
    private int _width;
    private int _height;
    protected Field(){ }
    public int GetWidth()
    {
        return _width;
    }

    public void SetWidth(int width)
    {
        _width = width;
    }
    public int GetHeight()
    {
        return _height;
    }
    public void SetHeight(int height)
    {
        _height = height;
    }
    public override string ToString()
    {
        return GetType().Name;
    }
    public abstract bool CheckInside(int x, int y);
}