using AutoMapper;
using Essence.Business.Dtos.AppUserDtos;
using Essence.Business.Dtos.EmailDtos;
using Essence.Business.Exceptions;
using Essence.Business.Services.Abstractions;
using Essence.Core.Entities;
using Essence.Core.Enum;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;

namespace Essence.Business.Services.Implementations;

internal class AuthService : IAuthService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly IMapper _mapper;
    private readonly IEmailService _emailService;

    public AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, 
        IHttpContextAccessor contextAccessor, 
        IMapper mapper,
        IEmailService emailService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _contextAccessor = contextAccessor;
        _mapper = mapper;
        _emailService = emailService;
    }
    public async Task<bool> LoginAsync(LoginDto dto, ModelStateDictionary ModelState)
    {
        if (!ModelState.IsValid)
            return false;

        var user = await _userManager.FindByEmailAsync(dto.EmailOrUsername);

        if (user is null)
            user = await _userManager.FindByNameAsync(dto.EmailOrUsername);

        if (user is null)
        {
            ModelState.AddModelError(" ", "User not found");
            return false;
        }

        if (user.EmailConfirmed is false)
        {
            ModelState.AddModelError(" ", "Email is not true");

            await _sendConfirmEmailToken(user);
            return false;
        }

        var result = await _signInManager.PasswordSignInAsync(user, dto.Password, dto.RememberMe, true);

        if (!result.Succeeded)
        {
            if (result.IsLockedOut)
            {
                ModelState.AddModelError("", "User is blocked");
                return false;
            }

            ModelState.AddModelError("", "Not true password");
            return false;
        }

        return true;
    }
 
    public async Task<bool> ChangeUserRoleAsync(UserChangeRoleDto dto)
    {
        var user = await _userManager.FindByIdAsync(dto.UserId);

        if (user is null)
            throw new InvalidInputException("Gözlənilməz xəta baş verdi yenidən sınayın.Təsdiqləmə linki yenidən göndərilmişdir.");

        var role = Enum.GetNames(typeof(IdentityRoles)).ToList().FirstOrDefault(x => x.ToLower() == dto.RoleName.ToLower());

        if (string.IsNullOrWhiteSpace(role))
            throw new InvalidInputException("Gözlənilməz xəta baş verdi yenidən sınayın.Təsdiqləmə linki yenidən göndərilmişdir.");

        await _userManager.AddToRoleAsync(user, role);

        return true;
    }

    public async Task<List<UserGetDto>> GetAllUserAsync()
    {
        var users = await _userManager.Users.ToListAsync();

        var dtos = _mapper.Map<List<UserGetDto>>(users);

        for (int i = 0; i < dtos.Count; i++)
        {
            dtos[i].Role = (await _userManager.GetRolesAsync(users[i])).FirstOrDefault() ?? "undifiend";
        }

        return dtos;
    }

    public async Task<UserGetDto> GetUserAsync(string id)
    {
        var user = await _userManager.FindByIdAsync(id);

        if (user is null)
            throw new NotFoundException((nameof(NotFoundException)));

        var dto = _mapper.Map<UserGetDto>(user);

        return dto;
    }

    public async Task<bool> LogoutAsync()
    {
        if (!_contextAccessor.HttpContext?.User.Identity?.IsAuthenticated ?? false)
            return false;

        await _signInManager.SignOutAsync();

        return true;
    }

    public async Task<bool> RegisterAsync(RegisterDto dto, ModelStateDictionary ModelState)
    {
        if (!ModelState.IsValid)
            return false;


        var isExist = await _userManager.Users.AnyAsync(x => x.NormalizedEmail == dto.Email.ToUpper());

        if (isExist)
        {
            ModelState.AddModelError("", ("Error email"));
            return false;
        }

        isExist = await _userManager.Users.AnyAsync(x => x.NormalizedUserName == dto.Username.ToUpper());

        if (isExist)
        {
            ModelState.AddModelError("", ("Error Username"));
            return false;
        }

        var user = _mapper.Map<AppUser>(dto);

        user.EmailConfirmed = true;

        var result = await _userManager.CreateAsync(user, dto.Password);

        if (!result.Succeeded)
        {
            ModelState.AddModelError("", string.Join(",", result.Errors.Select(x => x.Description)));
            return false;
        }

        await _userManager.AddToRoleAsync(user, IdentityRoles.User.ToString());

        //await _sendConfirmEmailToken(user);

        await _signInManager.SignInAsync(user, isPersistent: false);

        return true;
    }

    public async Task<bool> VerifyEmailAsync(VerifyEmailDto dto, ModelStateDictionary ModelState)
    {
        if (!ModelState.IsValid)
            throw new InvalidInputException((nameof(InvalidInputException)));


        var user = await _userManager.FindByEmailAsync(dto.Email);

        if (user is null)
            throw new InvalidInputException((nameof(InvalidInputException)));

        var result = await _userManager.ConfirmEmailAsync(user, dto.Token);


        if (!result.Succeeded)
        {
            await _sendConfirmEmailToken(user);

            throw new InvalidInputException(("Testiq olumamish email"));
        }

        await _signInManager.SignInAsync(user, isPersistent: false);
        //await _subscriberService.CreateAsync(new SubscriberCreateDto { Email = dto.Email }, ModelState);

        return true;
    }


    private async Task _sendConfirmEmailToken(AppUser user)
    {
        throw new NotImplementedException();
    }
}
