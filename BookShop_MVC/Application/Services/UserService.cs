using BookShop_MVC.Application.Contracts.RepositoryContracts;
using BookShop_MVC.Application.Contracts.ServiceContracts;
using BookShop_MVC.Application.DTOs;
using Readify.Domain._common.Entities;

namespace BookShop_MVC.Application.Services
{
    public class UserService(IUserRepository userRepository) : IUserService
    {
        public Result<bool> CreateUser(CreateUserDto user)
        {
            if (string.IsNullOrWhiteSpace(user.FirstName) ||
                string.IsNullOrWhiteSpace(user.LastName) ||
                string.IsNullOrWhiteSpace(user.UserName) ||
                string.IsNullOrWhiteSpace(user.Password))
            {
                return Result<bool>.Failure(message: "فیلد های اجبرای باید کامل شوند .");
            }

            if (user.Password.Length < 8)
            {
                return Result<bool>.Failure(message:"رمز عبور حداقل باید شامل 8 کاراکتر باشد.");
            }

            if (userRepository.IsUserNameExist(user.UserName))
            {
                return Result<bool>.Failure(message: "نام کاربری قبلا استفاده شده است .");
            }

            var result =  userRepository.CreateUser(user);
            if (result > 0)
            {
                return Result<bool>.Success(message: "ثبت نام با موفقیت انجام شد .");
            }
            return Result<bool>.Failure(message:"مشکلی پیش آمده لحظاتی دیگر تلاش کنید");
        }

        public Result<int> DeleteUser(int id)
        {
            var result = userRepository.DeleteUser(id);
            if (result > 0)
            {
                return Result<int>.Success(message:"کاربر با موفقیت حذف شد.");
            }
            else
            {
                return Result<int>.Failure(message:"مشکلی در حذف کار بر پیش آمده است.");
            }
        }

        public UpdateUserDto GetUserById(int userId)
        {
            return userRepository.GetUserById(userId);
        }

        public Result<UserDto> Login(string username, string password)
        {
            username = username.ToLower();
            var user = userRepository.Login(username);
            if (user is null)
            {
                return Result<UserDto>.Failure(message: "نام کاربری یا رمز عبور اشتباه است.");
            }
            if (user.Password != password)
            {
                return Result<UserDto>.Failure(message: "نام کاربری یا رمز عبور اشتباه است.");
            }
            return Result<UserDto>.Success(message: $"خوش اومدی {user.UserName} " , user);
        }

        public Result<bool> UpdateUser(UpdateUserDto user , int userId)
        {
            if (string.IsNullOrWhiteSpace(user.FirstName) ||
                string.IsNullOrWhiteSpace(user.LastName) ||
                string.IsNullOrWhiteSpace(user.UserName))
            {
                return Result<bool>.Failure(message: "فیلد های اجبرای باید کامل شوند .");
            }
            if (userRepository.IsUserNameExist(user.UserName))
            {
                return Result<bool>.Failure(message:"نام کاربری قبلا استفاده شده است");
            }

            if (!string.IsNullOrWhiteSpace(user.Password))
            {
                if (user.Password.Length < 8)
                {
                    return Result<bool>.Failure(message: "رمز عبور حداقل باید شامل 8 کاراکتر باشد.");
                }
            }
       
            if (userRepository.UpdateUser(user, userId))
            {
                return Result<bool>.Success(message:"تغییر اطلاعات با موفقیت انجام شد.");
            }
            else
            {
                return Result<bool>.Failure(message:"تغییر اطلاعات با موفقت انجام نشد.");
            }
        }

        public List<ShowUsersListDto> UsersList()
        {
            return userRepository.UsersList();
        }
    }
}
