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
        private readonly KitDeliveryNguyenTQRepositories _repository;

        public KitDeliveryNguyenTQService() => _repository ??= new KitDeliveryNguyenTQRepositories();

        public async Task<int> CreateAsync(KitDeliveryNguyenTq kitdelivery)
        {
            return await _repository.CreateAsync(kitdelivery);
        }

     

        public async Task<bool> DeleteAsync(int id)
        {
            var items = await _repository.GetByIdAsync(id);
            return await _repository.RemoveAsync(items);
        }

        public async Task<List<KitDeliveryNguyenTq>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<KitDeliveryNguyenTq> GetIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<List<KitDeliveryNguyenTq>> SearchAsync(int kitdeliveryId, string courierOut, int rating)
        {
           
            return await _repository.SearchAsync(kitdeliveryId, courierOut, rating);
        }

        public async Task<int> UpdateAsync(KitDeliveryNguyenTq kitdelivery)
        {
           return await _repository.UpdateAsync(kitdelivery);
        }

    
    }
}
