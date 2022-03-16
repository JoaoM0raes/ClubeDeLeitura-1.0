using System;

namespace ClubeDeLeitura
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            caixa[] caixas = new caixa[100];
            caixa novaCaixa = new caixa();
            Revista[] ArrayRevistas = new Revista[100];
            amigo[] arrayAmigo = new amigo[100];
            Empréstimo[] arrayEmprestimos = new Empréstimo[100];

            int i = 0;
            int b = 0;
            string digitado = "";
            int contador = 0;
            int emprestados = 0;

            while (true)
            {
                mostrarMenu();
                digitado = Console.ReadLine();
                if(digitado!="1"&& digitado!="2" && digitado != "3" && digitado != "4" && digitado != "s" && digitado != "5" && digitado != "6")
                {
                    Console.WriteLine("Escreva uma opção válida!!!");
                    continue;
                }
                if (digitado == "s")
                {
                    break;
                }
                if (digitado == "1")
                {
                    Console.Clear();
                    mostrarCaixas(ref caixas, novaCaixa, ref i);
                }
                if (digitado == "2")
                {
                    Console.Clear();
                    Revista novaRevista = new Revista();
                    novaRevista.cadastrarRevista(novaCaixa.revistas, caixas, ref i,ref ArrayRevistas,ref contador);
                }
                if (digitado == "3")
                {
                    Console.Clear();
                    amigo novoAmigo = new amigo();
                    novoAmigo.registrarAmigo(ref b, ref arrayAmigo);
                }
                if (digitado == "4")
                {
                    Console.Clear();
                    Empréstimo novoEmpréstimo = new Empréstimo();
                    novoEmpréstimo.cadastrarEmpréstimo(arrayAmigo, ArrayRevistas,ref b,ref contador,ref arrayEmprestimos,ref emprestados);
                }
                if (digitado == "5")
                {
                    mostrarRevistas(ArrayRevistas,contador);
                }
                if (digitado == "6")
                {
                    mostrarEmpréstimos(arrayEmprestimos);
                }
            }
        }
        public static void  mostrarMenu()
        {                
                Console.WriteLine("Escreva 1 para adicionar uma caixa");
                Console.WriteLine("Escreva 2 para adicionar uma revista");
                Console.WriteLine("Escreva 3 para adicionar um amigo");
                Console.WriteLine("Escreva 4 para adicionar um empréstimo");
                Console.WriteLine("Escreva 5 para vizualizar revistas criadas");
                Console.WriteLine("Escreva 6 para vizualizar todos os Empréstimos");

                Console.WriteLine("Digite S para sair ");
        }
        public static void mostrarCaixas(ref caixa[] caixas, caixa novaCaixa,ref int i)
        {
            string digitado = "";
            while (true)
            {
                caixas[i] = novaCaixa.cadastrarCaixa();
                i++;
                Console.WriteLine("Deseja criar outra caixa? s/n");
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
        public static void mostrarRevistas(Revista[] ArrayRevistas,int contador)
        {
            for (int i = 0; i < ArrayRevistas.Length; i++)
            {
                if (ArrayRevistas[i] != null)
                {
                    Console.WriteLine($"Revista: {ArrayRevistas[i].nomeRevista} \nQual Caixa Pertence: {ArrayRevistas[i].caixaGuardada}");
                }  
            }
        }
        public static void mostrarEmpréstimos(Empréstimo[] ArrayEmpréstimo)
        {
            string digitado = "";
            while (true)
            {
                Console.WriteLine("Digite 1 para mostrar os empréstimos abertos Obs: Empréstimos ao qual a data ainda não alcançou o tempo limite ");
                Console.WriteLine("Digite 2 para mostrar todos os empréstimos já criados");
                digitado = Console.ReadLine();
                if (digitado == "1")
                {
                    Console.Clear();
                    mostrarChamadosAbertos(ArrayEmpréstimo);
                }
                if (digitado == "2")
                {
                    Console.Clear();
                    mostrarTodosOsChamados(ArrayEmpréstimo);
                }
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
        public static void mostrarChamadosAbertos(Empréstimo[] ArrayEmpréstimo)
        {

            for (int i = 0; i < ArrayEmpréstimo.Length; i++)
            {
                if (ArrayEmpréstimo[i] != null)
                {
                    if (ArrayEmpréstimo[i].dataDeDevolução > DateTime.Now)
                    {
                        Console.WriteLine($"Revista emprestada: {ArrayEmpréstimo[i].nomeRevista} \nSolicitante: {ArrayEmpréstimo[i].nomeAmigo} \nData: {ArrayEmpréstimo[i].dataDeEmprestimo}");
                    }

                }
            }

        }
        public static void mostrarTodosOsChamados(Empréstimo[] ArrayEmpréstimo)
        {
            for (int i = 0; i < ArrayEmpréstimo.Length; i++)
            {
                if (ArrayEmpréstimo[i]!= null)
                {
                    Console.WriteLine($"Revista emprestada: {ArrayEmpréstimo[i].nomeRevista} \nSolicitante: {ArrayEmpréstimo[i].nomeAmigo} \nData: {ArrayEmpréstimo[i].dataDeEmprestimo}");
                }
                
            }
        }
    }
   
   
}
