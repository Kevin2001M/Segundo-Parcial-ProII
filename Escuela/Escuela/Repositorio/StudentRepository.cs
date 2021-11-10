using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Escuela.Data;
using Escuela.Dominio;
using Escuela.Servicio;

namespace Escuela.Repositorio
{
    public class StudentRepository : IStudent
    {
        private ApplicationDbContext app;

        public StudentRepository(ApplicationDbContext app)
        {
            this.app = app;
        }

        public void Buscar(Students s)
        {
            app.Students.Find(s);
        }

        public void Delete(Students s)
        {
            app.Students.Remove(s);
            app.SaveChanges();
        }

        public void Insertar(Students s)
        {
            app.Add(s);
            app.SaveChanges();
        }

        public List<Students> ListaEstudiantes()
        {
            return app.Students.ToList();
        }

        public void Update(Students s)
        {
            app.Update(s);
            app.SaveChanges();
        }

        public void Update(int id, Students s)
        {
            app.Update(s);
            app.SaveChanges();
        }

        public void Update(int id, Enrollment s)
        {
            app.Update(s);
            app.SaveChanges();
        }
    }
}
