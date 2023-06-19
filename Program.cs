public class Robot
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsPowered { get; set; }
    public RobotCommand?[] Commands { get; } = new RobotCommand?[3];
    
    public void Run()
    {
        foreach (RobotCommand? command in Commands)
        {
            command?.Run(this);
            Console.WriteLine($"[{X} {Y} {IsPowered}]");
        }
    }
}

public abstract class RobotCommand
{
    public abstract void Run(Robot robot);
}

public class OnCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        robot.IsPowered = true;
    }
}

public class OffCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        robot.IsPowered = false;
    }
}

public class NorthCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered)
            robot.Y += 1;
    }
}

public class SouthCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered)
            robot.Y -= 1;
    }
}

public class WestCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered)
            robot.X -= 1;
    }
}

public class EastCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered)
            robot.X += 1;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Robot robot = new Robot();
        
        for (int i = 0; i < 3; i++)
        {
            string? input = Console.ReadLine();
            RobotCommand command;
            
            if (input == "on")
                command = new OnCommand();
            else if (input == "off")
                command = new OffCommand();
            else if (input == "north")
                command = new NorthCommand();
            else if (input == "south")
                command = new SouthCommand();
            else if (input == "west")
                command = new WestCommand();
            else if (input == "east")
                command = new EastCommand();
            else
                continue;
            
            robot.Commands[i] = command;
        }
        robot.Run();
    }
}
