using AutoMapper;
using RepositoryPattern.DAL;
using RepositoryPatternBL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternBL;

public class AutoMapperProfile :Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Student, StudentReadDTO>();
        CreateMap<StudentAddDTO, Student>();
        CreateMap<StudentUpdateDTO, Student>();

        CreateMap<Course, CourseReadDTO>();

    }
}
