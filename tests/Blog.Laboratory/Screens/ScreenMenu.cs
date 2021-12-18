namespace Blog.Laboratory.Screens;

public class ScreenMenu
{
    private readonly List<ScreenMenuOption> _options;
    private readonly string _title;
    
    private ushort _currentIndex;
    private ScreenMenuOption _selectedScreenOption;

    private bool _isRunning = true;
    
    public ScreenMenu(string title, List<ScreenMenuOption> options, ushort defaultOptionIndex)
    {
        _title = title;
        _options = options;
        _currentIndex = defaultOptionIndex;
        _selectedScreenOption = options[defaultOptionIndex];
    }
    
    public async Task LoadScreen()
    {
        ModifyTitleOnScreen();
        SetDefaultThemeSettings();
        
        RefreshInteractiveMenu();
        await InteractiveWithScreenOptions();
    }

    private static void SetDefaultThemeSettings()
    {
        Console.ForegroundColor = ConsoleColor.White;
    }

    private void ModifyTitleOnScreen()
    {
        CleanScreen();
        Console.Title = _title;
        Console.WriteLine("======================================================");
        Console.WriteLine("|==**--> {0}", _title);
        Console.WriteLine("======================================================");
    }

    private static void CleanScreen() 
        => Console.Clear();

    private void ChangeSelectedScreenOptions()
        => _selectedScreenOption = _options[_currentIndex];
    
    private void RefreshInteractiveMenu()
    {
        CleanScreen();
        ModifyTitleOnScreen();
        ChangeSelectedScreenOptions();

        Console.SetCursorPosition(0, 5);
        foreach (var option in _options)
        {
            if (option == _selectedScreenOption)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("|==> {0}",option.Title);
                SetDefaultThemeSettings();
            }
            else
            {
                Console.WriteLine(" -  {0}",option.Title);
            }


        }
    }

    private async Task InteractiveWithScreenOptions()
    {
        do
        {
            var keyPressed = Console.ReadKey();

            switch (keyPressed.Key)
            {
                case ConsoleKey.DownArrow : DownArrowKeyPressed(); break;
                case ConsoleKey.UpArrow : UpArrowKeyPressed(); break;
                case ConsoleKey.Enter : await EnterKeyPressed(); break;
                case ConsoleKey.Escape : _isRunning = false; break;
            }
        } 
        while (_isRunning);
    }

    private async Task EnterKeyPressed()
    {
        
        switch (_selectedScreenOption.Type)
        {
            case EScreenMenuOptionType.ScreenMenu: await _options[_currentIndex].ScreenMenu.LoadScreen(); break;
            case EScreenMenuOptionType.Back: _isRunning = false; break;
            case EScreenMenuOptionType.ScreenAction: await _options[_currentIndex].Strategy.BuildScreenAsync(); break;
            case EScreenMenuOptionType.AnonymousAction: _options[_currentIndex].AnonymousAction.Invoke(); break;
            default: throw new ArgumentOutOfRangeException();
        }
        
        RefreshInteractiveMenu();
    }

    private void DownArrowKeyPressed()
    {
        if (_currentIndex + 1 >= _options.Count) return;
        
        _currentIndex++;
        
        RefreshInteractiveMenu();
    }

    private void UpArrowKeyPressed()
    {
        if (_currentIndex - 1 < 0) return;
        
        _currentIndex--;
        
        RefreshInteractiveMenu();
    }
    
    
}