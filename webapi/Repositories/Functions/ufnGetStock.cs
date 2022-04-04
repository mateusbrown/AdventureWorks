using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebApi.Repositories.Data;
using WebApi.Repositories.Models;

namespace WebApi.Repositories.Functions
{
    public partial class ufnGetStock
    {
        private readonly AdventureWorksContext _context;
        public ufnGetStock(AdventureWorksContext Context)
        {
            _context = Context;
        }

        public List<Models.Stock> Get(int ProductId)
        {
            var p = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@ProductId",
                    Value = ProductId
                }
            };

            return _context.ufnGetStock.FromSqlRaw("SELECT Quantity = dbo.ufnGetStock(@ProductId)",p.ToArray()).ToList<Models.Stock>();
        }
    }
}