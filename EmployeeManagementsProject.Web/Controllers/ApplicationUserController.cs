using EmployeeManagementsProject.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OA_DataAccess;
using System;
using System.Threading.Tasks;

namespace EmployeeManagementsProject.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicationUserController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _singInManager;

    public ApplicationUserController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _singInManager = signInManager;
    }

    [HttpPost]
    [Route("Register")]
    // POST : /api/ApplicationUser/Register
    public async Task<Object> PostApplicationUser(ApplicationUserModel model)
    {
        model.Role = "Customer";
        var applicationUser = new ApplicationUser()
        {
            UserName = model.UserName,
            Email = model.Email,
            FullName = model.FullName
        };

        try
        {
            var result = await _userManager.CreateAsync(applicationUser, model.Password);
            // await _userManager.AddToRoleAsync(applicationUser, model.Role);
            return Ok(result);
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
}
}
