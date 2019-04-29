using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteArgo
{
    public class teste2
    {
        public List<int> CriarLista(int quantidade)
        {
            var list = new List<int>();
            
            for (int i = 0; i < quantidade; i++)
            {
                list.Add(i);
            }
            return list;
        }

        public List<int> OrdenarLista(params int[] valores)
        {
            var list = valores.OrderBy(y => y).ToList();
            return list;
        }
    }
}
