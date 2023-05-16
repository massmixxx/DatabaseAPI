using AutoMapper;
using DatabaseAPI.Database;
using MediatR;
using DatabaseAPI.Models.DTO.ProductCategories;
using DatabaseAPI.Models.Commands.ProductCategories;
using Microsoft.EntityFrameworkCore;

namespace DatabaseAPI.BL.Handlers.ProductCategories
{
  public class UpdateProductCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, ProductCategoryDTO>
  {
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public UpdateProductCategoryCommandHandler(ApplicationDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    public async Task<ProductCategoryDTO> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
      // W sytuacji, gdy potrzebujesz zmienić jakieś pole w obiekcie pobieranym z DB po kluczu głównym, lepiej użyć FindAsync (i obsłużyć NULL).
      // Ta metoda ma to do siebie, że "z pudełka" wykorzystuje cache przy pobieraniu danych.
      // Ogólnie wszędzie tam, gdzie pojawia sę potrzeba pobrania rekordu po jego kluczu głównym Find będzie wydajniejsze niż First,
      // (a Single należałoby wogóle unikać przy potrzebie pobrania tylko 1 rekordu)
      var currCategory = await _context.Categories.FirstAsync(x => x.Id == request.Id);
      currCategory = _mapper.Map(request, currCategory);

      _context.Update(currCategory);
      await _context.SaveChangesAsync();

      return _mapper.Map<ProductCategoryDTO>(currCategory);
    }
  }
}
