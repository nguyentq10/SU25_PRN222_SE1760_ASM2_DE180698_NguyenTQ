using DNATest.Repositories.NguyenTQ.Basic;
using DNATest.Repositories.NguyenTQ.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNATest.Repositories.NguyenTQ
{
    public class UserAccountRepository : GenericRepository<UserAccount>
    {
        public UserAccountRepository() { }

        public UserAccountRepository(SU25_PRN222_SE1706_G6_ADNTestServiceContext context) => _context = context;

        public async Task<UserAccount> GetUserAccountAsync(String username,String password)
        {
            return await _context.UserAccounts.FirstOrDefaultAsync(m => m.UserName == username && m.Password == password && m.IsActive == true);
        }
    }
}
