using System;
using System.Collections.Generic;
using System.Linq;
using PW3.TPFinal.Repositorio.Data;

namespace PW3.TPFinal.Negocio.Modelos.Data
{
    public class EventoRecetasModel
    {
        public EventoRecetasModel()
        {
        }

        public EventoRecetasModel(Evento evento)
        {
            this.IdEvento = evento.IdEvento;
            this.Nombre = evento.Nombre;
            this.Fecha = evento.Fecha;
            this.CantidadComensales = evento.CantidadComensales;
            this.Ubicacion = evento.Ubicacion;
            this.Precio = evento.Precio;
            this.Foto = evento.Foto;
            this.Recetas = evento.EventosReceta.Select(x => new RecetaModel(x.IdRecetaNavigation)).ToList();  
        }

        public int IdEvento { get; set; }

        public string Nombre { get; set; }

        public DateTime Fecha { get; set; }

        public int CantidadComensales { get; set; }

        public string Ubicacion { get; set; }

        public string Foto { get; set; }

        public decimal Precio { get; set; }

        public IList<RecetaModel> Recetas { get; set; }        
    }
}
