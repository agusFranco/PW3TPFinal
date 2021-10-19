using System.Collections.Generic;

namespace PW3.TPFinal.Repositorio.Contratos
{
    public interface IBaseRepositorio<TEntidad, in TId> where TEntidad : class
    {
        TEntidad Obtener(TId id);

        ICollection<TEntidad> Obtener();

        void Agregar(TEntidad entity); 

        void Actualizar(TEntidad entity);

        void Borrar(TEntidad entity);

        int Guardar();
    }
}
