using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebApi.Repositories.Data;
using WebApi.Repositories.Models;

namespace WebApi.Repositories.Functions
{
    public partial class ufnGetContactInformation
    {
        private readonly AdventureWorksContext _context;
        public ufnGetContactInformation(AdventureWorksContext Context)
        {
            _context = Context;
        }

        public List<Models.ContactInformation> Get(int PersonID)
        {
            var p = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@PersonID",
                    Value = PersonID
                }
            };

            return _context.ufnGetContactInformation.FromSqlRaw("SELECT * FROM dbo.ufnGetContactInformation(@PersonID)",p.ToArray()).ToList<Models.ContactInformation>();
        }
    }
}