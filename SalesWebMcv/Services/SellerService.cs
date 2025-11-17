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

        public void Insert(Seller seller) 
        {
            _context.Add(seller);
            _context.SaveChanges();
        }

        public Seller FindById(int id) 
        {
            return _context.Seller.FirstOrDefault(obj => obj.Id == id);
        }

        public void Remove(int id) 
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }
    }
}
