using Company.Project.Web.Models;
using Company.Project.Web.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Project.Web.Controllers
{
    public class AccountController : Controller
    {

        private readonly IAccountRepository _accountRepository;
        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        [Route("Signup")]
        public IActionResult Signup()
        {
            return View();
        }
        [Route("Signup")]
        [HttpPost]
        public async Task<IActionResult> Signup(SignUpUser userModel)
        { 
            if(ModelState.IsValid)
            {
                var result = await _accountRepository.CreateUserAsync(userModel);
                if(!result.Succeeded)
                {
                    foreach(var errorMessage in result.Errors)
                    {
                        ModelState.AddModelError("", errorMessage.Description);
                    }
                    return View(userModel);
                }
                ModelState.Clear();
            }
            return View();

        }
        [Route(" LogIn")]
        public IActionResult LogIn()
        {
            return View();
        }
        [Route(" LogIn")]
        [HttpPost]
        public async Task<IActionResult> LogIn(SignInModel signInModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountRepository.PasswordSignInAsync(signInModel);
                if (result.Succeeded)
                {
                    HttpContext.Session.SetString("Email", signInModel.Email);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invalid Credentials");
            }
            return View(signInModel);
           

        }
        [Route("logout")]
        public async Task<IActionResult>Logout()
        {
           HttpContext.Session.Remove("Email");
            await _accountRepository.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}
