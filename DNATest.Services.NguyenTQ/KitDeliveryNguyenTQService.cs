using DNATest.Repositories.NguyenTQ;
using DNATest.Repositories.NguyenTQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNATest.Services.NguyenTQ
{
    public class KitDeliveryNguyenTQService : IKitDeliveryNguyenTQService
    {
        
        private readonly IUnitOfWork _unitOfWork;
       public KitDeliveryNguyenTQService() => _unitOfWork = new UnitOfWork();
        public async Task<int> CreateAsync(KitDeliveryNguyenTq kitdelivery)
        {
            return await _unitOfWork.KitDeliveryNguyenTQRepositories.CreateAsync(kitdelivery);
        }

     

        public async Task<bool> DeleteAsync(int id)
        {
            var items = await _unitOfWork.KitDeliveryNguyenTQRepositories.GetByIdAsync(id);
            return await _unitOfWork.KitDeliveryNguyenTQRepositories.RemoveAsync(items);
        }

        public async Task<List<KitDeliveryNguyenTq>> GetAllAsync()
        {
            return await _unitOfWork.KitDeliveryNguyenTQRepositories.GetAllAsync();
        }

        public async Task<KitDeliveryNguyenTq> GetIdAsync(int id)
        {
            return await _unitOfWork.KitDeliveryNguyenTQRepositories.GetByIdAsync(id);
        }

        public async Task<List<KitDeliveryNguyenTq>> SearchAsync(int kitdeliveryId, string courierOut, int rating)
        {
           
            return await _unitOfWork.KitDeliveryNguyenTQRepositories.SearchAsync(kitdeliveryId, courierOut, rating);
        }

        public async Task<int> UpdateAsync(KitDeliveryNguyenTq kitdelivery)
        {
           return await _unitOfWork.KitDeliveryNguyenTQRepositories.UpdateAsync(kitdelivery);
        }

    
    }
}
