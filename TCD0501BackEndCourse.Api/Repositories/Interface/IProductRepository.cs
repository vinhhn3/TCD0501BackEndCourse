using System.Collections.Generic;

using TCD0501BackEndCourse.Api.Models;

namespace TCD0501BackEndCourse.Api.Repositories.Interface
{
    public interface IProductRepository
    {
        List<Product> GetProducts();
    }
}
