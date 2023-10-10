public class Robot45 : Robot
{
    public Robot45()
    {
        SetInstructions("0 = quit simulation and print results\r\n1 = move forward one step\r\n2 = move backwards one step\r\n3 = rotate clockwise 45 degrees (eg north to east)\r\n4 = rotate counterclockwise 45 degrees (eg west to south)");
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
                Turn(-45);
                break;
            case 4:
                Turn(45);
                break;
        }
    }
    public override string Describe()
    {
        return "Robot90 - A robot that turns 45 degrees at a time!";
    }
}