using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestePleno.Models;
using TestePleno.Services;

namespace TestePleno.Controllers
{
    public class FareController
    {
        private OperatorService OperatorService;
        private FareService FareService;

        public FareController()
        {
            OperatorService = new OperatorService();
            FareService = new FareService();
        }

        public void CreateFare(Fare fare, string operatorCode)
        {

            var selectedOperator = OperatorService.GetOperatorByCode(operatorCode);

            if (selectedOperator == null)
            {
                var _operator = new Operator();
                _operator.Id = Guid.NewGuid();
                _operator.Code = operatorCode;
                OperatorService.Create(_operator);
                selectedOperator = _operator;
            }
            else
            {

                if (FareService.FareValidator(fare.Value, selectedOperator.Id)) 
                {
                    throw new Exception($"Já existe um registro para a entidade '{fare.Value}' com o Operadora '{selectedOperator.Code}' no período de 6 meses.");
                }

            }

            fare.OperatorId = selectedOperator.Id;
            FareService.Create(fare);

        }
    }
}
