using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio1
{
    class Program
    {
        static Boolean EPrimo(Int32 numero)
        {
            if (numero == 1)
            {
                return false;
            }

            for (Int32 numeroDivisao = 2; numeroDivisao < numero; numeroDivisao++)
            {
                if (numero % numeroDivisao == 0)
                {
                    return false;
                }
            }

            return true;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Informe um número inteiro:");
            Int32 numero = Convert.ToInt32(Console.ReadLine());

            if (numero == 1)
            {
                Console.WriteLine("Não é primo");
            }
            else
            {
                Boolean numeroPrimo = true;

                for (Int32 numeroDivisao = 2; numeroDivisao < numero; numeroDivisao++)
                {
                    if (numero % numeroDivisao == 0)
                    {
                        numeroPrimo = false;
                        Console.WriteLine("Não é primo");
                        break;
                    }
                }

                if (numeroPrimo == true)
                {
                    Console.WriteLine("É primo");
                }
            }

            if (EPrimo(numero) == true)
            {
                Console.WriteLine("É primo");
            }
            else
            {
                Console.WriteLine("Não é primo");
            }

            Console.ReadKey();
        }
    }
}