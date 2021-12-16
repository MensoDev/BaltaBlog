namespace Blog.Laboratory.Screens;

public class ScreenMenuOption
{
    private static readonly List<ScreenMenuOption> DefaultScreenMenuOptions = new() {new ScreenMenuOption("Back")};
    private static readonly ScreenMenu DefaultScreenMenu =  new ("Invalid Menu", DefaultScreenMenuOptions, 0);
    
    public ScreenMenuOption(string title, ScreenMenu menu)
    {
        Title = title;
        ScreenMenu = menu;
        Type = EScreenMenuOptionType.ScreenMenu;
        Strategy = new NoNullableScreenAction();
        AnonymousAction = () => {};
    }

    public ScreenMenuOption(string title)
    {
        Type = EScreenMenuOptionType.Back;
        Strategy = new NoNullableScreenAction();
        Title = title;
        ScreenMenu = DefaultScreenMenu;
        AnonymousAction = () => {};
    }

    public ScreenMenuOption(string title, IScreenActionStrategy strategy)
    {
        Title = title;
        Strategy = strategy;
        Type = EScreenMenuOptionType.ScreenAction;
        ScreenMenu = DefaultScreenMenu;
        AnonymousAction = () => {};
    }

    public ScreenMenuOption(string title, Action anonymousAction)
    {
        Title = title;
        AnonymousAction = anonymousAction;
        Type = EScreenMenuOptionType.AnonymousAction;
        ScreenMenu = DefaultScreenMenu;
        Strategy = new NoNullableScreenAction();
    }
    
    public string Title { get; private set; }
    public ScreenMenu ScreenMenu { get; private set; }
    public EScreenMenuOptionType Type { get; private set; }
    public IScreenActionStrategy Strategy { get; private set; }
    public Action AnonymousAction { get; private set; }
}

internal class NoNullableScreenAction : IScreenActionStrategy
{
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    public async Task<bool> BuildScreenAsync()
    {
        return await Task.FromResult(true);
    }
}