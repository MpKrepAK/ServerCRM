using System.Security.Claims;
using AutoMapper;
using CRM_Server_Side.Models.Database.Entitys;
using CRM_Server_Side.Models.Database.Entitys.Enums;
using CRM_Server_Side.Models.Mapping.Entitys;
using CRM_Server_Side.Models.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace CRM_Server_Side.Controllers.Authorization;

[Route("auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ICustomerRepository _customerRepository;

    public AuthController(IMapper mapper, ICustomerRepository customerRepository)
    {
        _mapper = mapper;
        _customerRepository = customerRepository;
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegistrationModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        Customer mapped = _mapper.Map<Customer>(model);
        mapped.DateOfRegistration = DateTime.Now;
        mapped.Role = Roles.User;
        _customerRepository.Add(mapped);
        
        return Ok("Регистрация прошла успешно");
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginModel model)
    {
        // Проверяем валидность модели
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        Customer customer = await _customerRepository.GetByAuthData(model.Email,model.Password);
        
        if (customer == null)
        {
            return BadRequest("Пользователь не найден");
        }
        
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Email, customer.Email),
            new Claim(ClaimTypes.Role, customer.Role.ToString()),
            new Claim(ClaimTypes.NameIdentifier, customer.Id.ToString())
        };

        
        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        
        var principal = new ClaimsPrincipal(identity);
        var authProperties = new AuthenticationProperties
        {
            
        };

        
        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            principal,
            authProperties);

        return Ok("Авторизация прошла успешно");
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        // Выполняем выход пользователя
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return Ok("Выход выполнен");
    }
}