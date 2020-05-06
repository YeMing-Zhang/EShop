﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Domain.Services;

namespace EasyAbp.EShop.Products.Products
{
    public class ProductManager : DomainService, IProductManager
    {
        private readonly IProductInventoryProvider _productInventoryProvider;

        public ProductManager(
            IProductInventoryProvider productInventoryProvider)
        {
            _productInventoryProvider = productInventoryProvider;
        }
        
        public async Task<bool> IsInventorySufficientAsync(Product product, ProductSku productSku, Guid storeId, int quantity)
        {
            return await _productInventoryProvider.IsInventorySufficientAsync(product, productSku, storeId, quantity);
        }

        public async Task<int> GetInventoryAsync(Product product, ProductSku productSku, Guid storeId)
        {
            return await _productInventoryProvider.GetInventoryAsync(product, productSku, storeId);
        }

        public async Task<bool> TryIncreaseInventoryAsync(Product product, ProductSku productSku, Guid storeId, int quantity)
        {
            return await _productInventoryProvider.TryIncreaseInventoryAsync(product, productSku, storeId, quantity);
        }

        public async Task<bool> TryReduceInventoryAsync(Product product, ProductSku productSku, Guid storeId, int quantity)
        {
            return await _productInventoryProvider.TryReduceInventoryAsync(product, productSku, storeId, quantity);
        }
    }
}