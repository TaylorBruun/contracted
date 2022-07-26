using System;
using System.Collections.Generic;
using contracted.Models;
using contracted.Repositories;

namespace contracted.Services
{
    public class ContractorsService
    {

        private readonly ContractorsRepository _repo;

        public ContractorsService(ContractorsRepository repo)
        {
            _repo = repo;
        }

        internal List<Contractor> GetAll()
        {
            List<Contractor> contractors = _repo.GetAll();
            return contractors;
        }

        internal Contractor GetById(int id)
        {
            Contractor found = _repo.GetById(id);
            if (found == null)
            {
                throw new Exception("Invalid Id");
            }
            return found;
        }

        internal Contractor Create(Contractor contractorData)
        {
            Contractor newContractor = _repo.Create(contractorData);
            return newContractor;
        }

        internal Contractor Update(Contractor contractorData, int id)
        {
            Contractor found = GetById(id);
            found.Name = contractorData.Name ?? found.Name;
            _repo.Update(found);
            return found;
        }

        internal void Delete(int id)
        {
            _repo.Delete(id);
        }
    }
}