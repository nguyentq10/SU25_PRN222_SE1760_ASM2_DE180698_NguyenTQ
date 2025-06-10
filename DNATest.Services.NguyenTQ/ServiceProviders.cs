using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNATest.Services.NguyenTQ
{   public interface IServiceProviders
    {
        UserAccountService UserAccountService { get; }
        KitDeliveryNguyenTQService KitDeliveryNguyenTQService { get; }

        FeedbackNguyenTQService FeedbackNguyenTQService { get; }
        IUserAccountService IUserAccountService { get; }
        IKitDeliveryNguyenTQService IKitDeliveryNguyenTQService { get; }
        IFeedbackNguyenTQService IFeedbackNguyenTQService { get; }
    }
    public class ServiceProviders : IServiceProvider
    {
        private KitDeliveryNguyenTQService _kitDeliveryNguyenTQService;
        private UserAccountService _userAccountService;
        private FeedbackNguyenTQService _feedbackNguyenTQService;
        IServiceProvider _IServiceProvider { get;}
        IKitDeliveryNguyenTQService _IKitDeliveryNguyenTQService { get;}

        IUserAccountService _IUserAccountService { get; }

        public ServiceProviders() { }

        public UserAccountService UserAccountService
        {
            get
            {
               return _userAccountService ??= new UserAccountService();
            }
        }

        public KitDeliveryNguyenTQService KitDeliveryNguyenTQService
        {
            get
            {
                return _kitDeliveryNguyenTQService ??= new KitDeliveryNguyenTQService();
            }
        }

        public FeedbackNguyenTQService FeedbackNguyenTQService
        {
            get
            {
                return _feedbackNguyenTQService ??= new FeedbackNguyenTQService();
            }
        }
        public IUserAccountService IUserAccountService
        {
            get
            {
                return _userAccountService ??= new UserAccountService();
            }
        }
        public IKitDeliveryNguyenTQService IKitDeliveryNguyenTQService
        {
            get
            {
                return _kitDeliveryNguyenTQService ??= new KitDeliveryNguyenTQService();
            }
        }
        public IFeedbackNguyenTQService IFeedbackNguyenTQService
        {
            get
            {
                return _feedbackNguyenTQService ??= new FeedbackNguyenTQService();
            }
        }
        public object? GetService(Type serviceType)
        {
            throw new NotImplementedException();
        }
    }
}
