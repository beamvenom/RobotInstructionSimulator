public class RightTriangle : Field
{
    public RightTriangle() { }
    public override bool CheckInside(int x, int y)
    {
        return !(x < 0 || y < 0 || x > GetWidth() || y > GetHeight()) && GetHeight() - x * GetHeight() / GetWidth() >= y;
    }
}