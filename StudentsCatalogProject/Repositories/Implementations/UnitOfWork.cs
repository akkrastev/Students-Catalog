using System;
using Data.Context;
using Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implementations
{
    public class UnitOfWork : IDisposable
    {
        private StudentSystemDbContext context = new StudentSystemDbContext();
        private GenericRepository<Student> studentRepository;
        private GenericRepository<Nationality> nationalityRepository;
        private GenericRepository<Faculty> facultyRepository;

        public GenericRepository<Student> StudentRepository
        {
            get
            {

                if (this.studentRepository == null)
                {
                    this.studentRepository = new GenericRepository<Student>(context);
                }
                return studentRepository;
            }
        }

        public GenericRepository<Faculty> FacultyRepository
        {
            get
            {
                if (this.facultyRepository == null)
                {
                    this.facultyRepository = new GenericRepository<Faculty>(context);
                }
                return facultyRepository;
            }
        }

        public GenericRepository<Nationality> NationalityRepository
        {
            get
            {
                if (this.nationalityRepository == null)
                {
                    this.nationalityRepository = new GenericRepository<Nationality>(context);
                }
                return nationalityRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
