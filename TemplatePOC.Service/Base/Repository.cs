using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TemplatePOC.Service.Base
{
    public class Repository<TId,TEntity> where TEntity : class
        where TId : new()
    {
        internal DbContext context;
        internal DbSet<TEntity> dbSet;

        public Repository(DbContext ctx)
        {
            this.context = ctx;
            this.dbSet = this.context.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null, 
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "") {

            IQueryable<TEntity> query = this.dbSet;

            if (filter != null)
                query = query.Where(filter);

            foreach(var includeProperty in includeProperties.Split(new char[] { ','}, StringSplitOptions.RemoveEmptyEntries))
                query = query.Include(includeProperty);

            if (orderBy != null)
                return orderBy(query);

            return query;
        }

        public virtual TEntity GetById(TId Id) {
            return this.dbSet.Find(new TId[] { Id});
        }

        public virtual void Insert(TEntity entity) {
            dbSet.Add(entity);
        }

        public virtual void Delete(TEntity entity) {
            if (this.context.Entry(entity).State == EntityState.Detached) {
                this.dbSet.Attach(entity);
            }

            this.dbSet.Remove(entity);
        }

        public virtual void Update(TEntity entity, Expression<Func<TEntity, object>>[] updateProperties) {
            this.context.Configuration.ValidateOnSaveEnabled = false;

            this.context.Entry<TEntity>(entity).State = EntityState.Unchanged;

            if (updateProperties != null)
            {
                foreach (var property in updateProperties)
                {
                    this.context.Entry<TEntity>(entity).Property(property).IsModified = true;
                }
            }
        }

        public void SaveChanges() {
            this.context.SaveChanges();


        }
    }
}
