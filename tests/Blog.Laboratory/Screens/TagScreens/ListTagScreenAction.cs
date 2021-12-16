using Blog.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Laboratory.Screens.TagScreens;

public class ListTagScreenAction : IScreenActionStrategy

{

    private readonly IUnitOfWork _unitOfWork;

    public ListTagScreenAction()
    {
        var work =  DependencyInjection.Provider.GetService<IUnitOfWork>();
        _unitOfWork = work ?? throw new NullReferenceException("IUnitOfWork is required");
    }
    
    public async Task<bool> BuildScreenAsync()
    {
        var tags = await _unitOfWork.TagRepository.GetAllAsync();
        
        Console.WriteLine("\n-==== Tags ");
        foreach (var tag in tags)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("ID[{0}]",tag.Id);
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" TAG-NAME: ");
            
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(tag.Name);
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" SLUG: ");
            
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(tag.Slug);
            Console.WriteLine();
        }

        Console.WriteLine("\nPress Key for continue....");
        Console.ReadKey();
        return true;
    }
    
    public void Dispose()
    {
        _unitOfWork.Dispose();
        GC.SuppressFinalize(this);
    }
}