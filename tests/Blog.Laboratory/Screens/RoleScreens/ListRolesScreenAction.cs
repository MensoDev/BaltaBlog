using Blog.Domain;
using Blog.Laboratory.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Laboratory.Screens.RoleScreens;

public class ListRolesScreenAction : IScreenActionStrategy
{
    private readonly IUnitOfWork _unitOfWork;

    public ListRolesScreenAction()
    {
        var work = DependencyInjection.Provider.GetService<IUnitOfWork>();
        _unitOfWork = work ?? throw new NullReferenceException("IUnitOfWork is required");
    }

    public async Task<bool> BuildScreenAsync()
    {
        Console.WriteLine("\n=======+++++++ LIST ROLES |||");
        Console.Write("|\n\n");

        try
        {
            var roles = await _unitOfWork.RoleRepository.GetAllAsync();

            foreach (var role in roles)
            {
                Console.WriteLine($"ID=[{role.Id}] ROLE=[{role.Name}] SLUG=[{role.Slug}]");
            }

            Alert.PressKeyToContinueMessage();
            return true;
        }
        catch (Exception e)
        {
            Alert.Error("Error",e.Message);
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