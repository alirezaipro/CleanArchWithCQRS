using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ApiController
(ISender sender)
    : ControllerBase
{
}