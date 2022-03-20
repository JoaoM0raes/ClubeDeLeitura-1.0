using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDeLeitura
{
    internal class amigo
    {
        public string nomeAmigo;
        public string nomeResponsávelAmigo;
        public int telefoneAmigo;
        public string endereçoAmigo;
        public int multa = 0;

        public void registrarAmigo(ref int b,ref amigo[] arrayAmigo)
        {
            string digitado = "";
            int numbers = 0;
            while (true)
            {
                amigo novoAmigo = new amigo();

                Console.WriteLine("Escreva o nome do Amigo");
                digitado = Console.ReadLine();
                novoAmigo.nomeAmigo = digitado;

                Console.WriteLine("Escreva o nome do Responsável");
                digitado = Console.ReadLine();
                novoAmigo.nomeResponsávelAmigo = digitado;

                Console.WriteLine("Escreva o número do Amigo");
                numbers = Convert.ToInt32(Console.ReadLine());
                novoAmigo.telefoneAmigo = numbers;

                Console.WriteLine("Escreva o endereço do Amigo");
                digitado = Console.ReadLine();
                novoAmigo.endereçoAmigo = digitado;
                arrayAmigo[b] = novoAmigo;
                b++;
                Console.WriteLine("Deseja continuar s/n");
                digitado = Console.ReadLine();
                if (digitado == "s")
                {
                    Console.Clear();
                    continue;
                }
                else
                {
                    Console.Clear();
                    break;
                }
            }
           


        }
        public void quitarDivida(amigo[] arrayAmigo )
        {
            string digitado = "";
            Console.WriteLine("Escreva o nome do amigo para quitar a divida");
            digitado = Console.ReadLine();
            for (int i = 0; i < arrayAmigo.Length; i++)
            {
                if (arrayAmigo[i] != null)
                {
                    if (arrayAmigo[i].nomeAmigo == digitado)
                    {
                        arrayAmigo[i].multa = 0;
                    }
                }
            }
        }
    }
}
