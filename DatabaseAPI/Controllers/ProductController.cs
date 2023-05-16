using DatabaseAPI.Models.Commands.Products;
using DatabaseAPI.Models.DTO.Products;
using DatabaseAPI.Models.Queries.Products;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ProductController : ControllerBase
  {
    private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

    // GET: api/<ProductController>
    // TODO Add pagination support
    // TODO Add search options
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var results = await _mediator.Send(new ProductListQuery());

        return new JsonResult(new ProductListDTO
        {
          Count = results.Count(),
          Items = results
        });
    }

    // GET api/<ProductController>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
      var result = await _mediator.Send(new ProductDetailsQuery { Id = id });
      return new JsonResult(result);
    }

    // POST api/<ProductController>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ProductCreateCommand command)
    {
      var product = await _mediator.Send(command);
      return new JsonResult(product);
    }

    // PUT api/<ProductController>/5
    [HttpPut]
    public async Task<IActionResult> Put([FromBody] UpdateProductCommand command)
    {
      var product = await _mediator.Send(command);
      return new JsonResult(product);
    }

    // DELETE api/<ProductController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      await _mediator.Send(new DeleteProductCommand() { Id = id });
      return Ok();
    }
  }
}
