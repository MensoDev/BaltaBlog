using Blog.Domain;
using Blog.Laboratory.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Laboratory.Screens.TagScreens;

public class DeleteTagScreenAction : IScreenActionStrategy
{
    
    private readonly IUnitOfWork _unitOfWork;

    public DeleteTagScreenAction()
    {
        var work =  DependencyInjection.Provider.GetService<IUnitOfWork>();
        _unitOfWork = work ?? throw new NullReferenceException("IUnitOfWork is required");
    }

    public async Task<bool> BuildScreenAsync()
    {
        var id = InputNumber.Read("Insert Tag ID");
        var tag = await _unitOfWork.TagRepository.GetByIdAsync(id);

        if (tag == null)
        {
            Alert.Information("Tag Not Exist", "Check your Tag.Id value");
            Alert.PressKeyToContinueMessage();

            return false;
        }

        if (!await _unitOfWork.TagRepository.RemoveAsync(tag))
        {
            Alert.Error("Error on Delete Tag", $"Tag {tag.Name} not deleted");        
            Alert.PressKeyToContinueMessage();
            return false;
        }
            
        Alert.Information("Success", $"Tag {tag.Name} Deleted");
        Alert.PressKeyToContinueMessage();
        return true;
    }
    
    
    public void Dispose()
    {
        _unitOfWork.Dispose();
        GC.SuppressFinalize(this);
    }
}