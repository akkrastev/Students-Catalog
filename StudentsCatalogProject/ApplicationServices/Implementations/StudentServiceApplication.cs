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
    public class StudentServiceApplication
    {
        private StudentSystemDbContext ctx = new StudentSystemDbContext();

        public List<StudentDto> Get()
        {
            List<StudentDto> studentDto = new List<StudentDto>();

            using(UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach(var item in unitOfWork.StudentRepository.Get())
                {
                    studentDto.Add(new StudentDto
                    {
                        Id = item.Id,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        DateOfBirth = item.DateOfBirth,
                        City = item.City,
                        Nationality = new NationalityDto
                        {
                            Id = item.Nationality.Id,
                            Title = item.Nationality.Title

                        },
                        Faculty = new FacultyDto
                        {
                            Id = item.Faculty.Id,
                            Name = item.Faculty.Name,
                            City = item.Faculty.City,
                            Address = item.Faculty.Address
                        }

                    });
                }
            }
            return studentDto;
        }

        public StudentDto GetById(int id)
        {
            StudentDto studentDto = new StudentDto();
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Student student = unitOfWork.StudentRepository.GetByID(id);
                if(student != null)
                {
                    studentDto = new StudentDto
                    {
                        Id = student.Id,
                        FirstName = student.FirstName,
                        LastName = student.LastName,
                        City = student.City,
                        DateOfBirth = student.DateOfBirth,
                        // you can create a search for this object based on NationalityId and load it here
                        Nationality = new NationalityDto
                        {
                            Id = student.NationalityId,
                            Title = student.Nationality.Title
                        },
                        Faculty = new FacultyDto
                        {
                            Id = student.FacultyId,
                            Name = student.Faculty.Name,
                            City = student.Faculty.City,
                            Address = student.Faculty.Address
                        }
                    };
                }
            }

            return studentDto;
        }

        public bool Save(StudentDto studentDto)
        {
            // either init nationality and faculty beforehand or create a check

           if(studentDto.Faculty == null || studentDto.Nationality == null)
            {
                return false;
            }

            // add additional functionality - if there are no such nationality and faculty -> create it
            Nationality nationality = new Nationality
            {
                Id = studentDto.Nationality.Id,
                Title = studentDto.Nationality.Title
            };

            Faculty faculty = new Faculty
            {
                Id = studentDto.Faculty.Id,
                Name = studentDto.Faculty.Name,
                City = studentDto.Faculty.City,
                Address = studentDto.Faculty.Address
            };

            Student student = new Student
            {
                Id = studentDto.Id,
                FirstName = studentDto.FirstName,
                LastName = studentDto.LastName,
                DateOfBirth = studentDto.DateOfBirth,
                City = studentDto.City,
                NationalityId = studentDto.Nationality.Id,
                FacultyId = studentDto.Faculty.Id
            };

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    if(studentDto.Id == 0)
                    {
                        unitOfWork.StudentRepository.Insert(student);
                    }
                    else
                    {
                        unitOfWork.StudentRepository.Update(student);
                    }
                    unitOfWork.Save();
                }
                return true;
            }
            catch
            {
                Console.WriteLine(student);
                return false;
            }
        }

        public bool Delete(int id)
        {
            // here DTOs are just an int 
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    Student student = unitOfWork.StudentRepository.GetByID(id);
                    unitOfWork.StudentRepository.Delete(student);
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
