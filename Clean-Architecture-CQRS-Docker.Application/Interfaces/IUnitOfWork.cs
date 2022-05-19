using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Architecture_CQRS_Docker.Application.Interfaces
{
    public interface IUnitOfWork
    {
        public IProductRepository productRepository { get; }
        
        Task SaveAsync();
    }
}
