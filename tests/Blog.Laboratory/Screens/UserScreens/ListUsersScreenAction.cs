using Blog.Domain;
using Blog.Laboratory.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Laboratory.Screens.UserScreens;

public class ListUsersScreenAction : IScreenActionStrategy
{
    private readonly IUnitOfWork _unitOfWork;

    public ListUsersScreenAction()
    {
        var work = DependencyInjection.Provider.GetService<IUnitOfWork>();
        _unitOfWork = work ?? throw new NullReferenceException("IUnitOfWork  is required");
    }

    public async Task<bool> BuildScreenAsync()
    {
        Console.WriteLine("\n=======+++++++ LIST USER |||");
        Console.Write("|\n");

        try
        {
            var users = await _unitOfWork.UserRepository.GetAllAsync();

            foreach (var user in users)
            {
                Console.WriteLine($"ID=[{user.Id}] UserName=[{user.Name}] Email=[{user.Email}] Bio=[{user.Bio}]");
            }
            Alert.PressKeyToContinueMessage();
            return true;
        }
        catch (Exception e)
        {
            Alert.Information("Error", e.Message);
            Alert.PressKeyToContinueMessage();
            return false;
        }
    }
    
    public void Dispose()
    {
        _unitOfWork.Dispose();
        GC.SuppressFinalize(this);
    }
    
}