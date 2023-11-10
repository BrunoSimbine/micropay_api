using micropay.Dto;
using micropay.Models;
using micropay.ViewModels;

namespace micropay.Services.UserService;

public interface IUserService
{
    Guid? GetId();

    List<UserViewModel> GetUsers(List<User> users);
    User Create(UserDto userDto);
}