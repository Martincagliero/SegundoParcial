using AccesoDatos.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccesoDatos.Repositories
{
    public class CancionRepository : GenericRepository<Cancion>
    {
       
       public List<Cancion> CancionesMasLargas()
        {
            return _context.Cancion
                .OrderByDescending(c => c.Duracion)

                .ToList();
        }


        public int CantidadTotalCanciones()
        {
    
   
            return _context.Cancion.Count();
        }


        public List<Cancion> CancionesOrdenadasXTitulo()
        {
            return _context.Cancion
                .OrderBy(c => c.Titulo)

                .ToList();
        }

        public bool VerificarExistenCanciones()
        {
            return _context.Cancion.Any();
        }
       
    }
    
        


    }

