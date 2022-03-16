using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDeLeitura
{
    internal class caixa
    {
        public string corCaixa;
        public string numeroCaixa;
        public string etiquetaCaixa;
        public Revista[] revistas = new Revista[100]; 

        public caixa cadastrarCaixa()
        {
            string digitado = "";

            caixa novaCaixa = new caixa();

            Console.WriteLine("Escreva a cor da caixa");
            digitado = Console.ReadLine();
            novaCaixa.corCaixa = digitado;

            Console.WriteLine("Escreva o numero caixa");
            digitado=Console.ReadLine();
            novaCaixa.numeroCaixa = digitado;

            Console.WriteLine("Escreva a etiqueta da caixa");
            digitado = Console.ReadLine();
            novaCaixa.etiquetaCaixa = digitado;

            return novaCaixa;
        }
        public int obterPosição()
        {
            int posição = 0;
            for (int i = 0; i < revistas.Length; i++)
            {
                if (revistas[i] == null)
                {
                    posição = i;
                    break;
                }
            }
            return posição;
        }
    }
}
