using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using contracted.Models;
using Dapper;

namespace contracted.Repositories
{
    public class JobsRepository
    {

         private readonly IDbConnection _db;

        public JobsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal List<Job> GetAll()
        {
            string sql = "SELECT * FROM jobs";
            return _db.Query<Job>(sql).ToList();
        }

        internal Job Create(Job jobData)
        {
            string sql = "INSERT INTO jobs (companyId, contractorId) VALUES (@CompanyId, @ContractorId); SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, jobData);
            jobData.Id = id;
            return jobData;
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM jobs WHERE id = @Id LIMIT 1";
            _db.Execute(sql, new { id });
        }

    }
}