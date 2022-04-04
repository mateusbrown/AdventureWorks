using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebApi.Repositories.Data;
using WebApi.Repositories.Models;

namespace WebApi.Repositories.StoredProcedure
{
    public partial class uspGetWhereUsedProductID
    {
        private readonly AdventureWorksContext _context;
        public uspGetWhereUsedProductID(AdventureWorksContext Context)
        {
            _context = Context;
        }

        public List<Models.WhereUsedProductID> Get(int StartProductId, DateTime CheckDate)
        {
            var p = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@StartProductId",
                    Value = StartProductId
                },
                new SqlParameter()
                {
                    ParameterName = "@CheckDate",
                    Value = CheckDate
                }
            };

            return _context.uspGetWhereUsedProductID.FromSqlRaw("EXEC dbo.uspGetWhereUsedProductID",p.ToArray()).ToList<Models.WhereUsedProductID>();
        }
    }
}