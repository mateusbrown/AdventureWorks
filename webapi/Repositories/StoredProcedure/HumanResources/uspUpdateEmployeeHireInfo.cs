using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebApi.Repositories.Data;
using WebApi.Repositories.Models;

namespace WebApi.Repositories.StoredProcedure.HumanResources
{
    public partial class uspUpdateEmployeeHireInfo
    {
        private readonly AdventureWorksContext _context;
        public uspUpdateEmployeeHireInfo(AdventureWorksContext Context)
        {
            _context = Context;
        }
        public int Execute(int BusinessEntityID, string JobTitle, DateTime HireDate, DateTime RateChangeDate, double Rate, Byte PayFrequency, bool CurrentFlag)
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
                    ParameterName = "@JobTitle",
                    Value = JobTitle
                },
                new SqlParameter()
                {
                    ParameterName = "@HireDate",
                    Value = HireDate
                },
                new SqlParameter()
                {
                    ParameterName = "@RateChangeDate",
                    Value = RateChangeDate
                },
                new SqlParameter()
                {
                    ParameterName = "@Rate",
                    Value = Rate
                },
                new SqlParameter()
                {
                    ParameterName = "@PayFrequency",
                    Value = PayFrequency
                },
                new SqlParameter()
                {
                    ParameterName = "@CurrentFlag",
                    Value = CurrentFlag
                }
            };

            return _context.Database.ExecuteSqlRaw("EXEC [HumanResources].[uspUpdateEmployeeHireInfo]", p.ToArray());
        }
    }
}