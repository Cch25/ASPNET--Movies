using System.Collections.Generic;
using System.Threading.Tasks;
using Filme.Core.Models;

namespace Filme.Core.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<IEnumerable<Customer>> CustomersMemberships();
        Customer GetCustomerDetails(int id);
        Task<IEnumerable<MembershipType>> GetMembershipTypeList();
    }
}
