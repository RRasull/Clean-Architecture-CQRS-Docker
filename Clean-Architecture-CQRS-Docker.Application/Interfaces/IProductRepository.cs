using Clean_Architecture_CQRS_Docker.Domain.Entities;
using Clean_Architecture_CQRS_Docker.Infrastructure.CQRS.Commands.Request;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Architecture_CQRS_Docker.Application.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<EntityEntry<Product>> CreateProductAsync(CreateProductCommandRequest request);

        Task DeleteProductAsync(DeleteProductCommandRequest request);


    }
}
