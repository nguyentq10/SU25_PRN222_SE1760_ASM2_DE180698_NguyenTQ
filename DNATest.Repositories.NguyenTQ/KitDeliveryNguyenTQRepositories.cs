using DNATest.Repositories.NguyenTQ.Basic;
using DNATest.Repositories.NguyenTQ.ModelExtentions;
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

        public async Task<List<KitDeliveryNguyenTq>> SearchAsync(string kitdeliveryId, string courierOut, decimal? fee)
        {
            var items = await _context.KitDeliveryNguyenTqs
                .Include(m => m.FeedbackNguyenTqs)
                .Where(m => 
                (m.KitCode.Contains(kitdeliveryId) || string.IsNullOrEmpty(kitdeliveryId))
                && (m.CourierOut.Contains(courierOut) || string.IsNullOrEmpty(courierOut))
                && (m.Fee == fee ||  fee == null)
                ).ToListAsync();
                return items ?? new List<KitDeliveryNguyenTq>();
        }
        public async Task<PaginationResult<List<KitDeliveryNguyenTq>>> SearchWithPagingAsync(KitDeliveryNguyenTQSearchRequest searchRequest)
        {
            var kitdeliverys = await this.SearchAsync(searchRequest.KitCode, searchRequest.CourierOut, searchRequest.Fee.Value);

            //// VuLNS | Paging
            var totalItems = kitdeliverys.Count();
            var totalPages = (int)Math.Ceiling((double)totalItems / searchRequest.PageSize.GetValueOrDefault());

            kitdeliverys = kitdeliverys.Skip((searchRequest.CurrentPage.GetValueOrDefault() - 1) * searchRequest.PageSize.GetValueOrDefault()).Take(searchRequest.PageSize.GetValueOrDefault()).ToList();

            var result = new PaginationResult<List<KitDeliveryNguyenTq>>
            {
                TotalItems = totalItems,
                TotalPages = totalPages,
                CurrentPage = searchRequest.CurrentPage.GetValueOrDefault(),
                PageSize = searchRequest.PageSize.GetValueOrDefault(),
                Items = kitdeliverys
            };

            return result;
        }
        public async Task<PaginationResult<List<KitDeliveryNguyenTq>>> SearchPagedAsync(string kitCode, string courierOut, decimal? fee, int page, int pageSize)
        {
            var query = _context.KitDeliveryNguyenTqs.AsQueryable();

            if (!string.IsNullOrEmpty(kitCode))
                query = query.Where(x => x.KitCode.Contains(kitCode));
            if (!string.IsNullOrEmpty(courierOut))
                query = query.Where(x => x.CourierOut.Contains(courierOut));
            if (fee.HasValue)
                query = query.Where(x => x.Fee == fee);

            var totalItems = await query.CountAsync();
            var pagedItems = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PaginationResult<List<KitDeliveryNguyenTq>>
            {
                Items = pagedItems,
                TotalItems = totalItems,
                PageSize = pageSize,
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize)
            };
        }

    }
}
