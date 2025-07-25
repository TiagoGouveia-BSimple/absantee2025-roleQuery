using Application.DTO;
using Application.IService;
using Microsoft.AspNetCore.Mvc;

namespace InterfaceAdapters.Controller;

[Route("api/roles")]
[ApiController]
public class RoleController : ControllerBase
{
    private readonly IRoleService _roleService;
    List<string> _errorMessages = new List<string>();

    public RoleController(IRoleService roleService)
    {
        _roleService = roleService;
    }

    // Get: api/roles
    [HttpGet]
    public async Task<ActionResult<IEnumerable<RoleDTO>>> GetAllRoles()
    {
        var result = await _roleService.GetAll();
        return Ok(result);
    }

    // Get: api/roles/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<RoleDTO>> GetById(Guid id)
    {
        var result = await _roleService.GetById(id);

        if (result == null)
            return NotFound(result);

        return Ok(result);
    }
}
