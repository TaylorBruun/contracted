using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using contracted.Models;
using contracted.Repositories;

namespace contracted.Services
{
    public class CompaniesService
    {

        private readonly CompaniesRepository _repo;

        public CompaniesService(CompaniesRepository repo)
        {
            _repo = repo;
        }

        internal List<Company> GetAll()
        {
            List<Company> companies = _repo.GetAll();
            return companies;
        }

        internal Company GetById(int id)
        {
            Company found = _repo.GetById(id);
            if (found == null)
            {
                throw new Exception("Invalid Id");
            }
            return found;
        }

        internal Company Create(Company companyData)
        {
            Company newCompany = _repo.Create(companyData);
            return newCompany;
        }

        internal Company Update(Company companyData, int id)
        {
            Company found = GetById(id);
            found.Name = companyData.Name ?? found.Name;
            _repo.Update(found);
            return found;
        }

        internal void Delete(int id)
        {
            _repo.Delete(id);
        }

        internal List<Company> GetCompaniesByContractor(int id)
        {
            {
            List<Company> companies = _repo.GetGetCompaniesByContractorAll(id);
            return companies;
        }
        }
    }
}