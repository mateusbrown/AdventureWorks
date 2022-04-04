using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebApi.Repositories.Data;
using WebApi.Repositories.Models;

namespace WebApi.Repositories.StoredProcedure.HumanResources
{
    public partial class uspUpdateEmployeePersonalInfo
    {
        private readonly AdventureWorksContext _context;
        public uspUpdateEmployeePersonalInfo(AdventureWorksContext Context)
        {
            _context = Context;
        }
        public int Execute(int BusinessEntityID, string NationalIDNumber, DateTime BirthDate, string MaritalStatus, string Gender)
        {
            var p = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@BusinessEntityID",
                    Value = BusinessEntityID
                },
                new SqlParameter()
                {
                    ParameterName = "@NationalIDNumber",
                    Value = NationalIDNumber
                },
                new SqlParameter()
                {
                    ParameterName = "@BirthDate",
                    Value = BirthDate
                },
                new SqlParameter()
                {
                    ParameterName = "@MaritalStatus",
                    Value = MaritalStatus
                },
                new SqlParameter()
                {
                    ParameterName = "@Gender",
                    Value = Gender
                }
            };

            return _context.Database.ExecuteSqlRaw("EXEC [HumanResources].[uspUpdateEmployeePersonalInfo]", p.ToArray());
        }
    }
}