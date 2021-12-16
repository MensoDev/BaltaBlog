using Blog.Domain;
using Blog.Domain.Entities;
using Blog.Laboratory.Forms;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Laboratory.Screens.TagScreens;

public class CreateTagScreenAction : IScreenActionStrategy
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateTagScreenAction()
    {
        var work =  DependencyInjection.Provider.GetService<IUnitOfWork>();
        _unitOfWork = work ?? throw new NullReferenceException("IUnitOfWork is required");
    }

    public async Task<bool> BuildScreenAsync()
    {
        var tag = GetTagFromScreen();
        return await _unitOfWork.TagRepository.RegisterAsync(tag);
    }

    private static Tag GetTagFromScreen()
    {
        var tagName = InputText.Read("Insert Tag Name");
        var tagSlug = InputText.Read("Insert Slug");

        return new Tag { Name = tagName, Slug = tagSlug};
    }
    
    public void Dispose()
    {
        _unitOfWork.Dispose();
        GC.SuppressFinalize(this);
    }
    
}