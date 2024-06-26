﻿using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Command;

public class SaleCommands : ISaleCommands
{
    private readonly RetailContext __context;

    public SaleCommands(RetailContext context)
    {
        __context = context;
    }

    public async Task insertSale(Sale sale)
    {
        __context.Add(sale);
        await __context.SaveChangesAsync();
    }

    public async Task removeSale(Sale sale)
    {
        __context.Remove(sale);
        await __context.SaveChangesAsync();
    }
}
