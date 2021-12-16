namespace Blog.Laboratory.Forms;

public static class Alert
{
    public static void Information(string title, string message)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        ShowMessage(title, message);
        Console.ForegroundColor = ConsoleColor.White;
    }

    public static void Error(string title, string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        ShowMessage(title, message);
        Console.ForegroundColor = ConsoleColor.White;
    }

    public static void PressKeyToContinueMessage()
    {
        Console.WriteLine("Press key por continue...");
        Console.ReadKey();
    }

    private static void ShowMessage(string title, string message)
    {
        Console.WriteLine("{0}=== Alert: {1} ------|", Environment.NewLine, title);
        Console.WriteLine("==Z|=> {0}{1}", message, Environment.NewLine);
    }
}