using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestePleno.Controllers;
using TestePleno.Models;
using TestePleno.Services;

namespace TestePleno
{
    class Program
    {
        static void Main(string[] args)
        {
            var fare = new Fare();
            fare.Id = Guid.NewGuid();

            Console.WriteLine("Informe o valor da tarifa a ser cadastrada:");
            var fareValueInput = Console.ReadLine();
            fare.Value = decimal.Parse(fareValueInput);

            Console.WriteLine("Informe o código da operadora para a tarifa:");
            Console.WriteLine("Exemplos: OP01, OP02, OP03...");
            var operatorCodeInput = Console.ReadLine();

            var fareController = new FareController();
            fareController.CreateFare(fare, operatorCodeInput);

            Console.WriteLine("Tarifa cadastrada com sucesso!");
        }
    }
}