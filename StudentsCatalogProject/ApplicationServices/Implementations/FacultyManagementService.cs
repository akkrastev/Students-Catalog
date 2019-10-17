using ApplicationServices.DTOs;
using Data.Context;
using Data.Entities;
using Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Implementations
{
    public class FacultyManagementService
    {

        private StudentSystemDbContext ctx = new StudentSystemDbContext();

        public List<FacultyDto> Get()
        {
            List<FacultyDto> facultyDto = new List<FacultyDto>();

            // use UnitOfWork
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                // foreach in the FacultyRepo instead of ctx
                foreach(var item in unitOfWork.FacultyRepository.Get())
                {
                    facultyDto.Add(new FacultyDto
                    {
                        Id = item.Id,
                        Name = item.Name,
                        City = item.City,
                        Address = item.Address

                    });
                }
            }

            return facultyDto;
        }

        public FacultyDto GetById(int id)
        {
            FacultyDto facultyDto = new FacultyDto();

            using(UnitOfWork unitOfWork = new UnitOfWork())
            {
                Faculty faculty = unitOfWork.FacultyRepository.GetByID(id);
                if(faculty != null)
                {
                    facultyDto = new FacultyDto
                    {
                        Id = faculty.Id,
                        Name = faculty.Name,
                        City = faculty.City,
                        Address = faculty.Address
                    };
                }
            }
            return facultyDto;
        }

        public bool Save(FacultyDto facultyDto)
        {
            Faculty faculty = new Faculty
            {
                Id = facultyDto.Id,
                Name = facultyDto.Name,
                City = facultyDto.City,
                Address = facultyDto.Address
            };

            try
            {
                using(UnitOfWork unitOfWork = new UnitOfWork())
                {
                    if (facultyDto.Id == 0)
                    {
                        unitOfWork.FacultyRepository.Insert(faculty);
                    }
                    else
                    {
                        unitOfWork.FacultyRepository.Update(faculty);
                    }
                    unitOfWork.Save();
                }
                return true;
            }
            catch
            {
                Console.WriteLine(faculty);
                return false;
            }
        }

        public bool Delete(int id)
        {
            // here DTOs are just an int
            try
            {
                using(UnitOfWork unitOfWork = new UnitOfWork())
                {
                    Faculty faculty = unitOfWork.FacultyRepository.GetByID(id);
                    unitOfWork.FacultyRepository.Delete(faculty);
                    unitOfWork.Save();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
