using Blog.Domain;
using Blog.Domain.Entities;
using Blog.Laboratory.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Laboratory.Screens.RoleScreens;

public class CreateRoleScreenAction : IScreenActionStrategy
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateRoleScreenAction()
    {
        var work = DependencyInjection.Provider.GetService<IUnitOfWork>();
        _unitOfWork = work ?? throw new NullReferenceException("IUnitOfWork is required");
    }
    
    public async Task<bool> BuildScreenAsync()
    {
        Console.WriteLine("\n=======+++++++ CREATE ROLE |||");
        Console.Write("|\n");

        var role = new Role
        {
            Name = InputText.Read("Insert Role Name"),
            Slug = InputText.Read("Insert Slug"),
        };

        try
        {
            var success = await _unitOfWork.RoleRepository.RegisterAsync(role);

            if (success)
            {
                Alert.Information("Role","Role are registered");
            }
            else
            {
                Alert.Error("Ops!","Error on register a new role");
            }

            Alert.PressKeyToContinueMessage();
            return success;
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