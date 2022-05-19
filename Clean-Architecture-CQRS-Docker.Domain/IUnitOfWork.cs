using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clean_Architecture_CQRS_Docker.Domain.Interfaces;

namespace Clean_Architecture_CQRS_Docker.Domain
{
    public interface IUnitOfWork
    {
        public IProductRepository ProductRepository { get; }
        
        Task SaveAsync();
    }
}
