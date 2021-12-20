using Blog.Domain;
using Blog.Laboratory.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Laboratory.Screens.RoleScreens;

public class AddUserOnRoleScreenAction : IScreenActionStrategy
{
    private readonly IUnitOfWork _unitOfWork;

    public AddUserOnRoleScreenAction()
    {
        var work = DependencyInjection.Provider.GetService<IUnitOfWork>();
        _unitOfWork = work ?? throw new NullReferenceException("IUnitOfWork is required");
    }

    public async Task<bool> BuildScreenAsync()
    {
        Console.WriteLine("\n=======+++++++ ADD USER ON ROLE |||");
        Console.Write("|\n");

        var userId = InputNumber.Read("Insert UserId");
        var user = await _unitOfWork.UserRepository.GetByIdAsync(userId);

        if (user == null)
        {
            Alert.Error("OPS!","User not exist on database");
            Alert.PressKeyToContinueMessage();
            return false;
        }
        
        var roleId = InputNumber.Read("Insert RoleId");
        var role = await _unitOfWork.RoleRepository.GetByIdAsync(roleId);
        
        if (role == null)
        {
            Alert.Error("OPS!","Role not exist on database");
            Alert.PressKeyToContinueMessage();
            return false;
        }

        var success = await _unitOfWork.RoleRepository.AddUserInRoleAsync(role, user);

        if (success)
        {
            Alert.Information("Success", $"User {user.Name} added in {role.Name} role");
            Alert.PressKeyToContinueMessage();
            return success;
        }
            
        Alert.Information("Error", $"User {user.Name} not added in {role.Name} role");
        Alert.PressKeyToContinueMessage();
        return true;
        
    }
    
    public void Dispose()
    {
        _unitOfWork.Dispose();
        GC.SuppressFinalize(this);
    }
}