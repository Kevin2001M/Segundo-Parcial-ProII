using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Escuela.Data;
using Escuela.Dominio;
using Escuela.Servicio;
using Microsoft.EntityFrameworkCore;

namespace Escuela.Repositorio
{
    public class EnrollmntRepository : IRollements
    {
        private ApplicationDbContext bd;

        public EnrollmntRepository(ApplicationDbContext bd)
        {
            this.bd = bd;
        }

        public void Buscar(Enrollment e)
        {
            throw new NotImplementedException();
        }

        public void Delete(Enrollment e)
        {
            throw new NotImplementedException();
        }


        public void Insertar(Enrollment e)
        {
            bd.Add(e);
            bd.SaveChanges();
        }

        public List<Enrollment> UnionDeTablas()
        {
            var union = bd.Enrollments.Include(e => e.Students).Include(c => c.Course).ToList();

            return union;
        }
      
    }
}
