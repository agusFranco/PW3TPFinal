using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PW3.TPFinal.Repositorio.Contratos;

namespace PW3.TPFinal.Repositorio.Implementaciones
{
    public abstract class BaseRepositorio<TEntidad, TId> : IBaseRepositorio<TEntidad, TId> where TEntidad : class
    {
        protected DbSet<TEntidad> Set;

        protected DbContext Context { get; }

        protected BaseRepositorio(DbContext context)
        {
            this.Context = context;
            this.Set = context.Set<TEntidad>();
        }

        public virtual TEntidad Obtener(TId id)
        {
            return this.Set.Find(id);
        }

        public virtual ICollection<TEntidad> Obtener()
        {
            return this.Set.ToList();
        }

        public virtual void Agregar(TEntidad entity)
        {
            this.Set.Add(entity);
        }

        public virtual void Actualizar(TEntidad entity)
        {
            this.Set.Update(entity);
        }

        public virtual void Borrar(TEntidad entity)
        {
            this.Set.Remove(entity);
        }

        public virtual int Guardar()
        {
            return this.Context.SaveChanges();
        }
    }
}
