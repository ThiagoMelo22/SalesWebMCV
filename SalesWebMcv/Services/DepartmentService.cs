using SalesWebMcv.Models;

namespace SalesWebMcv.Services
{
    public class DepartmentService
    {
        private readonly SalesWebMcvContext _context;

        public DepartmentService(SalesWebMcvContext context) 
        {
            _context = context;
        }

        public List<Department> FindAll()
        {
            return _context.Department.ToList();
        }
    }
}
