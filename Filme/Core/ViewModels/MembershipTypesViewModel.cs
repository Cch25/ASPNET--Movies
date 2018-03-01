using System.Collections.Generic;
using Filme.Core.Models;

namespace Filme.Core.ViewModels
{
    public class MembershipTypesViewModel
    {
        
        public IEnumerable<MembershipType> MembershipType{ get; set; }
        public Customer Customers { get; set; }
    }
}