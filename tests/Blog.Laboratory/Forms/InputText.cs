namespace Blog.Laboratory.Forms;

public static class InputText
{
    public static string Read(string title)
    {
        var value = "";
        do
        {
            value =  ShowElement(title);
            if(string.IsNullOrEmpty(value)) Alert.Error("Invalid Value", "The value is required");
            
        } while (string.IsNullOrEmpty(value));
        
        return value;
    }

    private static string ShowElement(string title)
    {
        Console.Write("{0}::: {1}: ", Environment.NewLine, title);
        return  Console.ReadLine()!;
    }
}