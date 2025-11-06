using BookShop_MVC.Application.Contracts.RepositoryContracts;
using BookShop_MVC.Application.DTOs;
using BookShop_MVC.Models.Entities;
using BookShop_MVC.Models.Infrastructure.DateBase;

namespace BookShop_MVC.Models.Infrastructure.Repositories
{
    public class UserRepository(AppDbContext _context) : IUserRepository

    {
        public int CreateUser(CreateUserDto user)
        {
            User newUser = new User()
            {
                UserName = user.UserName,
                Password = user.Password,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Role = user.Role
            };
            _context.Users.Add(newUser);
            return _context.SaveChanges();
        }

        public int DeleteUser(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            _context.Users.Remove(user);
            return _context.SaveChanges();
        }

        public UpdateUserDto GetUserById(int userId)
        {
            return _context.Users.Where(u => u.Id == userId)
                .Select(x => new UpdateUserDto()
                {
                    Id = x.Id,
                    UserName = x.UserName,
                    Password = x.Password,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Role = x.Role
                }).FirstOrDefault();
        }

        public string GetUserNameById(int userId)
        {
            return _context.Users.FirstOrDefault(u => u.Id == userId).UserName;
        }

        public bool IsUserNameExist(string userName)
        {
            return _context.Users.Any(u => u.UserName.ToLower() == userName.ToLower());
        }

        public UserDto Login(string userName)
        {
            return _context.Users.Where(u => u.UserName.ToLower() == userName)
                .Select(x => new UserDto()
            {
                UserName = x.UserName,
                Password = x.Password,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Role = x.Role
            }).FirstOrDefault();
        }

        public bool UpdateUser(UpdateUserDto user , int userId)
        {
            try
            {
                var updateUser = _context.Users
                    .FirstOrDefault(u => u.Id == userId);

                if (updateUser is not null)
                {
                    updateUser.UserName = user.UserName;
                    updateUser.Role = user.Role;
                    updateUser.FirstName = user.FirstName;
                    updateUser.LastName = user.LastName;
                    if (!string.IsNullOrWhiteSpace(user.Password))
                    {
                        updateUser.Password = user.Password;
                    }
                    _context.SaveChanges();
                    return true;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }
        

        public List<ShowUsersListDto> UsersList()
        {
            return _context.Users.Select(x => new ShowUsersListDto()
            {
                Id = x.Id,
                UserName = x.UserName,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Role = x.Role
            }).ToList();

        }
    }
}
