using AutoMapper;
using Foodies.APIs.DTOs.User;
using Foodies.APIs.Errors;
using Foodies.APIs.Extensions;
using Foodies.Core.Entities.Identity;
using Foodies.Core.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Foodies.APIs.Controllers
{
    public class AccountController : BaseAPIController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IAuthService _authService;
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;

        public AccountController(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            IAuthService authService,
            IEmailService emailService,
            IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authService = authService;
            _emailService = emailService;
            this._mapper = mapper;
        }


        [HttpPost("login")]  // POST: /api/account/login
        public async Task<ActionResult<UserDTO>> Login (LoginDTO model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
                return Unauthorized(new BaseErrorApiResponse(401, "Wrong Credintials."));

            var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
            if (result.Succeeded is false)
                return Unauthorized(new BaseErrorApiResponse(401, "Wrong Credintials."));

            return Ok(new UserDTO()
            {
                DisplayName = user.DisplayName,
                Email = user.Email,
                Token = await _authService.CreateTokenAsync(user)
            });
        }


        [HttpPost("register")]  // POST: api/account/register
        public async Task<ActionResult<UserDTO>> Register(RegisterDTO model)
        {
            var user = new AppUser()
            {
                DisplayName = model.DisplayName,
                //UserName = model.Email.Split("@")[0],
                UserName = model.UserName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
            };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
                return BadRequest(result.Errors);
                //return BadRequest(new BaseErrorApiResponse(400, (result.Errors.Select(E => E.Description)).Aggregate((currentMessage, Error) => $"{currentMessage},\n{Error}")));

            return Ok(new UserDTO()
            {
                DisplayName = user.DisplayName,
                Email = user.Email,
                Token = await _authService.CreateTokenAsync(user)
            });
        }


        [HttpPost("forgot-password")]  // POST: api/account/forgot-password
        public async Task<IActionResult> ForgotPassword(ForgotPasswordDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user is null)
                return NotFound(new BaseErrorApiResponse(404, "User not found"));

            var code = new Random().Next(100000, 999999).ToString();

            //await _userManager.RemoveClaimsAsync(user, await _userManager.GetClaimsAsync(user));

            await _userManager.AddClaimAsync(user, new Claim("PasswordResetCode", code));

            await _emailService.SendEmailAsync(model.Email, "Reset Password Code", $"Your reset Code is: {code}");

            return Ok(new {message = "reset code sent to you Email."});
        }


        [HttpPost("verify-reset-code")]
        public async Task<IActionResult> VerifyResetCode(VerifyCodeDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user is null)
                return NotFound(new BaseErrorApiResponse(404, "User Not found"));

            var claims = await _userManager.GetClaimsAsync(user);
            var code = claims.FirstOrDefault(C => C.Type == "PasswordResetCode")?.Value;

            if (code != model.Code)
                return BadRequest(new BaseErrorApiResponse(400, "Invalid Code"));

            return Ok("Code Verified");
        }


        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user is null)
                return NotFound(new BaseErrorApiResponse(404, "User not found"));

            var result = await _userManager.ResetPasswordAsync(user, await _userManager.GeneratePasswordResetTokenAsync(user), model.NewPassword);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok("Password Reset Successfully");
        }


        [Authorize]
        [HttpGet("profile")]
        public async Task<ActionResult<UserProfileDTO>> GetUserProfile()
        {
            var user = await _userManager.FindUserWithAddressAsync(User);

            var mappedUser = _mapper.Map<UserProfileDTO>(user);
            return Ok(mappedUser);
        }


        [Authorize]
        [HttpPost("update-address")]
        public async Task<ActionResult<AddressDTO>> UpdateAddress(AddressDTO newAddress)
        {
            var user = await _userManager.FindUserWithAddressAsync(User);

            var adddress = user?.Address;

            if (adddress != null)
            {
                user.Address = _mapper.Map<Address>(newAddress);
                user.Address.Id = adddress.Id;
            }
            else
                user.Address = new Address(newAddress.Country, newAddress.City, newAddress.Street);

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded) return BadRequest(result.Errors);
            
            return Ok(newAddress);
        }
    }
}
