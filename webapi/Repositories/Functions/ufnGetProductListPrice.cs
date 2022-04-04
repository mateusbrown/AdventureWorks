using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebApi.Repositories.Data;
using WebApi.Repositories.Models;

namespace WebApi.Repositories.Functions
{
    public partial class ufnGetProductListPrice
    {
        private readonly AdventureWorksContext _context;
        public ufnGetProductListPrice(AdventureWorksContext Context)
        {
            _context = Context;
        }

        public List<Models.ProductListPrice> Get(int ProductId, DateTime OrderDate)
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

            return _context.ufnGetProductListPrice.FromSqlRaw("SELECT ListPrice = dbo.ufnGetProductListPrice(@ProductId, @OrderDate)",p.ToArray()).ToList<Models.ProductListPrice>();
        }
    }
}