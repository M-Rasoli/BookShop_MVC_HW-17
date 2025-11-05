using BookShop_MVC.Application.DTOs;
using Readify.Domain._common.Entities;

namespace BookShop_MVC.Application.Contracts.ServiceContracts
{
    public interface IUserService
    {
        Result<UserDto> Login(string username, string password);
        Result<bool> CreateUser(CreateUserDto user);
        Result<bool> UpdateUser(UpdateUserDto user, int userId);
        Result<int> DeleteUser(int id);
        List<ShowUsersListDto> UsersList();
        UpdateUserDto GetUserById(int userId);
    }
}
