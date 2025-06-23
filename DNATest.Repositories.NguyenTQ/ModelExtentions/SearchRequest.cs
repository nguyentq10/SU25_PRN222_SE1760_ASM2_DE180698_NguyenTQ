using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNATest.Repositories.NguyenTQ.ModelExtentions
{
    public class SearchRequest
    {
        public int? CurrentPage { get; set; } = 1;
        public int? PageSize { get; set; } = 10;
    }

    public class  KitDeliveryNguyenTQSearchRequest:SearchRequest
    {
        public string? KitCode { get; set; }
        public string? CourierOut { get; set; }
        public decimal? Fee { get; set; }

    }
}
