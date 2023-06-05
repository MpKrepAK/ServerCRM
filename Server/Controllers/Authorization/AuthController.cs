using System.Security.Claims;
using AutoMapper;
using CRM_Server_Side.Models.Database;
using CRM_Server_Side.Models.Database.Entitys;
using CRM_Server_Side.Models.Database.Entitys.Enums;
using CRM_Server_Side.Models.Mapping.Entitys;
using CRM_Server_Side.Models.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRM_Server_Side.Controllers.Authorization;

[Route("auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ShopContext _context;

    public AuthController(IMapper mapper, ShopContext context)
    {
        _mapper = mapper;
        _context = context;
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegistrationModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var cust = await _context.Customers.FirstOrDefaultAsync(x => x.Email == model.Email);
        if (cust!=null)
        {
            return BadRequest();
        }

        Customer mapped = _mapper.Map<Customer>(model);
        mapped.DateOfRegistration = DateTime.Now.ToUniversalTime();
        mapped.Role = Roles.User;
        
        _context.Customers.Add(mapped);
        await _context.SaveChangesAsync();
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

        Customer customer = await _context.Customers.FirstOrDefaultAsync(x=>x.Email==model.Email&&x.Password==model.Password);
        
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