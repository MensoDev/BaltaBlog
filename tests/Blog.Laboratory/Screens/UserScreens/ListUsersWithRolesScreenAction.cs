using Blog.Domain;
using Blog.Domain.Entities;
using Blog.Laboratory.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Laboratory.Screens.UserScreens;

public class ListUsersWithRolesScreenAction : IScreenActionStrategy
{
    private readonly IUnitOfWork _unitOfWork;
    
    public ListUsersWithRolesScreenAction()
    {
        var work = DependencyInjection.Provider.GetService<IUnitOfWork>();
        _unitOfWork = work ?? throw new NullReferenceException("IUnitOfWork is required");
    }
    
    public async Task<bool> BuildScreenAsync()
    {
        Console.WriteLine("\n=======+++++++ LIST USER |||");
        Console.Write("|\n");

        try
        {
            var users = await _unitOfWork.UserRepository.GetAllWithRolesAsync();

            foreach (var user in users)
            {
                Console.WriteLine($"ID=[{user.Id}] UserName=[{user.Name}] Email=[{user.Email}] Bio=[{user.Bio}]");
                Console.Write("Roles: ");
                foreach (var role in user.Roles)
                {
                    Console.Write("ID[{0}]{1}, ", role.Id, role.Name);
                }
                Console.WriteLine();
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