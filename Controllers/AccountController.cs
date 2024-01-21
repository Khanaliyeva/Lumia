using Lumia.Helpers;
using Lumia.Models;
using Lumia.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Lumia.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signInManager;
		private readonly RoleManager<IdentityRole> _roleManager;

		public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
			_userManager = userManager;
			_signInManager = signInManager;
			_roleManager = roleManager;
		}


        //GunelKh sade rolesuz Gunel098  gunel@gmail.com
        //g@gmail.com  Gunel1 Gunel000 ADMIN
        //fuad2007@gmail.com  FuadKh Fuad123 user


        public IActionResult Register()
		{
			return View();
		}


		[HttpPost]
		public async Task<IActionResult> Register(RegisterVm vm)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}
			AppUser user=new AppUser()
			{
				Name = vm.Name,
				Surname = vm.Surname,
				UserName = vm.UserName,
				Email = vm.Email,
			};
			
			var result =await _userManager.CreateAsync(user, vm.Password);
			if (!result.Succeeded)
			{
				foreach(var item in result.Errors)
				{
					ModelState.AddModelError("", item.Description);
				}
			}
			await _userManager.AddToRoleAsync(user,UserRole.User.ToString());
			return RedirectToAction("Index","Home");
		}



		public IActionResult Login()
		{
			return View();
		}



		[HttpPost]
		public async Task<IActionResult> Login(LoginVm vm)
		{
			var user =await _userManager.FindByEmailAsync(vm.UserNameOrEmail);
			if(user == null)
			{
				user=await _userManager.FindByNameAsync(vm.UserNameOrEmail);
				if( user == null)
				{
					throw new Exception("Username ve ya Password sehvdi");
				}
			}
			var result = await _signInManager.CheckPasswordSignInAsync(user, vm.Password, false);
			if (result == null)
			{
				throw new Exception("Username ve ya Password sehvdi");
			}
			await _signInManager.SignInAsync(user, false);
			return RedirectToAction("Index", "Home");
		}



		public IActionResult LogOut()
		{
			_signInManager.SignOutAsync();
			return RedirectToAction("Index", "Home");
		}



		public async Task<IActionResult> CreateRole()
		{
            foreach (UserRole role in Enum.GetValues(typeof(UserRole)))
            {
                if(!await _roleManager.RoleExistsAsync(role.ToString()))
				{
					await _roleManager.CreateAsync(new IdentityRole()
					{
						Name=role.ToString()
					});
				}
            }
			return RedirectToAction("Index","Home");
        }
	}
}
