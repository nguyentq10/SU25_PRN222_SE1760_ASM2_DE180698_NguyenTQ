using DNATest.Repositories.NguyenTQ.ModelExtentions;
using DNATest.Repositories.NguyenTQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DNATest.Services.NguyenTQ
{
    public interface IKitDeliveryNguyenTQService
    {
        Task<List<KitDeliveryNguyenTq>> GetAllAsync();
        
        Task<KitDeliveryNguyenTq> GetIdAsync(int id);

        Task<List<KitDeliveryNguyenTq>> SearchAsync(string kitdeliveryId, string courierOut, decimal? rating);
        Task<int> CreateAsync(KitDeliveryNguyenTq kitdelivery);
        Task<int> UpdateAsync(KitDeliveryNguyenTq kitdelivery);
        Task<bool> DeleteAsync(int id);

        Task<PaginationResult<List<KitDeliveryNguyenTq>>> GetPagedAsync(int page, int pageSize);

        Task<PaginationResult<List<KitDeliveryNguyenTq>>> SearchPagedAsync(string kitCode, string courierOut, decimal? fee, int page, int pageSize);

    }
}
