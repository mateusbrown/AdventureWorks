using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebApi.Repositories.Data;
using WebApi.Repositories.Models;

namespace WebApi.Repositories.StoredProcedure.HumanResources
{
    public partial class uspUpdateEmployeeLogin
    {
        private readonly AdventureWorksContext _context;
        public uspUpdateEmployeeLogin(AdventureWorksContext Context)
        {
            _context = Context;
        }
        public int Execute(int BusinessEntityID, HierarchyId OrganizationNode, string LoginID, string JobTitle, DateTime HireDate, bool CurrentFlag)
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
                    ParameterName = "@OrganizationNode",
                    Value = OrganizationNode
                },
                new SqlParameter()
                {
                    ParameterName = "@LoginID",
                    Value = LoginID
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
                    ParameterName = "@CurrentFlag",
                    Value = CurrentFlag
                }
            };

            return _context.Database.ExecuteSqlRaw("EXEC [HumanResources].[uspUpdateEmployeeLogin]", p.ToArray());
        }
    }
}