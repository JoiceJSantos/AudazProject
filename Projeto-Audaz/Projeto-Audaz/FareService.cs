using System;
using System.Collections.Generic;
using System.Linq;
using TestePleno.Models;

namespace TestePleno.Services
{
    public class FareService
    {
        private Repository _repository = new Repository();

        public void Create(Fare fare)
        {
            _repository.Insert(fare);
        }

        public void Update(Fare fare)
        {
            _repository.Update(fare);
        }

        public Fare GetFareById(Guid fareId)
        {
            var fare = _repository.GetById<Fare>(fareId);
            return fare;
        }

        public List<Fare> GetFares()
        {
            var fares = _repository.GetAll<Fare>();
            return fares;
        }

        public Boolean FareValidator(decimal value, Guid operatorId)
        {
            var fares = _repository.GetAll<Fare>();
             return fares.Any(selectedFares => selectedFares.OperatorId == operatorId && selectedFares.Value == value && selectedFares.Status == 1 && (selectedFares.InsertedDate >= DateTime.Now.AddMonths(-6)));
        }
    }
}
