using System;
using System.Linq;
using Workbook.BLL.DTOs;
using Workbook.BLL.Services.Base;
using Workbook.BLL.Services.Interfaces;
using Workbook.DAL.Entities;
using Workbook.DAL.EntityFramework;
using Workbook.DAL.EntityFramework.baseRepository;

namespace Workbook.BLL.Services.Serv
{
    public sealed class WorkBookService : BaseService<DAL.Entities.Workbook, WorkbookDTO>,IWorkBookService
    {
        private readonly IWorkBookRepository _baseRepository;
        private readonly IUserRepository _userRepository;
        private readonly IBookNoteRepository _iBookNoteRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public WorkBookService(IWorkBookRepository baseRepository, IUserRepository userRepository, IBookNoteRepository bookNoteRepository, IDepartmentRepository departmentRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;
            _userRepository = userRepository;
            _iBookNoteRepository = bookNoteRepository;
            _departmentRepository = departmentRepository;
        }

        public override void Add(WorkbookDTO item)
        {
            var workbook =new DAL.Entities.Workbook();
            var employee= (Employee)_userRepository.FindById(item.Employee.Id);
            //workbook.Employee = employee;
            workbook.EmployeeId = employee.Id;
            var company = _userRepository.FindById(item.Company.Id);
            //workbook.Company = (Company) company;
            workbook.CompanyId = company.Id;

            var student = _userRepository.FindById(item.Student.Id);
            //workbook.Student = (Student) student;
            workbook.StudentId = student.Id;
            workbook.GradeCompany = item.GradeCompany;
            workbook.GradeDepartment = item.GradeCompany;
            _baseRepository.Add(workbook);
            _baseRepository.Save();

        }

        public override void Update(WorkbookDTO item)
        {

            var workbook = new DAL.Entities.Workbook();
            var employee = (Employee)_userRepository.FindById(item.Employee.Id);
            workbook.Employee = null;
            workbook.EmployeeId = employee.Id;
            var company = _userRepository.FindById(item.Company.Id);
            workbook.Company = null;
            workbook.CompanyId = company.Id;
            //var noteDTO= item.Noteses.FirstOrDefault(x => x.Id == new Guid());
            //var note = new BookNote();
            //if (noteDTO!=null)
            //{
            //    note.FinishDate = noteDTO.FinishDate;
            //    note.StartDate = noteDTO.StartDate;
            //    note.Note = noteDTO.Note;
            //    note.WorkBookId = item.Id;
            //}

            var student = _userRepository.FindById(item.Student.Id);
            workbook.Student = null;
            workbook.StudentId = student.Id;
            workbook.GradeCompany = item.GradeCompany;
            workbook.GradeDepartment = item.GradeCompany;
            //if (note.WorkBookId!= new Guid())
            //{
            //    workbook.Noteses.Add(note);
            //}
            _baseRepository.Edit(workbook);
            _baseRepository.Save();
        }

        public override void Remove(WorkbookDTO item)
        {
            if (item == null)
            {
                return;
            }
            var workbook = _baseRepository.FindById(item.Id);
            if (workbook.Noteses != null)
            {
                foreach (var note in workbook.Noteses)
                {
                    _iBookNoteRepository.Delete(note);
                }
            }
            
            workbook.Noteses = null;

            workbook.Employee = null;
            workbook.EmployeeId = null;
            
            workbook.Company = null;
            workbook.CompanyId = null;

            
            workbook.Student = null;
            workbook.StudentId = null;
            base.Remove(item);
        }
    }
}
