using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using contracted.Models;
using Dapper;

namespace contracted.Repositories
{
    public class CompaniesRepository
    {

        private readonly IDbConnection _db;

        public CompaniesRepository(IDbConnection db)
        {
            _db = db;
        }

        internal List<Company> GetAll()
        {
            string sql = "SELECT * FROM companies";
            return _db.Query<Company>(sql).ToList();
        }

        internal Company GetById(int id)
        {
            string sql = "SELECT * FROM companies WHERE id = @Id";
            return _db.QueryFirstOrDefault<Company>(sql, new { id });
        }

        internal Company Create(Company companyData)
        {
            string sql = "INSERT INTO companies (name) VALUES (@Name); SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, companyData);
            companyData.Id = id;
            return companyData;
        }

        internal void Update(Company original)
        {
            string sql = "UPDATE companies SET name=@Name WHERE id=@Id LIMIT 1;";
            _db.Execute(sql, original);
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM companies WHERE id = @Id LIMIT 1";
            _db.Execute(sql, new{id});
        }

        internal List<Company> GetCompaniesByContractor(int id)
        {
            string sql = "SELECT * from jobs JOIN companies ON jobs.companyId = companies.id WHERE contractorId = @Id";
            return _db.Query<>(sql, new{id}).ToList();
        }
    }
}