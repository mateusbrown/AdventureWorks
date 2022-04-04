using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebApi.Repositories.Data;
using WebApi.Repositories.Models;

namespace WebApi.Repositories.Functions
{
    public partial class ufnGetProductDealerPrice
    {
        private readonly AdventureWorksContext _context;
        public ufnGetProductDealerPrice(AdventureWorksContext Context)
        {
            _context = Context;
        }

        public List<Models.ProductDealerPrice> Get(int ProductId, DateTime OrderDate)
        {
            var p = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@ProductId",
                    Value = ProductId
                },
                new SqlParameter()
                {
                    ParameterName = "@OrderDate",
                    Value = OrderDate
                }
            };

            return _context.ufnGetProductDealerPrice.FromSqlRaw("SELECT DealerPrice = dbo.ufnGetProductDealerPrice(@ProductId, @OrderDate)",p.ToArray()).ToList<Models.ProductDealerPrice>();
        }
    }
}