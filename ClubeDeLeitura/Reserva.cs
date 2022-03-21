using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDeLeitura
{
    internal class Reserva
    {
        public string nomeAmigo;
        public string nomeRevista;
        public DateTime dataReserva;
        public bool valido;

        public void reservarRevista(Reserva[] arrayReserva, amigo[] arrayAmigo, Revista[] arrayRevista,  ref int b, ref int contador, ref Empréstimo[] arrayEmpréstimo, ref int emprestados, CategoriaRevista[] categorias, ref int c)
        {
            int k = 0;
            string digitado = "";
            string nome = "";
            string revista = "";
            DateTime dataReservaDate = DateTime.Now;    
            while (true)
            {
                
                Reserva novaReserva = new Reserva();
                Console.WriteLine("Escreva o nome do amigo para criar uma reserva");
               nome = Console.ReadLine();
                bool existente = false;
                for (int i = 0; i < arrayAmigo.Length; i++)
                {
                    if(arrayAmigo[i] != null)
                    {
                        if (arrayAmigo[i].nomeAmigo == nome)
                        {
                            novaReserva.nomeAmigo = nome;
                            existente = true;
                        }
                    }
                  
                }
                if (existente == false)
                {
                    Console.Clear();
                    Console.WriteLine("Amigo não existe");
                    continue;
                }
                Console.WriteLine("Escreva o nome da revista para ser reservada");
               revista = Console.ReadLine();
                bool criado = false;
                for (int i = 0; i < arrayRevista.Length; i++)
                {
                    if (arrayRevista[i] != null)
                    {
                        if (arrayRevista[i].nomeRevista == revista)
                        {
                            novaReserva.nomeRevista = revista;
                            arrayRevista[i].reservado = true;
    
                            criado = true;
                        }
                    }
                  
                }
                if (criado == false)
                {
                    Console.WriteLine("Revista não existe");
                }

                novaReserva.dataReserva = DateTime.Now;
               ;
                arrayReserva[k] = novaReserva;
                k++;

                for (int i = 0; i < arrayReserva.Length; i++)
                {
                    if (arrayReserva[i] != null)
                    {
                        if (arrayReserva[i].dataReserva > arrayReserva[i].dataReserva.AddDays(2))
                        {
                            arrayReserva[i].valido = false;
                            arrayRevista[i].reservado = false;
                        }
                    }
                    
                }
                Console.WriteLine("Deseja criar um empréstimo já? s/n");
                digitado=Console.ReadLine();
                if (digitado == "s")
                {
                    Empréstimo novoEmprestimo = new Empréstimo();
                  
                    bool amigoRepetido = false;
                    for (int i = 0; i < emprestados; i++)
                    {
                        if (arrayEmpréstimo[i].aberto == true)
                        {
                            if (nome == arrayEmpréstimo[i].nomeAmigo)
                            {
                                amigoRepetido = true;
                                break;
                            }
                        }
                    }
                    if (amigoRepetido == true)
                    {
                        Console.Clear();
                        Console.WriteLine("O Amigo só deve realizar Um empréstimo por vez");
                        break;
                    }
                    bool amigoExiste = false;
                    for (int i = 0; i < b; i++)
                    {
                        if (arrayAmigo[i].nomeAmigo == nome && arrayAmigo[i].multa == 0 && arrayAmigo[i].multa == 0)
                        {
                            novoEmprestimo.nomeAmigo = nome;
                            amigoExiste = true;
                        }
                    }
                    if (amigoExiste == false)
                    {
                        Console.Clear();
                        Console.WriteLine("Nome de amigo ainda não adicionado Ou Ele está Devendo");
                        break;

                    }
                    amigoExiste = false;


                    
                    bool revistaExiste = false;
                    for (int i = 0; i < contador; i++)
                    {
                        if (arrayRevista[i].nomeRevista == revista )
                        {
                            novoEmprestimo.nomeRevista = revista;
                            revistaExiste = true;
                        }
                    }
                    if (revistaExiste == false)
                    {
                        Console.Clear();
                        Console.WriteLine("Nome da revista iválido Ou Revista já reservada");
                        break;
                    }
                    int days = 0;
                    for (int i = 0; i < c; i++)
                    {
                        for (int l = 0; l < contador; l++)
                        {
                            if (categorias[i].revistas[l] != null)
                            {
                                if (categorias[i].revistas[l].nomeRevista == revista)
                                {
                                    days = categorias[i].quantidadeDeDias;
                                    break;
                                }
                            }

                        }
                    }
                    revistaExiste = false;


                    DateTime temp = DateTime.Now;
                    novoEmprestimo.dataDeEmprestimo = DateTime.Now;



                    novoEmprestimo.dataDeDevolução = temp.AddDays(days);


                    novoEmprestimo.aberto = true;

                    arrayEmpréstimo[emprestados] = novoEmprestimo;
                    emprestados++;
                    Console.WriteLine("Empréstimo criado!!!");
                    break;
                }
                else
                {
                    break;
                }
               
            }           
        }
    }
}
