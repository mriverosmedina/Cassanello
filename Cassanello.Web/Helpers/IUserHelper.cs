using Cassanello.Web.Datos.Entidades;
using Cassanello.Web.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cassanello.Web.Helpers
{
    public interface IUserHelper
    {
        Task<Usuario> GetUserByEmailAsync(string email);

        Task<IdentityResult> AddUserAsync(Usuario user, string password);

        Task CheckRoleAsync(string roleName);

        Task AddUserToRoleAsync(Usuario user, string roleName);

        Task<bool> IsUserInRoleAsync(Usuario user, string roleName);

        Task<SignInResult> LoginAsync(LoginViewModel Model);

        Task LogoutAsync();

        Task<bool> DeleteUserAsync(string email);

        Task<IdentityResult> UpdateUserAsync(Usuario usurio);

    }
}
