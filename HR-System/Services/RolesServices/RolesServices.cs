using HR_System.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.RolesServices
{
    public class RolesServices : IRolesServices
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<IdentityUser> userManager;

        public RolesServices(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }
        public async Task<bool> Create(IdentityRole model)
        {
            try
            {
                var result = await roleManager.CreateAsync(model);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Delete(string id)
        {
            try
            {
                var role = await GetByID(id);
                if (role != null)
                {
                    var result = await roleManager.DeleteAsync(role);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> Edit(IdentityRole model)
        {
            try
            {
                var role = await GetByID(model.Id);
                if (role != null)
                {
                    role.Name = model.Name;
                    var result = await roleManager.UpdateAsync(role);
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {
                return true;
            }
        }


        public IQueryable<IdentityRole> GetAll()
        {
            var roles = roleManager.Roles;
            return roles;
        }

        public async Task<IdentityRole> GetByID(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            return role;
        }
    }
}
