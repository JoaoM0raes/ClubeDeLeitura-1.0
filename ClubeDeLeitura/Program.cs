using System;

namespace ClubeDeLeitura
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CategoriaRevista[] ArrayCategoria = new CategoriaRevista[100]; 
            caixa[] caixas = new caixa[100];
            caixa novaCaixa = new caixa();
            Revista[] ArrayRevistas = new Revista[100];
            amigo[] arrayAmigo = new amigo[100];
            Empréstimo[] arrayEmprestimos = new Empréstimo[100];

            int i = 0;
            int b = 0;
            int c = 0;
            string digitado = "";
            int contador = 0;
            int emprestados = 0;

            while (true)
            {
                mostrarMenu();
                digitado = Console.ReadLine();
                if(digitado!="1"&& digitado!="2" && digitado != "3" && digitado != "4" && digitado != "s" && digitado != "5" && digitado != "6" && digitado != "7")
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
                if (digitado == "3")
                {
                    Console.Clear();
                    Revista novaRevista = new Revista();
                    novaRevista.cadastrarRevista(novaCaixa.revistas, caixas, ref i,ref ArrayRevistas,ref contador,ArrayCategoria,ref c);
                }
                if (digitado == "4")
                {
                    mostrarAmigos( arrayAmigo, ref b);
                }
                if (digitado == "5")
                {
                    Console.Clear();
                    mostrarEmpréstimos(arrayEmprestimos, arrayAmigo, ArrayRevistas, ref b, ref contador, ref arrayEmprestimos, ref emprestados, ArrayCategoria, ref c);    
                }
                if (digitado == "2")
                {
                    CategoriaRevista novaCategoria = new CategoriaRevista();
                    novaCategoria.cadastrarCategoria( ArrayCategoria, ref  c);
                }
            }
        }
        public static void  mostrarMenu()
        {                
                Console.WriteLine("Escreva 1 para adicionar uma caixa");
                Console.WriteLine("Escreva 2 Criar uma nova categoria");
                Console.WriteLine("Escreva 3 para adicionar uma revista");
                Console.WriteLine("Escreva 4 para acessar amigos");
                Console.WriteLine("Escreva 5 para acessar empréstimos");
               
                

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
        public static void mostrarEmpréstimos(Empréstimo[] ArrayEmpréstimo,amigo[] arrayAmigo,Revista[] ArrayRevistas,ref int b,ref int contador,ref Empréstimo[] arrayEmprestimos, ref int emprestados,CategoriaRevista[] ArrayCategoria,ref int c )
        {
            string digitado = "";
            while (true)
            {
                Console.WriteLine("Digite 1 para adicionar um empréstimo");
                Console.WriteLine("Digite 2 para Fechar um empréstimo");
                Console.WriteLine("Digite 3 para mostrar os empréstimos abertos Obs: Empréstimos ao qual a data ainda não alcançou o tempo limite ");
                Console.WriteLine("Digite 4 para mostrar todos os empréstimos já criados");
                digitado = Console.ReadLine();
                if (digitado == "1")
                {
                    Empréstimo novoEmpréstimo = new Empréstimo();
                    novoEmpréstimo.cadastrarEmpréstimo(arrayAmigo, ArrayRevistas, ref b, ref contador, ref arrayEmprestimos, ref emprestados, ArrayCategoria, ref c);
                }
                if (digitado == "3")
                {
                    Console.Clear();
                    mostrarChamadosAbertos(ArrayEmpréstimo);
                }
                if (digitado == "4")
                {
                    Console.Clear();
                    mostrarTodosOsChamados(ArrayEmpréstimo);
                }
                if (digitado == "2")
                {
                    Empréstimo empréstimo = new Empréstimo();
                    empréstimo.terminarEmpéstimo(ArrayEmpréstimo,ref emprestados,arrayAmigo);
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
            string digitado = "";
            while (true)
            {
                for (int i = 0; i < ArrayEmpréstimo.Length; i++)
                {
                    if (ArrayEmpréstimo[i] != null)
                    {
                        if (ArrayEmpréstimo[i].aberto == true)
                        {
                            Console.WriteLine($"Revista emprestada: {ArrayEmpréstimo[i].nomeRevista} \nSolicitante: {ArrayEmpréstimo[i].nomeAmigo} \nData: {ArrayEmpréstimo[i].dataDeEmprestimo.ToShortDateString()} \nData De Devolução: {ArrayEmpréstimo[i].dataDeDevolução.ToShortDateString()}");
                        }
                    }
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
        public static void mostrarTodosOsChamados(Empréstimo[] ArrayEmpréstimo)
        {
            string digitado = "";
            string status = "";
            while (true)
            {
                for (int i = 0; i < ArrayEmpréstimo.Length; i++)
                {
                    if (ArrayEmpréstimo[i] != null)
                    {
                        if (ArrayEmpréstimo[i].aberto == true)
                        {
                            status = "aberto";
                        }
                        else
                        {
                            status = "fechado";
                        }
                        Console.WriteLine($"Revista emprestada: {ArrayEmpréstimo[i].nomeRevista} \nSolicitante: {ArrayEmpréstimo[i].nomeAmigo} \nData: {ArrayEmpréstimo[i].dataDeEmprestimo} \nStatus: {status} ");
                    }
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
        public static void mostrarAmigos(amigo[] arrayAmigo,ref int b)
        {
           
            string digitado = "";
            while (true)
            {
                Console.WriteLine("Escreva 1 para adicionar um Amigo");
                Console.WriteLine("Escreva 2 para quitar a divida de um amigo");
                digitado = Console.ReadLine();
                if (digitado == "1")
                {
                    amigo novoAmigo = new amigo();
                    Console.Clear();
                    novoAmigo.registrarAmigo(ref b, ref arrayAmigo);
                }
                if (digitado == "2")
                {
                    amigo novoAmigo = new amigo();
                    novoAmigo.quitarDivida(arrayAmigo);
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
       
    }
   
   
}
