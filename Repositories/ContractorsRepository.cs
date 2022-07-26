using System.Collections.Generic;
using System.Data;
using System.Linq;
using contracted.Models;
using Dapper;

namespace contracted.Repositories
{
    public class ContractorsRepository
    {

        private readonly IDbConnection _db;

        public ContractorsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal List<Contractor> GetAll()
        {
            string sql = "SELECT * FROM contractors";
            return _db.Query<Contractor>(sql).ToList();
        }

        internal Contractor GetById(int id)
        {
            string sql = "SELECT * FROM contractors WHERE id = @Id";
            return _db.QueryFirstOrDefault<Contractor>(sql, new { id });
        }

        internal Contractor Create(Contractor ContractorData)
        {
            string sql = "INSERT INTO contractors (name) VALUES (@Name); SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, ContractorData);
            ContractorData.Id = id;
            return ContractorData;
        }

        internal void Update(Contractor original)
        {
            string sql = "UPDATE contractors SET name=@Name WHERE id=@Id LIMIT 1;";
            _db.Execute(sql, original);
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM contractors WHERE id = @Id LIMIT 1";
            _db.Execute(sql, new{id});
        }
    }
}