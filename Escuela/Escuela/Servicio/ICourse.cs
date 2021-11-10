using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Escuela.Dominio;

namespace Escuela.Servicio
{
    public interface ICourse
    {
       void Insertar(Course c);

        void Delete(Course c);

        void Buscar(Course c);

        void Update(int id, Students s);

        ICollection<Course> ListarCursos();
        void Update(int id, Course c);
    }
}
