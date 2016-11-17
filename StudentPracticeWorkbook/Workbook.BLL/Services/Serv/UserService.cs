using System.Security.Cryptography;
using Workbook.BLL.Services.Base;
using Workbook.BLL.Services.Interfaces;
using Workbook.DAL.EntityFramework;

namespace User.BLL.Services.Serv
{
    public sealed class UserService : BaseService<Workbook.DAL.Entities.User>, IUserService
    {
        private readonly IUserRepository _baseRepository;
        private readonly MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

        public UserService(IUserRepository baseRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public override void Add(Workbook.DAL.Entities.User item)
        {
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream(
            System.Text.Encoding.UTF32.GetBytes(item.HashPassword)))
            {
                item.HashPassword = md5.ComputeHash(ms).ToString();
            }
            _baseRepository.Add(item);
        }


    }
}
