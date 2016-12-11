using Workbook.BLL.DTOs;
using Workbook.BLL.Services.Base;
using Workbook.DAL.Entities;
using Workbook.DAL.EntityFramework;
using Workbook.DAL.EntityFramework.baseRepository;
using Workbook.DAL.EntityFramework.Repositories;

namespace Workbook.BLL.Services.Serv
{
    public sealed class DepartmentService : BaseService<Department, DepartmentDTO>, IDepartmentService
    {
        private readonly IDepartmentRepository _baseRepository;
        private readonly IUserRepository _userRepository;
        private readonly IWorkBookRepository _workBookRepository;

        public DepartmentService(IDepartmentRepository baseRepository, IUserRepository userRepository, IWorkBookRepository workBookRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;
            _userRepository = userRepository;
            _workBookRepository = workBookRepository;
        }


        public override void Add(DepartmentDTO item)
        {
            var department= new Department();
            department.Name = item.Name;
            _baseRepository.Add(department);
        }

        public override void Update(DepartmentDTO item)
        {
            var department = _baseRepository.FindById(item.Id);
            department.Name = item.Name;
           
            _baseRepository.Edit(department);
            _baseRepository.Save();
        }

        public override void Remove(DepartmentDTO item)
        {
            var users = _userRepository.GetBy(x => x.Department.Id == item.Id);
            var workbooks= _workBookRepository.GetBy(x => x.Department.Id == item.Id);
            foreach (var user in users)
            {
                user.Department = null;
                user.DepartmentId = null;
                _userRepository.Edit(user);
              
            }
            _userRepository.Save();
            foreach (var workbook in workbooks)
            {
                workbook.Department = null;
                workbook.DepartmentId = null;
                _workBookRepository.Edit(workbook);
               
            }

            _workBookRepository.Save();
            var department = _baseRepository.FindById(item.Id);
            department.Users = null;
            _baseRepository.Delete(department);
            _baseRepository.Save();
        }
    }
}
