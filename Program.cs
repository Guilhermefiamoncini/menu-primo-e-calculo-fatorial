using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;


namespace Exercicio1
{
    class Program
    {

        static event EventHandler onprimo;
        static event EventHandler onfatorial;

        static void GravarLog(DateTime dataHora, String mensagem)
        {
            try
            {
                if (File.Exists("../../log.txt"))
                {
                    File.AppendAllText("../../log.txt", "\n");
                }

                File.AppendAllText("../../log.txt", String.Format("{0:dd/MM/yyyy HH:mm:ss} - {1}", dataHora, mensagem));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
        static void program_onprimo(object sender, EventArgs e)
        {
            LogEventArgs logEventArgs = (LogEventArgs)e;
            GravarLog(logEventArgs.DataHora, logEventArgs.Mensagem);
        }
        static void Program_Onfatorial(object sender, EventArgs e)
        {
            LogEventArgs logEventArgs = (LogEventArgs)e;
            GravarLog(logEventArgs.DataHora, logEventArgs.Mensagem);
        }



        static Int32 LerInteiroPositivo()
        {
            Int32 numeroLido = 0;
            Boolean lerNumero = true;
            Boolean numeroValido = true;

            while (lerNumero == true)
            {
                try
                {
                    numeroLido = Convert.ToInt32(Console.ReadLine());
                    numeroValido = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Valor inválido, favor informar somente números inteiros positivos");
                    numeroValido = false;
                }

                if (numeroValido == true)
                {
                    if (numeroLido > 0)
                    {
                        lerNumero = false;
                    }
                    else
                    {
                        Console.WriteLine("Número inválido, favor informar somente números inteiros positivos");
                    }
                }
            }

            return numeroLido;
        }

        static void MontarMenu(String[] opcoes, Action[] acoes)
        {
            if (opcoes.Length > 0)
            {
                Boolean imprimirMenu = true;
                StringBuilder menu = new StringBuilder();
                Int32 numeroOpcao = 1;

                menu.Append(numeroOpcao).Append(" - ").Append(opcoes[numeroOpcao - 1]);

                for (numeroOpcao = 2; numeroOpcao <= opcoes.Length; numeroOpcao++)
                {
                    menu.Append("\n").Append(numeroOpcao).Append(" - ").Append(opcoes[numeroOpcao - 1]);
                }

                while (imprimirMenu == true)
                {
                    Console.WriteLine(menu.ToString());
                    Int32 opcaoEscolhida = LerInteiroPositivo();

                    if (opcaoEscolhida < opcoes.Length)
                    {
                        acoes[opcaoEscolhida - 1]();
                    }
                    else if (opcaoEscolhida == opcoes.Length)
                    {
                        imprimirMenu = false;
                    }
                    else
                    {
                        Console.WriteLine("Opção inválida");
                    }
                }
            }
        }





        static void reconhecendonumeroprimo()
        {
            Console.WriteLine("Informe um número inteiro:");
            Int32 numero = Convert.ToInt32(Console.ReadLine());

            if (numero == 1)
            {
                Console.WriteLine("Não é primo");
                onprimo.Invoke(null, new LogEventArgs()
                {
                    DataHora = DateTime.Now,
                    Mensagem = string.Format("o numero {0} não é primo", numero)

                });
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
                        onprimo.Invoke(null, new LogEventArgs()
                        {
                            DataHora = DateTime.Now,
                            Mensagem = string.Format("o numero {0} não é primo", numero)

                        });
                        break;
                    }
                }

                if (numeroPrimo == true)
                {
                    Console.WriteLine("É primo");
                    onprimo.Invoke(null, new LogEventArgs()
                    {
                        DataHora = DateTime.Now,
                        Mensagem = String.Format("o número {0} é primo", numero)

                    });

                }
            }


        }


        static Int32 calcularfatorial(Int32 numero)
        {
            if (numero < 2)
            {
                return 1;
            }
            return numero * calcularfatorial(numero - 1);
        }

        static void fatorial()
        {
            Console.WriteLine("informe um numero");
            Int32 num = LerInteiroPositivo();
            Int32 fat = calcularfatorial(num);

            Console.WriteLine("o fatorial de {0} é {1}",num, fat);
             onfatorial.Invoke(null, new LogEventArgs()
                {
                    DataHora = DateTime.Now,
                    Mensagem = string.Format("o fatorial do número {0} é igual a {1}",num,fat)

                });
        }
    
 

        static void Main(string[] args)
        {
            onprimo += program_onprimo;
            onfatorial += Program_Onfatorial;
            MontarMenu(new String[]
               {
                "verificar primo",
                "calcular fatorial",
                "Sair"
               }, new Action[] {
                reconhecendonumeroprimo,
                fatorial

               });


        }
    }
}