using DNATest.Repositories.NguyenTQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNATest.Services.NguyenTQ
{
    public interface IUserAccountService
    {
        Task<UserAccount> GetSystemUserAccountAsync(string username, string password);
    }
}
