using System.Linq;
using Kruchy.Model.DataTypes.Database;
using Kruchy.Zakupy.Dao.Context;
using Microsoft.EntityFrameworkCore;

namespace Kruchy.Zakupy.Dao.Database
{
    class UnitOfWork : IUnitOfWork
    {
        private readonly ZakupyContext context;

        private int counter = 0;

        public UnitOfWork(
            ZakupyContext context)
        {
            this.context = context;
        }

        public void Finish()
        {
            counter--;
            if (counter == 0)
                context.SaveChanges();
        }

        public void Rollback()
        {
            context.ChangeTracker.DetectChanges();

            //get all entries that are changed
            var entries = context.ChangeTracker.Entries().Where(e => e.State != EntityState.Unchanged).ToList();

            //somehow try to discard changes on every entry
            foreach (var dbEntityEntry in entries)
            {
                var entity = dbEntityEntry.Entity;

                if (entity == null) continue;

                if (dbEntityEntry.State == EntityState.Added)
                {
                    RemoveObjectFromContext(entity);
                    //if entity is in Added state, remove it. (there will be problems with Set methods if entity is of proxy type, in that case you need entity base type
                    //var set = context.Set(entity.GetType());
                    //set.Remove(entity);
                }
                else if (dbEntityEntry.State == EntityState.Modified)
                {
                    //entity is modified... you can set it to Unchanged or Reload it form Db??
                    dbEntityEntry.Reload();
                }
                else if (dbEntityEntry.State == EntityState.Deleted)
                    //entity is deleted... not sure what would be the right thing to do with it... set it to Modifed or Unchanged
                    dbEntityEntry.State = EntityState.Modified;
            }
        }

        private void RemoveObjectFromContext(object parameterObject)
        {
            var propertyDbSet =
                context
                    .GetType()
                        .GetProperties()
                            .Where(o => o.PropertyType == typeof(DbSet<>))
                            .Single(o => o.PropertyType.GetGenericArguments()[0] == parameterObject.GetType());

            var dbSet = propertyDbSet.GetValue(context);

            var removeMethod = dbSet.GetType().GetProperty("Remove");
            removeMethod.GetMethod.Invoke(dbSet, new object[] { parameterObject });
        }

        public void Start()
        {
            counter++;
        }
    }
}
