using Clean_Architecture_CQRS_Docker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Architecture_CQRS_Docker.Application.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {

    }
}
