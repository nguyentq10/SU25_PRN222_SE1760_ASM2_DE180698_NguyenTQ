using DNATest.Repositories.NguyenTQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNATest.Services.NguyenTQ
{
    public interface IFeedbackNguyenTQService
    {
        Task<List<FeedbackNguyenTq>> GetAllAsync();

        Task<FeedbackNguyenTq> GetAsync(int id);
    }
}
