using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebApi.Repositories.Data;
using WebApi.Repositories.Models;

namespace WebApi.Repositories.StoredProcedure
{
    public partial class uspGetEmployeeManagers
    {
        private readonly AdventureWorksContext _context;
        public uspGetEmployeeManagers(AdventureWorksContext Context)
        {
            _context = Context;
        }

        public List<Models.EmployeeManagers> Get(int BusinessEntityID)
        {
            var p = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@BusinessEntityID",
                    Value = BusinessEntityID
                }
            };

            return _context.uspGetEmployeeManagers.FromSqlRaw("EXEC dbo.uspGetEmployeeManagers",p.ToArray()).ToList<Models.EmployeeManagers>();
        }
    }
}