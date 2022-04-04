using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebApi.Repositories.Data;
using WebApi.Repositories.Models;

namespace WebApi.Repositories.StoredProcedure
{
    public partial class uspSearchCandidateResumes
    {
        private readonly AdventureWorksContext _context;
        public uspSearchCandidateResumes(AdventureWorksContext Context)
        {
            _context = Context;
        }

        public List<Models.SearchCandidateResumes> Get(string Search, bool UseInflectional, bool UseThesaurus, int Language)
        {
            var p = new List<SqlParameter>()
            {
                new SqlParameter()
                {
                    ParameterName = "@searchString",
                    Value = Search
                },
                new SqlParameter()
                {
                    ParameterName = "@useInflectional",
                    Value = UseInflectional
                },
                new SqlParameter()
                {
                    ParameterName = "@useThesaurus",
                    Value = UseThesaurus
                },
                new SqlParameter()
                {
                    ParameterName = "@language",
                    Value = Language
                }
            };

            return _context.uspSearchCandidateResumes.FromSqlRaw("EXEC dbo.uspSearchCandidateResumes",p.ToArray()).ToList<Models.SearchCandidateResumes>();
        }
    }
}