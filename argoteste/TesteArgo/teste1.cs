using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteArgo
{
    public class teste1
    {
        public int Somar(int n1, int n2)
        {
            return n1 + n2; // retorna valor da soma de dois números inteiros
        }

        public int Subtrair(int n1, int n2)
        {
            return n1 - n2; //retorna valor da subtração do primeiro valor com o segundo valor
        }

        public decimal Media(params int[] valor)
        {
            return valor.Sum() /valor.Length; //retorna a média dos valores calculados
        }

        public int CalcularIdade(int ano, int mes, int dia)
        {
            int idade = DateTime.Now.Year - ano;
            if (DateTime.Now.Month < mes || (DateTime.Now.Month == mes && DateTime.Now.Day < dia)){
                idade --;
            }
            return idade;
        }

    }
}
