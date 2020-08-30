using Apteka.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace pierwszaPodpiecieEntityframework.Database
{
    public abstract class baseRepository<Entity> : IRepository<Entity>  where Entity : BaseEntity
    {
        // tworzenie konstruktora aby polaczyc sie z baza
        // protected po to zeby klasy dziedziczase mogly korzystac po tej zmiennej
        protected AptekaDbContext dbContext;


        // wziecie z bazy tabelki zeby latwiej odowolywac sie w funkcjach
        // abstract oznacza ze klasy dziedziczace beda musialy nadpisac zeby kazda miala swoja tabelke
        protected abstract DbSet<Entity> DbSet { get; }
        
        public baseRepository(AptekaDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public List<Entity> GetAll()
        {
            var list = new List<Entity>();
            var entities = DbSet;
            foreach (var entity in entities)
                list.Add(entity);
            return list;
        }

        public bool SaveChanges()
        {
            return dbContext.SaveChanges() > 0;
        }

        public bool AddNew(Entity entity)
        {
            DbSet.Add(entity);

            return SaveChanges();
        }

        public bool Delete(Entity entity)
        {
            var foundEntity = DbSet.FirstOrDefault(x => x.Id == entity.Id);
            if (foundEntity != null)
            {
                DbSet.Remove(foundEntity);
                return SaveChanges();
            }

            return false;
        }

    }
}
