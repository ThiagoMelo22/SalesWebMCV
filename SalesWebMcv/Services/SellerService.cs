using SalesWebMcv.Models;

namespace SalesWebMcv.Services
{
    public class SellerService
    {
        private readonly SalesWebMcvContext _context;

        public SellerService(SalesWebMcvContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }
    }
}
