public class Rectangle : Field
{
    public Rectangle() { }

    public override bool CheckInside(int x, int y)
    {
        return !(x < 0 || y < 0 || x > GetWidth() || y > GetHeight());
    }
}