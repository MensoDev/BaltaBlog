namespace Blog.Laboratory.Forms;

public static class InputNumber
{
    public static int Read(string title)
    {
        var value = 0;
        do
        {
            var stringNumber =  ShowElement(title);
            if(!int.TryParse(stringNumber, out value) && value <= 0) 
                Alert.Error("Invalid Value", "The value is required");
            
        } while (value <= 0);
        
        return value;
    }

    private static string ShowElement(string title)
    {
        Console.Write("{0}::: {1}: ", Environment.NewLine, title);
        return  Console.ReadLine()!;
    }
}