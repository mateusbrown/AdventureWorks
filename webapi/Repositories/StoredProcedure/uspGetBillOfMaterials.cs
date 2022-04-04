using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebApi.Repositories.Data;
using WebApi.Repositories.Models;

namespace WebApi.Repositories.StoredProcedure
{
    public partial class uspGetBillOfMaterials
    {
        private readonly AdventureWorksContext _context;
        public uspGetBillOfMaterials(AdventureWorksContext Context)
        {
            _context = Context;
        }

        public List<Models.BillOfMaterials> Get(int StartProductId, DateTime CheckDate)
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

            return _context.uspGetBillOfMaterials.FromSqlRaw("EXEC dbo.uspGetBillOfMaterials",p.ToArray()).ToList<Models.BillOfMaterials>();
        }
    }
}