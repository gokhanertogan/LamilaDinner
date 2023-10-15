using FluentAssertions;
using LamilaDinner.Application.Common.Interfaces.Persistence;
using LamilaDinner.Application.Menus.Commands.CreateMenu;
using LamilaDinner.Application.UnitTests.Menus.Commands.TestUtils;
using LamilaDinner.Application.UnitTests.TestUtils.Menus.Extensions;
using Moq;

namespace LamilaDinner.Application.UnitTests.Menus.Commands.CreateMenu;

public class CreateMenuCommandHandlerTests
{
    private readonly CreateMenuCommandHandler _handler;
    private readonly Mock<IMenuRepository> _mockMenuRepository;

    public CreateMenuCommandHandlerTests(CreateMenuCommandHandler handler)
    {
        _mockMenuRepository = new Mock<IMenuRepository>();
        _handler = new CreateMenuCommandHandler(_mockMenuRepository.Object);
    }

    [Theory]
    [MemberData(nameof(ValidCreateMenuCommands))]
    public async Task HandleCreateMenuCommand_WhenMenuIsValid_ShouldCreateAndReturnMenu(CreateMenuCommand createMenuCommand)
    {
        //var createMenuCommand = CreateMenuCommandUtils.CreateCommand();

        var result = await _handler.Handle(createMenuCommand, default);

        result.IsError.Should().BeFalse();

        result.Value.ValidateCreatedFrom(createMenuCommand);
        _mockMenuRepository.Verify(m => m.Add(result.Value), Times.Once);
    }

    public static IEnumerable<object[]> ValidCreateMenuCommands()
    {
        yield return new[] { CreateMenuCommandUtils.CreateCommand() };
        yield return new[]
        {
            CreateMenuCommandUtils.CreateCommand(
                sections : CreateMenuCommandUtils.CreateSectionsCommand(sectionCount:3))
        };

        yield return new[]
        {
            CreateMenuCommandUtils.CreateCommand(
                sections : CreateMenuCommandUtils.CreateSectionsCommand(sectionCount:3, items: CreateMenuCommandUtils.CreateItemsCommand(itemCount:3)))
        };
    }

    public void Test_HappyFlow()
    {

    }
    public void Creating_A_Menu_Creates_And_Returns_Menu()
    {

    }
    public void Handling_Create_Menu_Stores_Menu_In_DB()
    {

    }
    public void Test_CreateMenuCommandHandler_HandleValid_ReturnsMenu()
    {

    }
}