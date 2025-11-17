using SalesWebMcv.Models;
using Microsoft.EntityFrameworkCore;
using SalesWebMcv.Services.Exceptions;

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

        public Seller FindById(int id)
        {
            return _context.Seller.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id);
        }

        public void Insert(Seller seller) 
        {
            _context.Add(seller);
            _context.SaveChanges();
        }

        public void Update(Seller seller) 
        {
            if (!_context.Seller.Any(x => x.Id == seller.Id)) 
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(seller);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex) 
            {
                throw new DbConcurrencyException(ex.Message);
            }
        }

        public void Remove(int id) 
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }
    }
}
