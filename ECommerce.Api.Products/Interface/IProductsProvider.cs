﻿using ECommerce.Api.Products.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Api.Products.Interface
{
    public interface IProductsProvider
    {
        Task<(bool IsSuccess, IEnumerable<Product> Products, string ErrorMessage)> GetProductsAsync();

        Task<(bool IsSuccess, Product Product, string ErrorMessage)> GetProductAsync(int id);

    }
}
