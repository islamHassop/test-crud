using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using testCREST.viewmodels;

namespace testCREST.Controllers
{
    public class AcountController : Controller
    {
        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signInManager;
        public AcountController(UserManager<IdentityUser> _userManager, SignInManager<IdentityUser> _signInManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
        }
        public IActionResult Registration()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registration(VM_UserAcount newuser)
        {

            if (ModelState.IsValid == true)
            {
                IdentityUser user = new IdentityUser();
                user.UserName=newuser.UserName;
                user.Email=newuser.Email;
                IdentityResult result = await userManager.CreateAsync(user, newuser.Password);
                if (result.Succeeded)
                {
                  await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Create","Student");
                }
                else
                {
                    foreach(var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }

                }
            }


            return View(newuser);
        }
    }
}
