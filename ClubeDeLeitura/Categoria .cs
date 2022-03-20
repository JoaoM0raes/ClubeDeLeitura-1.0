using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDeLeitura
{
    internal class CategoriaRevista
    {
        public string nome;
        public int quantidadeDeDias;
        public Revista[] revistas = new Revista[100];

        public void cadastrarCategoria( CategoriaRevista[] categorias ,ref int c )
        {
            string digitado = "";
            int numbers = 0;
            CategoriaRevista novaCategoria = new CategoriaRevista();
            Console.WriteLine("Escreva o Nome da categoria");
            digitado = Console.ReadLine();
            novaCategoria.nome = digitado;

            Console.WriteLine("Escreva a quantidade de dias para o empréstimo");
            numbers = Convert.ToInt32(Console.ReadLine());
            novaCategoria.quantidadeDeDias = numbers;
            categorias[c] = novaCategoria;
            c++;
        }
        public int Obterposição()
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
