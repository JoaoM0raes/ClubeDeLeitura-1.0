using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDeLeitura
{
    internal class Revista
    {
        
        public string nomeRevista;
        public string tipoDeRevista;      
        public int númeroDaEdição;
        public string AnoRevista;
        public string caixaGuardada;
        
        public void cadastrarRevista(Revista[] Revistas,caixa[] listaDecaixas,ref int n,ref Revista[] arrayRevista,ref int contador)
        { 
           
            string digitado = "";
            int numbers = 0;
            
            while (true)
            {
                Revista novaRevista = new Revista();
                Console.WriteLine("Escreva o nome da Revista");
                digitado = Console.ReadLine();
                novaRevista.nomeRevista = digitado;

                Console.WriteLine("Escreva o tipo da Revista");
                digitado = Console.ReadLine();
                novaRevista.tipoDeRevista = digitado;

                Console.WriteLine("Escreva o número da edição da Revista");
                numbers = Convert.ToInt32(Console.ReadLine());
                novaRevista.númeroDaEdição = numbers;

                Console.WriteLine("Escreva o ano da Revista");
                digitado =Console.ReadLine();
                DateTime temp;
                if (DateTime.TryParse(digitado, out temp))
                {
                    novaRevista.AnoRevista = digitado;
                }
                else
                {
                    Console.WriteLine("Favor digitar um data válida");
                    continue;
                }
                

                Console.WriteLine("Escreva em qual caixa a revista está guardada");
                digitado = Console.ReadLine();
                novaRevista.caixaGuardada = digitado;
                bool criado = false;
                for (int i = 0; i < n; i++)
                {
                    if (listaDecaixas[i].numeroCaixa == digitado)
                    {
                        int espaçoVazio = listaDecaixas[i].obterPosição();
                        listaDecaixas[i].revistas[espaçoVazio] = novaRevista;
                        criado = true;
                        break;
                    }
                }
                if (criado == false)
                {
                    Console.WriteLine("Caixa não criada");
                    continue;
                }
                criado = false;


                arrayRevista[contador] = novaRevista;
                contador++;
               

                
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
