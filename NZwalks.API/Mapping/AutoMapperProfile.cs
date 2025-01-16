using AutoMapper;
using NZwalks.API.Models.Domain;
using NZwalks.API.Models.DTO;

namespace NZwalks.API.Mapping
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
    






            CreateMap<Client, AddClientDto>().ReverseMap();
            CreateMap<AddClientDto, Client>().ReverseMap();

            CreateMap<AddProjectDto, Project>().ReverseMap();
            CreateMap<Project, AddProjectDto>().ReverseMap();



            CreateMap<AddEmployeeDto, Employee>().ReverseMap();
            CreateMap<Employee, AddEmployeeDto>().ReverseMap();

            CreateMap<LogTime, AddLogtimeDTO>().ReverseMap();
            CreateMap<AddLogtimeDTO,LogTime>().ReverseMap();

        }
    }
}
