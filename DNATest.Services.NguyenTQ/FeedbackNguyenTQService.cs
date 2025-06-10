using DNATest.Repositories.NguyenTQ;
using DNATest.Repositories.NguyenTQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNATest.Services.NguyenTQ
{
    public class FeedbackNguyenTQService : IFeedbackNguyenTQService
    {
        private FeedbackNguyenTQRepository _repository;

        public FeedbackNguyenTQService() => _repository ??= new FeedbackNguyenTQRepository();
        public async Task<List<FeedbackNguyenTq>> GetAllAsync()
        {
           return await _repository.GetAllAsync();
        }

        public async Task<FeedbackNguyenTq> GetAsync(int id)
        {
            return await _repository.GetByIdAsync(id) ?? new FeedbackNguyenTq();
        }
    }
}
