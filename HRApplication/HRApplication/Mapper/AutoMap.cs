using AutoMapper;
using HRApplication.Models;
using HRApplication.ViewModels.EmployeeQualifications;
using HRApplication.ViewModels.Governorate;
using HRApplication.ViewModels.Neighborhood;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRApplication.Mapper
{
    public class AutoMap : Profile
    {
        public IMapper Mapper()
        {
            MapperConfiguration configuration = new MapperConfiguration(config => 
            {
                config.CreateMap<Governorate, GetGovernorate>();
                config.CreateMap<CreateGovernorate,Governorate>();
                config.CreateMap<Governorate, EditGovernorate>().ReverseMap();
                config.CreateMap<Governorate, DeleteGovernorate>();

                config.CreateMap<Neighborhood, GetNeighborhood>().ForMember(d => d.Governorate,
                    o => o.MapFrom(s => s.Governorate.Name));
                config.CreateMap<CreateNeighborhood, Neighborhood>();                    
                config.CreateMap<Neighborhood, EditNeighborhood>().ReverseMap();
                config.CreateMap<Neighborhood, DeleteNeighborhood>().ForMember(d => d.Governorate,
                    o => o.MapFrom(s => s.Governorate.Name));

                config.CreateMap<EmployeeQualification, GetEmployeeQualification>().ForMember(d => d.EmployeeName,
                    o => o.MapFrom(s => s.Employee.Name)).ForMember(d => d.Governorate, o => o.MapFrom(s => s.Employee.Governorate.Name))
                    .ForMember(d => d.Neighborhood, o => o.MapFrom(s => s.Employee.Neighborhood.Name))
                    .ForMember(d => d.CareerField, o => o.MapFrom(s => s.Employee.CareerField.Name))
                    .ForMember(d => d.Address, o => o.MapFrom(s => s.Employee.Address))
                    .ForMember(d => d.CompanyJob, o => o.MapFrom(s => s.Employee.CompanyJob.Name))
                    .ForMember(d => d.JobArrangement, o => o.MapFrom(s => s.Employee.CompanyJob.JobArrangement))
                    .ForMember(d => d.Qualification, o => o.MapFrom(s => s.Qualification.Name));

                config.CreateMap<CreateEmployeeQualification, EmployeeQualification>();
                config.CreateMap<EditEmployeeQualification, EmployeeQualification>().ReverseMap();

                config.CreateMap<EmployeeQualification, DeleteEmployeeQualification>().ForMember(d => d.EmployeeName,
                    o => o.MapFrom(s => s.Employee.Name)).ForMember(d => d.Governorate, o => o.MapFrom(s => s.Employee.Governorate.Name))
                    .ForMember(d => d.Neighborhood, o => o.MapFrom(s => s.Employee.Neighborhood.Name))
                    .ForMember(d => d.CareerField, o => o.MapFrom(s => s.Employee.CareerField.Name))
                    .ForMember(d => d.Address, o => o.MapFrom(s => s.Employee.Address))
                    .ForMember(d => d.CompanyJob, o => o.MapFrom(s => s.Employee.CompanyJob.Name))
                    .ForMember(d => d.JobArrangement, o => o.MapFrom(s => s.Employee.CompanyJob.JobArrangement))
                    .ForMember(d => d.Qualification, o => o.MapFrom(s => s.Qualification.Name)); 



            });

            IMapper mapper = configuration.CreateMapper();
            return mapper;
        }
    }
}