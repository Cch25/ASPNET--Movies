using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Filme.Core.Models;
using Filme.Core.Repositories;

namespace Filme.Persistence.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Customer>> CustomersMemberships()
        {
            return await _context.Customers.Include(m => m.MembershipType).ToListAsync();
        }

        public Customer GetCustomerDetails(int id)
        {
            return _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
        }

        public async Task<IEnumerable<MembershipType>> GetMembershipTypeList()
        {
            return await _context.MembershipTypes.ToListAsync();
        }
    }
}