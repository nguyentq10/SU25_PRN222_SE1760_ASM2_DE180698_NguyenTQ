using DNATest.Repositories.NguyenTQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNATest.Repositories.NguyenTQ
{   public interface IUnitOfWork : IDisposable
    {
       UserAccountRepository UserAccountRepository { get; }
       KitDeliveryNguyenTQRepositories KitDeliveryNguyenTQRepositories { get; }

       FeedbackNguyenTQRepository FeedbackNguyenTQRepository { get; }

        int SaveChangesWithTransaction();
        Task<int> SaveChangesWithTransactionAsync();

    }
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SU25_PRN222_SE1706_G6_ADNTestServiceContext _context;
        private UserAccountRepository _userAccountRepository;
        private KitDeliveryNguyenTQRepositories _kitDeliveryNguyenTQRepositories;
        private FeedbackNguyenTQRepository _feedbackNguyenTQRepository;

        public UnitOfWork() => _context = new SU25_PRN222_SE1706_G6_ADNTestServiceContext();

        public UserAccountRepository UserAccountRepository
        {
            get {return _userAccountRepository ??= new UserAccountRepository(_context);
            }
        }

        public KitDeliveryNguyenTQRepositories KitDeliveryNguyenTQRepositories
        {
            get { return _kitDeliveryNguyenTQRepositories ??= new KitDeliveryNguyenTQRepositories(_context); }
        }

        public FeedbackNguyenTQRepository FeedbackNguyenTQRepository
        {
            get { return _feedbackNguyenTQRepository ??= new FeedbackNguyenTQRepository(_context); }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public int SaveChangesWithTransaction()
        {
            int result = -1;

            //System.Data.IsolationLevel.Snapshot
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    result = _context.SaveChanges();
                    dbContextTransaction.Commit();
                }
                catch (Exception)
                {
                    //Log Exception Handling message                      
                    result = -1;
                    dbContextTransaction.Rollback();
                }
            }

            return result;
        }

        public async Task<int> SaveChangesWithTransactionAsync()
        {
            int result = -1;

            //System.Data.IsolationLevel.Snapshot
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                try
                {
                    result = await _context.SaveChangesAsync();
                    dbContextTransaction.Commit();
                }
                catch (Exception)
                {
                    //Log Exception Handling message                      
                    result = -1;
                    dbContextTransaction.Rollback();
                }
            }

            return result;
        }
    }
}
