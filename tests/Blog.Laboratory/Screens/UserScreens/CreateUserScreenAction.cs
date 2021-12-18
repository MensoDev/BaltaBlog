using Blog.Domain;
using Blog.Domain.Entities;
using Blog.Laboratory.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Laboratory.Screens.UserScreens;

public class CreateUserScreenAction : IScreenActionStrategy
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateUserScreenAction()
    {
        var work = DependencyInjection.Provider.GetService<IUnitOfWork>();
        _unitOfWork = work ?? throw new NullReferenceException("IUnitOfWork is required");
    }

    public async Task<bool> BuildScreenAsync()
    {
        Console.WriteLine("\n=======+++++++ CREATE USER |||");
        Console.Write("|\n");

        var user = new User
        {
            Name = InputText.Read("Insert UserName"),
            Email = InputText.Read("Insert Email Address"),
            Image = InputText.Read("Insert Image URL"),
            Bio = InputText.Read("Insert Bio"),
            Slug = InputText.Read("Insert Slug"),
            PasswordHash = InputText.Read("Insert PasswordHash")
        };

        try
        {
            var success = await _unitOfWork.UserRepository.RegisterAsync(user);

            if (success)
            {
                Alert.Information("User","User are registered");
            }
            else
            {
                Alert.Error("Ops!","Error on register a new user");
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