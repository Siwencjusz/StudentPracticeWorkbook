using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Workbook.BLL.DTOs;
using Workbook.DAL.Entities;
using Workbook = Workbook.DAL.Entities.Workbook;

namespace Workbook.BLL.init
{
    public static class InitBLL
    {
        public static void InitMapper()
        {
            Mapper.Initialize(cfg =>
                {
                    //    cfg.CreateMap<DAL.Entities.Workbook, WorkbookDTO>()
                    //        .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Department))
                    //        .ForMember(dest => dest.Company, opt => opt.MapFrom(src => src.Company))
                    //        .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.DepartmentId))
                    //        .ForMember(dest => dest.GradeCompany, opt => opt.MapFrom(src => src.GradeCompany))
                    //        .ForMember(dest => dest.GradeDepartment, opt => opt.MapFrom(src => src.GradeDepartment))
                    //        .ForMember(dest => dest.Company, opt => opt.MapFrom(src => src.Company))
                    //        .ForMember(dest => dest.Employee, opt => opt.MapFrom(src => src.Employee))
                    //        .ForMember(dest => dest.Employee, opt => opt.MapFrom(src => src.Employee))
                    //        .ForMember(dest => dest.Noteses, opt => opt.AllowNull())
                    //        .ForMember(dest => dest.DocumentUrl, opt => opt.MapFrom(src => src.DocumentUrl))
                    //        .ForMember(dest => dest.Student, opt => opt.MapFrom(src => src.Student));
                    cfg.CreateMap<DAL.Entities.BookNote, BookNoteDTO>()
                        .ForMember(dest => dest.FinishDate, opt => opt.MapFrom(src => src.FinishDate))
                        .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
                        .ForMember(dest => dest.FinishDate, opt => opt.MapFrom(src => src.FinishDate))
                        .ForMember(dest => dest.Note, opt => opt.MapFrom(src => src.Note))
                        .ForMember(dest => dest.Workbook, opt => opt.AllowNull());
                cfg.CreateMissingTypeMaps = true;
            });
        }
    }
}
