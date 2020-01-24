using Cassanello.Web.Datos.Entidades;
using Cassanello.Web.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cassanello.Web.Helpers
{
    public class UserHelper : IUserHelper
    {
        private readonly UserManager<Usuario> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<Usuario> _signInManager;


        public UserHelper(UserManager<Usuario> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<Usuario> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }


        public async Task<IdentityResult> AddUserAsync(Usuario user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task AddUserToRoleAsync(Usuario user, string roleName)
        {
            await _userManager.AddToRoleAsync(user, roleName);

        }

        public async Task CheckRoleAsync(string roleName)
        {
            var roleExists = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExists)
            {
                await _roleManager.CreateAsync(new IdentityRole
                {
                    Name = roleName
                });
            }
        }

        public async Task<Usuario> GetUserByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return user;
        }

        public async Task<bool> IsUserInRoleAsync(Usuario user, string roleName)
        {
            return await _userManager.IsInRoleAsync(user, roleName);
        }

        public Task<SignInResult> LoginAsync(LoginViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task LogoutAsync()
        {
            throw new NotImplementedException();
        }
    }
}
