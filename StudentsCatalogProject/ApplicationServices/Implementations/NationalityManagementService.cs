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
    public class NationalityManagementService
    {
        private StudentSystemDbContext ctx = new StudentSystemDbContext();

        public List<NationalityDto> Get()
        {
            List<NationalityDto> nationalitiesDto = new List<NationalityDto>();

            // use UnitOfWork
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                // foreach in the NationalityRepository instead of ctx
                foreach (var item in unitOfWork.NationalityRepository.Get())
                {

                    nationalitiesDto.Add(new NationalityDto
                    {
                        Id = item.Id,
                        Title = item.Title
                    });

                }
            }

            return nationalitiesDto;
        }

        public NationalityDto GetById(int id)
        {
            NationalityDto nationalityDto = new NationalityDto();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Nationality nationality = unitOfWork.NationalityRepository.GetByID(id);
                if (nationality != null)
                {
                    nationalityDto = new NationalityDto
                    {
                        Id = nationality.Id,
                        Title = nationality.Title,
                    };
                }
            }

            return nationalityDto;
        }

        public bool Save(NationalityDto nationalityDto)
        {
            Nationality nationality = new Nationality
            {
                Id = nationalityDto.Id,
                Title = nationalityDto.Title
            };

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    if (nationalityDto.Id == 0)
                    {
                        unitOfWork.NationalityRepository.Insert(nationality);
                    }
                    else
                    {
                        unitOfWork.NationalityRepository.Update(nationality);
                    }
                    unitOfWork.Save();
                }
             

                return true;
            }
            catch
            {
                Console.WriteLine(nationality);
                return false;
            }
        }

        public bool Delete(int id)
        {
            // here the DTO is just an int
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    Nationality nationality = unitOfWork.NationalityRepository.GetByID(id);
                    unitOfWork.NationalityRepository.Delete(nationality);
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
