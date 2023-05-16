using DatabaseAPI.Database.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace DatabaseAPI.Database.Interceptors
{
  public class ModificationDateInterceptor : SaveChangesInterceptor
  {
    protected virtual void SetModificationDate(IModificationTracked entry)
    {
      entry.ModificationDate = DateTime.Now;
    }

    private void ExecuteInternal(DbContextEventData eventData, InterceptionResult<int> result)
    {
      var modifiedEntries = eventData.Context.ChangeTracker.Entries()
      .Where(x => x.State == EntityState.Modified)
      .Where(x => typeof(IModificationTracked).IsAssignableFrom(x.Entity.GetType()));

      foreach (var modifiedEntry in modifiedEntries)
      {
        SetModificationDate((IModificationTracked)modifiedEntry.Entity);
      }
    }

    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
      ExecuteInternal(eventData, result);
      return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
      ExecuteInternal(eventData, result);
      return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
  }
}
