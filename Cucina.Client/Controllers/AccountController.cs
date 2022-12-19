using Cucina.Application.Interfaces.Base;
using Cucina.Application.Utilities.Extensions;
using Cucina.Application.Utilities.Generators;
using Cucina.Application.Utilities.Security;
using Cucina.Core.Entities;
using Cucina.Core.ViewModels.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Cucina.Client.Controllers;

public class AccountController : Controller
{
    #region ===[ Private Members ]=============================================================

    private readonly IUnitOfWork _unitOfWork;

    #endregion

    #region ===[ Constructor ]=================================================================

    public AccountController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    #endregion

    #region ===[ Public Methods ]==============================================================

    #region Register

    [HttpGet]
    public async Task<IActionResult> Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<JsonResult> Register(RegisterViewModel register)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "در روند عملیات مشکلی رخ داده است");
            }

            var isExistUserByEmail =
                await _unitOfWork.Users.IsExistUserByEmail(register.Email!.SanitizeText().ToLower());
            
            var hashedPassword = PasswordHelper.EncodePasswordMd5(register.Password!);
            
            if (isExistUserByEmail) ModelState.AddModelError(string.Empty, "کاربری با این ایمیل وجود دارد");
            
            var user = new User
            {
                Id = CodeGenerator.CreateId(),
                RoleId = null,
                UserName = register.UserName!.SanitizeText().ToLower(),
                FirstName = register.FirstName!.SanitizeText().ToLower(),
                LastName = register.LastName!.SanitizeText().ToLower(),
                BirthDate = null,
                Email = register.Email!.SanitizeText().ToLower(),
                Password = hashedPassword,
                RePassword = hashedPassword,
                Mobile = null,
                Address = null,
                Biography = null,
                SocialMedia = null,
                EmailConfirmationCode = null,
                SmsconfirmationCode = null,
                IsEmailConfirmed = false,
                IsSmsconfirmed = false,
                RegistrationDate = DateTime.Parse(DateTime.Now.ToShamsi()),
                ModificationDate = null,
                IsDeleted = false
            };

            if (ModelState.Count.Equals(0))
            {
                await _unitOfWork.Users.AddAsync(user);
            }

            return new JsonResult(new { model = register, error = ModelState });
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    #endregion

    #region Login

    #endregion

    #region Logout

    #endregion

    #region Email Activation

    #endregion

    #region Forgot Password

    #endregion

    #region Reset Password

    #endregion

    #endregion
}