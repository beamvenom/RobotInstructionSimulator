public class Robot90 : Robot
{
    public Robot90()
    {
        SetInstructions("0 = quit simulation and print results\r\n1 = move forward one step\r\n2 = move backwards one step\r\n3 = rotate clockwise 90 degrees (eg north to east)\r\n4 = rotate counterclockwise 90 degrees (eg west to south)");
    }
    public override void Execute(int command)
    {
        switch (command)
        {
            case 0:
                break;
            case 1:
                Move(1);
                break;
            case 2:
                Move(-1);
                break;
            case 3:
                Turn(-90);
                break;
            case 4:
                Turn(90);
                break;
        }
    }
    public override string Describe()
    {
        return "A robot that turns 90 degrees at a time!";
    }
}