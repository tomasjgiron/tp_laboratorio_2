using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        private static string ValidarOperador(string operador)
        {
            string retorno = "+";

            if(operador == "-")
            {
                retorno = "-";
            }
            else if(operador == "*")
            {
                retorno = "*";
            }
            else if(operador == "/")
            {
                retorno = "/";
            }

            return retorno;
        }

        public static double Operar(Numero n1, Numero n2, string operador)
        {
            double retorno = 0;

            if(!(n1 is null) && !(n2 is null))
            {
                switch(ValidarOperador(operador))
                {
                    case "+":
                        {
                            retorno = n1 + n2;
                            break;
                        }
                    case "-":
                        {
                            retorno = n1 - n2;
                            break;
                        }
                    case "*":
                        {
                            retorno = n1 * n2;
                            break;
                        }
                    case "/":
                        {
                            retorno = n1 / n2;
                            break;
                        }
                }
            }
            return retorno;
        }

    }
}
