public abstract class Robot
{
    private int _x;
    private int _y;
    private int _rotation;
    private string _instructions;

    protected Robot(){ }
    public virtual int GetX()
    {
        return _x;
    }
    public virtual void SetX(int x)
    {
        _x = x;
    }
    public virtual int GetY()
    {
        return _y;
    }
    public virtual void SetY(int y)
    {
        _y = y;
    }
    public int GetRotation()
    {
        return _rotation;
    }
    public void SetRotation(int rotation)
    {
        _rotation = rotation;
    }
    public string GetInstructions()
    {
        return _instructions;
    }
    protected void SetInstructions(string instructions)
    {
        _instructions = instructions;
    }
    public virtual void Turn(int degrees)
    {
        SetRotation(GetRotation() + degrees);
    }
    public virtual void Move(int units)
    {
        _x += Convert.ToInt32(units * Math.Cos(Math.PI / 180 * GetRotation()));
        _y -= Convert.ToInt32(units * Math.Sin(Math.PI / 180 * GetRotation()));
    }
    public override string ToString()
    {
        return GetType().Name;
    }
    public virtual string Describe() 
    {
        return GetType().Name;
    }

    public abstract void Execute(int command);

}