public class Robot
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsPowered { get; set; }
    public IRobotCommand?[] Commands { get; } = new IRobotCommand?[3];
    
    public void Run()
    {
        foreach (IRobotCommand? command in Commands)
        {
            command?.Run(this);
            Console.WriteLine($"[{X} {Y} {IsPowered}]");
        }
    }
}

public interface IRobotCommand
{
    void Run(Robot robot);
}

public class OnCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        robot.IsPowered = true;
    }
}

public class OffCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        robot.IsPowered = false;
    }
}

public class NorthCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered)
            robot.Y += 1;
    }
}

public class SouthCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered)
            robot.Y -= 1;
    }
}

public class WestCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered)
            robot.X -= 1;
    }
}

public class EastCommand : IRobotCommand
{
    public void Run(Robot robot)
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
            IRobotCommand command;
            
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
