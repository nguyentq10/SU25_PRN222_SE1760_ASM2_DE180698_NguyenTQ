using DNATest.Repositories.NguyenTQ;
using DNATest.Repositories.NguyenTQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNATest.Services.NguyenTQ
{
    public class UserAccountService : IUserAccountService
    {   
        private readonly UserAccountRepository _repository;

        public UserAccountService() => _repository ??= new UserAccountRepository(); 

        public async Task<UserAccount> GetSystemUserAccountAsync(string username, string password)
        {
           return await _repository.GetUserAccountAsync(username, password);
        }
    }
}
