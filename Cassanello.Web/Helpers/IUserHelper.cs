﻿using Cassanello.Web.Datos.Entidades;
using Microsoft.AspNetCore.Identity;
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
    }
}
