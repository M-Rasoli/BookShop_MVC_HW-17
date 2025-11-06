using BookShop_MVC.Application.DTOs;
using BookShop_MVC.Models.Entities;

namespace BookShop_MVC.Application.Contracts.RepositoryContracts
{
    public interface IUserRepository
    {
        UserDto Login(string userName);
        int CreateUser(CreateUserDto user);
        bool UpdateUser(UpdateUserDto user, int userId);
        int DeleteUser(int id);
        List<ShowUsersListDto> UsersList();
        bool IsUserNameExist(string userName);
        UpdateUserDto GetUserById(int userId);
        string GetUserNameById(int userId);
    }
}
