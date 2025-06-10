using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DNATest.Repositories.NguyenTQ.Models;
namespace DNATest.Services.NguyenTQ
{
    public interface IKitDeliveryNguyenTQService
    {
        Task<List<KitDeliveryNguyenTq>> GetAllAsync();
        
        Task<KitDeliveryNguyenTq> GetIdAsync(int id);

        Task<List<KitDeliveryNguyenTq>> SearchAsync(int kitdeliveryId, string courierOut, int rating);
        Task<int> CreateAsync(KitDeliveryNguyenTq kitdelivery);
        Task<int> UpdateAsync(KitDeliveryNguyenTq kitdelivery);
        Task<bool> DeleteAsync(int id);
    }
}
