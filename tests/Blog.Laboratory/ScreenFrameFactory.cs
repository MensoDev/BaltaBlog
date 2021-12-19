using Blog.Laboratory.Forms;
using Blog.Laboratory.Screens;
using Blog.Laboratory.Screens.RoleScreens;
using Blog.Laboratory.Screens.TagScreens;
using Blog.Laboratory.Screens.UserScreens;

namespace Blog.Laboratory;

public static class ScreenFrameFactory
{
    public static ScreenMenu CreateMainScreenFrame()
    {
        var options = new List<ScreenMenuOption>
        {
            new ("Tag Menu", CreateTagScreenFrame()),
            new ("Role Menu",  CreateRoleScreenFrame()),
            new ("Category Menu", CreateCategoryScreenFrame()),
            new ("User Menu", CreateUserScreenFrame()),
            new ("Exit Application", () => Environment.Exit(0))
        };

        return new ScreenMenu("Dapper Course", options, 0);
    }

    private static ScreenMenu CreateTagScreenFrame()
    {
        var options = new List<ScreenMenuOption>
        {
            new ("Create Tag", new CreateTagScreenAction()),
            new ("Delete Tag", new DeleteTagScreenAction()),
            new ("Update Tag", new UpdateTagScreenAction()),
            new ("List Tags", new ListTagScreenAction()),
            new ("Back Main Menu")
        };

        return new ScreenMenu("Blog Tag Menu", options, 0);
    }
    
    private static ScreenMenu CreateRoleScreenFrame()
    {
        var options = new List<ScreenMenuOption>
        {
            new ("Create Role", new CreateRoleScreenAction()),
            new ("Delete Role", () => InputText.Read("Test")),
            new ("Update Role", () => InputText.Read("Test")),
            new ("List Roles", () => InputText.Read("Test")),
            new ("Add User in Role", () => InputText.Read("Test")),
            new ("Back Main Menu")
        };

        return new ScreenMenu("Blog Role Menu", options, 0);
    }
    private static ScreenMenu CreateCategoryScreenFrame()
    {
        var options = new List<ScreenMenuOption>
        {
            new ("Create Category", () => InputText.Read("Test")),
            new ("Delete Category", () => InputText.Read("Test")),
            new ("Update Category", () => InputText.Read("Test")),
            new ("List Categories", () => InputText.Read("Test")),
            new ("Back Main Menu")
        };

        return new ScreenMenu("Blog Category Menu", options, 0);
    }
    
    private static ScreenMenu CreateUserScreenFrame()
    {
        var options = new List<ScreenMenuOption>
        {
            new ("Create User", new CreateUserScreenAction()),
            new ("Delete User", () => InputText.Read("Test")),
            new ("Update User", () => InputText.Read("Test")),
            new ("List Users", new ListUsersScreenAction()),
            new ("List Users With Roles", () => InputText.Read("Test")),
            new ("Back Main Menu")
        };

        return new ScreenMenu("Blog Users Menu", options, 0);
    }
}