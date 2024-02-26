using SignalChat.DataAccess.Models;
using SignalChat.DataAccess.Repositories.Interfaces;
using SignalChat.Models.User;
using SignalChat.Services;
using SignalChat.Services.Exceptions;

namespace SignalChat.Tests;

/// <summary>
/// Тесты <see cref="UserService"/>.
/// </summary>
public class UserServiceTests
{
    /// <summary>
    /// Проверяет, что при валидном Id пользователя возвращается пользователь.
    /// </summary>
    [Theory, AutoMoqData]
    public async Task GetUser_ValidId_Success(
        [Frozen] Mock<IUserRepository> userRepositoryMock,
        int id,
        DbUser dbUser,
        UserService userService)
    {
        // Arrange
        dbUser.Id = id;
        userRepositoryMock.Setup(x => x.GetUser(id)).ReturnsAsync(dbUser);
        
        // Act
        var user = await userService.GetUser(id);
        
        // Assert
        Assert.Equal(id, user.Id);
        userRepositoryMock.Verify(x => x.GetUser(id), Times.Once);
    }

    /// <summary>
    /// Проверяет, что при невалидном Id пользователя выбрасывается исключение.
    /// </summary>
    [Theory, AutoMoqData]
    public async Task GetUser_InvalidId_ThrowsException(
        [Frozen] Mock<IUserRepository> userRepositoryMock,
        int id,
        UserService userService)
    {
        // Arrange
        userRepositoryMock.Setup(x => x.GetUser(id)).ReturnsAsync(() => null);
        
        // Act
        var act = () => userService.GetUser(id);
        
        // Assert
        await Assert.ThrowsAsync<UserNotFoundException>(act);
    }

    /// <summary>
    /// Проверяет, что при валидном запросе пользователь обновляется.
    /// </summary>
    [Theory, AutoMoqData]
    public async Task UpdateUser_ValidUser_Success(
        [Frozen] Mock<IUserRepository> userRepositoryMock,
        User user,
        UserService userService)
    {
        // Arrange
        userRepositoryMock.Setup(x => x.IsUserExistsById(user.Id)).ReturnsAsync(true);
        userRepositoryMock.Setup(x => x.IsUserExistsByUsername(user.Username)).ReturnsAsync(false);
        userRepositoryMock.Setup(x => x.IsUserExistsByEmail(user.Email)).ReturnsAsync(false);
        
        // Act
        await userService.UpdateUser(user);
        
        // Assert
        userRepositoryMock.Verify(x => x.UpdateUser(It.IsAny<DbUser>()), Times.Once);
    }

    /// <summary>
    /// Проверяет, что при невалидном Id пользователя выбрасывается исключение.
    /// </summary>
    [Theory, AutoMoqData]
    public async Task UpdateUser_InvalidId_ThrowsException(
        [Frozen] Mock<IUserRepository> userRepositoryMock,
        User user,
        UserService userService)
    {
        // Arrange
        userRepositoryMock.Setup(x => x.IsUserExistsById(user.Id)).ReturnsAsync(false);
        
        // Act
        var act = () => userService.UpdateUser(user);
        
        // Assert
        await Assert.ThrowsAsync<UserNotFoundException>(act);
    }
    
    /// <summary>
    /// Проверяет, что при невалидном логине пользователя выбрасывается исключение.
    /// </summary>
    [Theory, AutoMoqData]
    public async Task UpdateUser_InvalidUsername_ThrowsException(
        [Frozen] Mock<IUserRepository> userRepositoryMock,
        User user,
        UserService userService)
    {
        // Arrange
        userRepositoryMock.Setup(x => x.IsUserExistsById(user.Id)).ReturnsAsync(true);
        userRepositoryMock.Setup(x => x.IsUserExistsByUsername(user.Username)).ReturnsAsync(true);
        
        // Act
        var act = () => userService.UpdateUser(user);
        
        // Assert
        await Assert.ThrowsAsync<UsernameAlreadyTakenException>(act);
    }
    
    /// <summary>
    /// Проверяет, что при невалидной почте пользователя выбрасывается исключение.
    /// </summary>
    [Theory, AutoMoqData]
    public async Task UpdateUser_InvalidEmail_ThrowsException(
        [Frozen] Mock<IUserRepository> userRepositoryMock,
        User user,
        UserService userService)
    {
        // Arrange
        userRepositoryMock.Setup(x => x.IsUserExistsById(user.Id)).ReturnsAsync(true);
        userRepositoryMock.Setup(x => x.IsUserExistsByUsername(user.Username)).ReturnsAsync(false);
        userRepositoryMock.Setup(x => x.IsUserExistsByEmail(user.Email)).ReturnsAsync(true);
        
        // Act
        var act = () => userService.UpdateUser(user);
        
        // Assert
        await Assert.ThrowsAsync<EmailAlreadyTakenException>(act);
    }
    
    /// <summary>
    /// Проверяет, что при валидном Id пользователя удаляется пользователь.
    /// </summary>
    [Theory, AutoMoqData]
    public async Task DeleteUser_ValidId_Success(
        [Frozen] Mock<IUserRepository> userRepositoryMock,
        int id,
        UserService userService)
    {
        // Arrange
        userRepositoryMock.Setup(x => x.IsUserExistsById(id)).ReturnsAsync(true);
        
        // Act
        await userService.DeleteUser(id);
        
        // Assert
        userRepositoryMock.Verify(x => x.DeleteUser(id), Times.Once);
    }
    
    /// <summary>
    /// Проверяет, что при невалидном Id пользователя выбрасывается исключение.
    /// </summary>
    [Theory, AutoMoqData]
    public async Task DeleteUser_InvalidId_ThrowsException(
        [Frozen] Mock<IUserRepository> userRepositoryMock,
        int id,
        UserService userService)
    {
        // Arrange
        userRepositoryMock.Setup(x => x.IsUserExistsById(id)).ReturnsAsync(false);
        
        // Act
        var act = () => userService.DeleteUser(id);
        
        // Assert
        await Assert.ThrowsAsync<UserNotFoundException>(act);
    }
}