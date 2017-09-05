using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalData.Domain.ValueObjects
{
    public class Cnpj : Document
    {        
        public override bool Validate()
        {
            var multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            var multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            Number = Number.Trim();
            Number = Number.Replace(".", "").Replace("-", "");
            if (Number.Length != 11)
                return false;
            var tempNumber = Number.Substring(0, 9);
            var soma = 0;

            for (var i = 0; i < 9; i++)
                soma += int.Parse(tempNumber[i].ToString()) * multiplicador1[i];
            var resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            var digito = resto.ToString();
            tempNumber = tempNumber + digito;
            soma = 0;
            for (var i = 0; i < 10; i++)
                soma += int.Parse(tempNumber[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return Number.EndsWith(digito);
        }
    }
}
