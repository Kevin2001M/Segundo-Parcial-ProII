using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Escuela.Dominio;

namespace Escuela.Servicio
{
   public interface IRollements
    {
        List<Enrollment> UnionDeTablas();

        void Insertar(Enrollment e);

        void Delete(Enrollment e);

        void Buscar(Enrollment e);
    }
   
}
