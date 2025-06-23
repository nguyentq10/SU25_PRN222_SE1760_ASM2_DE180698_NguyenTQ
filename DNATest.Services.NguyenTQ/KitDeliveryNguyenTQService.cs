using Azure;
using DNATest.Repositories.NguyenTQ;
using DNATest.Repositories.NguyenTQ.ModelExtentions;
using DNATest.Repositories.NguyenTQ.Models;
using Microsoft.EntityFrameworkCore;
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

        public async Task<PaginationResult<List<KitDeliveryNguyenTq>>> GetPagedAsync(int page, int pageSize)
        {
            var allItems = await _unitOfWork.KitDeliveryNguyenTQRepositories.GetAllAsync(); // luôn dùng await
            var pageItems = allItems.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            return new PaginationResult<List<KitDeliveryNguyenTq>>
            {
                TotalItems = allItems.Count,
                TotalPages = (int)Math.Ceiling((double)allItems.Count / pageSize),
                CurrentPage = page,
                PageSize = pageSize,
                Items = pageItems
            };
        }

        public async Task<List<KitDeliveryNguyenTq>> SearchAsync(string kitcode, string courierOut, decimal? rating)
        {
           
            return await _unitOfWork.KitDeliveryNguyenTQRepositories.SearchAsync(kitcode, courierOut, rating);
        }


        public async Task<int> UpdateAsync(KitDeliveryNguyenTq kitdelivery)
        {
           return await _unitOfWork.KitDeliveryNguyenTQRepositories.UpdateAsync(kitdelivery);
        }

        public async Task<PaginationResult<List<KitDeliveryNguyenTq>>> SearchPagedAsync(string kitCode, string courierOut, decimal? fee, int page, int pageSize)
        {
           return await _unitOfWork.KitDeliveryNguyenTQRepositories.SearchPagedAsync(kitCode, courierOut, fee, page, pageSize);
        }


    }
}
