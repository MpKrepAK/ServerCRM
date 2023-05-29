using CRM_Server_Side.Models.Database.Entitys;
using CRM_Server_Side.Models.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CRM_Server_Side.Controllers;

[ApiController]
[Route("employees")]
public class EmployeeCRUDController
{
    private readonly ILogger<EmployeeCRUDController> _logger;
    private readonly IEmployeeRepository _employeeRepository;
    
    public EmployeeCRUDController(ILogger<EmployeeCRUDController> logger, IEmployeeRepository employeeRepository)
    {
        _logger = logger;
        _employeeRepository = employeeRepository;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var list = await _employeeRepository.GetAll();
            return new OkObjectResult(list);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new BadRequestResult();
        }
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var list = await _employeeRepository.GetById(id);
            return new OkObjectResult(list);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new BadRequestResult();
        }
    }
    [HttpPost]
    public async Task<IActionResult> Add(Employee entity)
    {
        bool res = await _employeeRepository.Add(entity);
        if (res)
        {
            return new OkResult();
        }
        else
        {
            return new BadRequestResult();
        }
    }
    [HttpPatch("{id}")]
    public async Task<IActionResult> Update(int id, Employee entity)
    {
        bool res = await _employeeRepository.Update(id, entity);
        if (res)
        {
            return new OkResult();
        }
        else
        {
            return new BadRequestResult();
        }
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        bool res = await _employeeRepository.Delete(id);
        if (res)
        {
            return new OkResult();
        }
        else
        {
            return new BadRequestResult();
        }
    }
}