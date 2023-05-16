using DatabaseAPI.Models.Commands.ProductCategories;
using DatabaseAPI.Models.DTO.ProductCategories;
using DatabaseAPI.Models.Queries.ProductCategories;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace DatabaseAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CategoryController : ControllerBase
  {

    private readonly IMediator _mediator;

    public CategoryController(IMediator mediator)
    {
      _mediator = mediator;
    }

    // GET: api/<CategoryController>
    [HttpGet]
    public async Task<IActionResult> Get()
    {
      var list = await _mediator.Send(new ProductCategoryListQuery());
      return new JsonResult(list);
    }

    // GET api/<CategoryController>/5
    [HttpGet("{id}")]
    public async Task<ProductCategoryDetailsDTO> Get(int id)
    {
      ProductCategoryDetailsQuery query = new ProductCategoryDetailsQuery() { Id = id };
      return await _mediator.Send(query);
    }

    // POST api/<CategoryController>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CategoryCreateCommand command)
    {
      ProductCategoryDTO category = await _mediator.Send(command);
      return new JsonResult(category);
    }

    // PUT api/<CategoryController>/5
    [HttpPut]
    public async Task<IActionResult> Put([FromBody] UpdateCategoryCommand command)
    {
      ProductCategoryDTO category = await _mediator.Send(command);
      return new JsonResult(category);
    }

    // DELETE api/<CategoryController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      await _mediator.Send(new DeleteCategoryCommand() { Id = id });
      return Ok();
    }
  }
}
