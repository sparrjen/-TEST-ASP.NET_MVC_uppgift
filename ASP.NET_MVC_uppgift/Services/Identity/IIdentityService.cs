using ASP.NET_MVC_uppgift.Data;
using ASP.NET_MVC_uppgift.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_MVC_uppgift.Services.Identity
{
    public interface IIdentityService
    {
        Task CreateRootAccountAsync();

        Task CreateNewRole(string roleName);
        Task<IdentityResult> CreateNewUserAsync(AppUser user, string password);
        Task AddUserToRole(AppUser user, string roleName);

        IEnumerable<AppUser> GetAllUsers();

        IEnumerable<IdentityRole> GetAllRoles();

        Task<IEnumerable<UserViewModel>> GetAllUsersWithRolesAsync();

    }
}
