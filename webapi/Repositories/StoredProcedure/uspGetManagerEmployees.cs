using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebApi.Repositories.Data;
using WebApi.Repositories.Models;

namespace WebApi.Repositories.StoredProcedure
{
    public partial class uspGetManagerEmployees
    {
        private readonly AdventureWorksContext _context;
        public uspGetManagerEmployees(AdventureWorksContext Context)
        {
            _context = Context;
        }

        public List<Models.ManagerEmployees> Get(int BusinessEntityID)
        {
            var p = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@BusinessEntityID",
                    Value = BusinessEntityID
                }
            };

            return _context.uspGetManagerEmployees.FromSqlRaw("EXEC dbo.uspGetManagerEmployees",p.ToArray()).ToList<Models.ManagerEmployees>();
        }
    }
}