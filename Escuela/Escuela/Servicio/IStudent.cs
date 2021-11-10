using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Escuela.Dominio;

namespace Escuela.Servicio
{
    public interface IStudent
    {
        void Insertar(Students s);

        void Delete(Students s);

        void Update(int id, Students s);

        void Buscar(Students s);

        List<Students> ListaEstudiantes();
        void Update(int id, Enrollment s);
    }
}
