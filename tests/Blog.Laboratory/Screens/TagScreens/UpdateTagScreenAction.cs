using Blog.Domain;
using Blog.Laboratory.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Laboratory.Screens.TagScreens;

public class UpdateTagScreenAction : IScreenActionStrategy
{

    private readonly IUnitOfWork _unitOfWork;

    public UpdateTagScreenAction()
    {
        var work = DependencyInjection.Provider.GetService<IUnitOfWork>();
        _unitOfWork = work ?? throw new NullReferenceException("IUnitOfWork is required");
    }

    public async Task<bool> BuildScreenAsync()
    {
        Console.WriteLine("\n=======+++++++ UPDATE TAG BY ID |||");
        Console.Write("|\n");

        var id = InputNumber.Read("Insert Tag ID");
        var tag = await _unitOfWork.TagRepository.GetByIdAsync(id);

        if (tag == null)
        {
            Alert.Error("Tag not exist", "Tag not found");
            Alert.PressKeyToContinueMessage();
            return false;
        }
        
        Console.WriteLine($"Selected TAG_ID: {tag.Id} TAG_NAME: {tag.Name}");

        tag.Name = InputText.Read($"TAG NAME [{tag.Name}]:");
        tag.Slug = InputText.Read($"TAG SLUG [{tag.Slug}]:");

        var success = await _unitOfWork.TagRepository.UpdateAsync(tag);
        
        if(success)
            Alert.Information("Tag Updated", $"TAG {tag.Name} are updated");
        else
            Alert.Error("Tag Not Updated", $"TAG {tag.Name} not updated");
        
        Alert.PressKeyToContinueMessage();
        return true;
    }
    
    public void Dispose()
    {
        _unitOfWork.Dispose();
        GC.SuppressFinalize(this);
    }
}