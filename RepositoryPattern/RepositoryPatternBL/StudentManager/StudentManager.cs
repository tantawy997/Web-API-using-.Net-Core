using AutoMapper;
using RepositoryPattern.DAL;
using RepositoryPatternBL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternBL;

public class StudentManager : IStudentManager
{
    private readonly IStudentRepo studentRepo;
    private readonly IMapper mapper;

    public StudentManager(IStudentRepo _StudentRepo, IMapper _Mapper)
    {
         studentRepo = _StudentRepo;
        mapper = _Mapper;
        
    }

    public StudentReadDTO Add(StudentAddDTO Student)
    {
        var dbModel = mapper.Map<Student>(Student);
        dbModel.Id = Guid.NewGuid();
        studentRepo.Add(dbModel);
        studentRepo.SaveChanges();

        return mapper.Map<StudentReadDTO>(dbModel);
    }

    public void Delete(Guid id)
    {
        //studentRepo.Delete(id);

        studentRepo.DeleteById(id);
        studentRepo.SaveChanges();
    }

    public List<StudentReadDTO> GetAll()
    {
        var student =  studentRepo.GetAll();

        return mapper.Map<List<StudentReadDTO>>(student);

    }

    public StudentReadDTO? GetById(Guid id)
    {
        var StudentDBO = studentRepo.GetById(id);

        if (StudentDBO == null)
        {
            return null;
        }
        return mapper.Map<StudentReadDTO>(StudentDBO);

    }

    public bool update(StudentUpdateDTO StudentDTO)
    {
        var StudentToBeEdit = studentRepo.GetById(StudentDTO.Id);
        if (StudentToBeEdit == null)
        {
            return false;
        }

        mapper.Map(StudentDTO, StudentToBeEdit);
        studentRepo.Update(StudentToBeEdit);
        studentRepo.SaveChanges();

        return true;

        
    }

    public List<StudentReadDTO> GetbyPhone(string Phone)
    {
        
        var studentPhone = studentRepo.GetByPhone(Phone);
        return mapper.Map<List<StudentReadDTO>>(studentPhone);
    }
}
