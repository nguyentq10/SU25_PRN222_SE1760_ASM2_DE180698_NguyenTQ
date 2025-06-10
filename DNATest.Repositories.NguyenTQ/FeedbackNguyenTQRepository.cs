using DNATest.Repositories.NguyenTQ.Basic;
using DNATest.Repositories.NguyenTQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNATest.Repositories.NguyenTQ
{
    public class FeedbackNguyenTQRepository : GenericRepository<FeedbackNguyenTq>
    {
        public FeedbackNguyenTQRepository() { } 
            
        public FeedbackNguyenTQRepository(SU25_PRN222_SE1706_G6_ADNTestServiceContext context) => _context = context;
    }
}
