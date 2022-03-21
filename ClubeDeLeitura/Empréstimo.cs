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
        public bool aberto;
         
        

        public void cadastrarEmpréstimo(amigo[] arrayAmigo,Revista[] arrayRevista,ref int b,ref int contador,ref Empréstimo[]arrayEmpréstimo,ref int emprestados,CategoriaRevista[] categorias, ref int c )
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
                    if (arrayEmpréstimo[i].aberto==true)
                    {
                        if (digitado == arrayEmpréstimo[i].nomeAmigo)
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
                    if (arrayAmigo[i].nomeAmigo == digitado && arrayAmigo[i].multa== 0 && arrayAmigo[i].multa == 0)
                    {
                        novoEmprestimo.nomeAmigo = digitado;
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


                Console.WriteLine("Escreva o nome da Revista");
                digitado = Console.ReadLine();
                bool revistaExiste = false;
                for (int i = 0; i < contador; i++)
                {
                    if (arrayRevista[i].nomeRevista == digitado && arrayRevista[i].reservado==false)
                    {
                        novoEmprestimo.nomeRevista = digitado;
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
                            if (categorias[i].revistas[l].nomeRevista == digitado)
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
           
            
        }
        public void terminarEmpéstimo(Empréstimo[] arrayEmpréstimo,ref int emprestados,amigo[] arrayAmigo)
        {
            int multa = 0;
            bool pegouMulta = false;
            string digitado = "";
            DateTime data = DateTime.Now;
            string pegarData = "";
            while (true)
            {
                Console.WriteLine("Escreva o nome do amigo para a devolução do emprestimo");
                digitado = Console.ReadLine();
                for (int i = 0; i < emprestados; i++)
                {
                    if (arrayEmpréstimo[i].nomeAmigo == digitado)
                    {
                        arrayEmpréstimo[i].aberto = false;
                        data = arrayEmpréstimo[i].dataDeDevolução;
                    }
                }
                Console.WriteLine("Escreva a data em que o amigo devolveu a revista");
                pegarData = Console.ReadLine();
                DateTime temp;
                if (DateTime.TryParse(pegarData, out temp))
                {
                   
                }
                else
                {
                    Console.WriteLine("Favor digitar um data válida");
                    continue;
                }
                
                if (temp > data)     
                    pegouMulta = true;                
                else                
                    pegouMulta = false;

                if (pegouMulta == true)
                {
                    Console.WriteLine("Escreva a multa para aplica-la (Você pode quitar a multa do amigo aqui!!!!)");
                    multa = Convert.ToInt32(Console.ReadLine());
                    for (int i = 0; i < arrayAmigo.Length; i++)
                    {
                        if (arrayAmigo[i] != null)
                        {
                            if (arrayAmigo[i].nomeAmigo == digitado)
                            {
                                if (pegouMulta == true)
                                {
                                    arrayAmigo[i].multa = multa;
                                }
                            }
                        }
                    }
                }
                Console.WriteLine("Empréstimo fechado!!!");
                break;
             



            }
           
        }
        
    }
}
