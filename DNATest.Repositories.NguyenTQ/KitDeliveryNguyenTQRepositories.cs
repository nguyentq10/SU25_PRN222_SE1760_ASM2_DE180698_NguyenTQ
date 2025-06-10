using DNATest.Repositories.NguyenTQ.Basic;
using DNATest.Repositories.NguyenTQ.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNATest.Repositories.NguyenTQ
{
    public class KitDeliveryNguyenTQRepositories : GenericRepository<KitDeliveryNguyenTq>
    {
        public KitDeliveryNguyenTQRepositories() { }
        
        public KitDeliveryNguyenTQRepositories(SU25_PRN222_SE1706_G6_ADNTestServiceContext context) => _context = context;

        public async Task<List<KitDeliveryNguyenTq>> GetAllAsync()
        {
            var items = await _context.KitDeliveryNguyenTqs
                .Include(m => m.FeedbackNguyenTqs)
                .ToListAsync();
                return items ?? new List<KitDeliveryNguyenTq> ();
        }

        public async Task<KitDeliveryNguyenTq> GetByIdAsync(int id)
        {
            var items = await _context.KitDeliveryNguyenTqs
                .Include(m => m.FeedbackNguyenTqs)
                .FirstOrDefaultAsync(m => m.KitDeliveryNguyenTqid == id);
            return items ?? new KitDeliveryNguyenTq();
        }

        public async Task<List<KitDeliveryNguyenTq>> SearchAsync(int kitdeliveryId, string courierOut, int rating)
        {
            var items = await _context.KitDeliveryNguyenTqs
                .Include(m => m.FeedbackNguyenTqs)
                .Where(m => 
                (m.KitDeliveryNguyenTqid == kitdeliveryId || kitdeliveryId==null)
                && (m.CourierOut.Contains(courierOut) || string.IsNullOrEmpty(courierOut))
                && (m.FeedbackNguyenTqs.Any(f => f.Rating == rating))
                ).ToListAsync();
                return items ?? new List<KitDeliveryNguyenTq>();
        }
        
    }
}
