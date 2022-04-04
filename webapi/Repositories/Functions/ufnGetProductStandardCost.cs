using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebApi.Repositories.Data;
using WebApi.Repositories.Models;

namespace WebApi.Repositories.Functions
{
    public partial class ufnGetProductStandardCost
    {
        private readonly AdventureWorksContext _context;
        public ufnGetProductStandardCost(AdventureWorksContext Context)
        {
            _context = Context;
        }

        public List<Models.ProductStandardCost> Get(int ProductId, DateTime OrderDate)
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

            return _context.ufnGetProductStandardCost.FromSqlRaw("SELECT StandardCost = dbo.ufnGetProductStandardCost(@ProductId, @OrderDate)",p.ToArray()).ToList<Models.ProductStandardCost>();
        }
    }
}