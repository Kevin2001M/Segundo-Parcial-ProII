﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Escuela.Data;
using Escuela.Dominio;
using Escuela.Servicio;

namespace Escuela.Repositorio
{
    public class CourseRepositorio : ICourse 
    {
        private ApplicationDbContext app;
      
        public CourseRepositorio(ApplicationDbContext app)
        {
            this.app = app;
        }

        public void Buscar(Course c)
        {
            app.Courses.Find(c);
            
        }

        public void Delete(Course c)
        {
            app.Courses.Remove(c);
        }

        public void Insertar(Course c)
        {
            app.Add(c);
            app.SaveChanges();

        }

        public List<Course> ListarCursos()
        {
            return app.Courses.ToList();

        }


        public void Update(int id, Course c)
        {
            app.Update(c);
            app.SaveChanges();
        }

        public void Update(int id, Students s)
        {
            throw new NotImplementedException();
        }

        ICollection<Course> ICourse.ListarCursos()
        {
            return app.Courses.ToList();
        }
    }
}
