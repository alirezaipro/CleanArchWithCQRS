using Application.Products.Commands;
using Application.Products.Queries.GetProductById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

public class ProductController
    (ISender sender)
    : ApiController(sender)
{
    #region Create

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductRequestDto model,
        CancellationToken cancellationToken)
    {
        var command = new CreateProductCommand()
        {
            Description = model.Description,
            Price = model.Price,
            Tags = model.Tags,
            Title = model.Title,
        };

        var result = await sender.Send(command, cancellationToken);

        return Ok(result.Id);
    }

    #endregion

    #region Get

    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var query = new GetProductByIdQuery()
        {
            Id = id
        };

        var result = await sender.Send(query, cancellationToken);

        return Ok(result);
    }

    #endregion
}