using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDeLeitura
{
    internal class Empréstimo
    {
        public string nomeAmigo;
        public string nomeRevista;
        public DateTime dataDeEmprestimo;
        public DateTime dataDeDevolução;
        

        public void cadastrarEmpréstimo(amigo[] arrayAmigo,Revista[] arrayRevista,ref int b,ref int contador,ref Empréstimo[]arrayEmpréstimo,ref int emprestados)
        {
            string digitado = "";
            
            while (true)
            {
                Empréstimo novoEmprestimo = new Empréstimo();
                Console.WriteLine("Escreva o nome do Amigo");
                digitado = Console.ReadLine();
                bool amigoRepetido = false;
                for (int i = 0; i < emprestados; i++)
                {
                    if (digitado == arrayEmpréstimo[i].nomeAmigo)
                    {
                        amigoRepetido = true;
                        break;
                    }
                }
                if (amigoRepetido == true)
                {
                    Console.WriteLine("O Amigo só deve realizar Um empréstimo por vez");
                    continue;
                }
                bool amigoExiste = false;
                for (int i = 0; i < b; i++)
                {
                    if (arrayAmigo[i].nomeAmigo == digitado)
                    {
                        novoEmprestimo.nomeAmigo = digitado;
                        amigoExiste = true;
                    }
                }
                if (amigoExiste == false)
                {
                    Console.WriteLine("Nome de amigo ainda não adicionado");
                    continue;

                }
                amigoExiste = false;


                Console.WriteLine("Escreva o nome da Revista");
                digitado = Console.ReadLine();
                bool revistaExiste = false;
                for (int i = 0; i < b; i++)
                {
                    if (arrayRevista[i].nomeRevista == digitado)
                    {
                        novoEmprestimo.nomeRevista = digitado;
                        revistaExiste = true;
                    }
                }
                if (revistaExiste == false)
                {
                    Console.Clear();
                    Console.WriteLine("Nome da revista iválido");
                    continue;
                }
                revistaExiste = false;
                

                Console.WriteLine("Escreva a data de empréstimo MM/dd/AAAA");
                digitado = Console.ReadLine();
                DateTime temp;
                if (DateTime.TryParse(digitado, out temp))
                {
                    novoEmprestimo.dataDeEmprestimo = temp;
                }
                else
                {
                    Console.WriteLine("Favor digitar um data válida");
                    continue;
                }
                Console.WriteLine("Escreva a data de devolução");
                digitado = Console.ReadLine();
                DateTime time;
                if (DateTime.TryParse(digitado, out time))
                {
                    novoEmprestimo.dataDeDevolução = time;
                }
                else
                {
                    Console.WriteLine("Favor digitar um data válida");
                    continue;
                }
                

                arrayEmpréstimo[emprestados] = novoEmprestimo;
                emprestados++;


                Console.WriteLine("Deseja continuar s/n");
                digitado = Console.ReadLine();
                if (digitado == "s")
                {
                    continue;
                }
                else
                {
                    break;
                }
            }
           
            
        }
    }
}
