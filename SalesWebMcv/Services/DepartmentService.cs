using SalesWebMcv.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SalesWebMcv.Services
{
    public class DepartmentService
    {
        private readonly SalesWebMcvContext _context;

        public DepartmentService(SalesWebMcvContext context) 
        {
            _context = context;
        }

        public async Task<List<Department>> FindAllAsync()
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
