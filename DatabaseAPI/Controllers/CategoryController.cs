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
    // FYI: Mediator oferuje dedykowane interfejsy do wysyłania requests (ISender) i notifications (IPublisher).
    // ostatnio zacząłem w kontrolerach używać ISender, ale po za tym, że nie widzę metody Publish, to jakichś większych zalet nie widzę :)
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
      // Puryści CQRSa twierdzą, że command nie powinien zwracać niczego. Od tego jest query.
      // Osobiście staram się tego trzymać, ale w określonych przypadkach stosuję wyjątki.
      // Jednym z nich jest operacja "Zaloguj użytkownika", która musi zwrócić kontekst zalogowanego usera (choćby ten durny access token) i jakoś nie pasuje mi to do Query
      // Drugim jest przykład bazy danych, jak twoja, czyli takiej w której to baza generuje klucze główne (int).
      // Tego staram się unikać używając Guidów jako Id i przekazując je jako pole w command.
      // W czystym REST API, sugerowaną odpowiedzią na POST, jest HTTP 201 Created, a ten jako argument potrzebuje linku do GetById utworzonego obiektu. 
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
      return Ok(); // Alternatywnie dla DELETE można zwracać HTTP 204 No Content
    }
  }
}
