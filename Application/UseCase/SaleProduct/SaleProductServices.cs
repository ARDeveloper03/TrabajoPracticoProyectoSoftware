﻿using Application.Interfaces;
using Domain.Entities;

namespace Application.UseCase;

public class SaleProductServices : ISaleProductServices
{
    private readonly ISaleProductCommands __command;
    private readonly ISaleProductQuery __query;

    public SaleProductServices(ISaleProductCommands command, ISaleProductQuery query)
    {
        __command = command;
        __query = query;
    }

    public async Task createSaleProduct(SaleProduct saleProduct)
    {
        await __command.insertSaleProduct(saleProduct);
    }

    public async Task deleteSaleProduct(SaleProduct saleProduct)
    {
        await __command.removeSaleProduct(saleProduct);
    }

    public Task<List<SaleProduct>> getAll()
    {
        var SaleProduct = __query.getListSaleProducts();
        return Task.FromResult(SaleProduct);
    }

    public Task<SaleProduct> getById(int shoppingCartId)
    {
        var SaleProduct = __query.getSaleProduct(shoppingCartId);
        return Task.FromResult(SaleProduct);
    }
}
