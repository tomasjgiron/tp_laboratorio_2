using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        
        private double numero;

        public string SetNumero
        {
            set
            {
                numero = ValidarNumero(value);
            }
        }

        public Numero()
        {
            numero = 0;
        }

        public Numero(double numero)
        {
            this.numero = numero;
        }
       
        public Numero(string strNumero)
        {
            double.TryParse(strNumero, out numero);
        }

        private double ValidarNumero(string strNumero)
        {
            double retorno = 0;

            double.TryParse(strNumero, out retorno);

            return retorno;
        }

        public string BinarioADecimal(string binario)
        {
            string retorno = "Valor Inválido";
            int aux;
            string auxString;

            int.TryParse(binario, out aux);
            if(aux < 0)
            {
                Math.Abs(aux);
            }

            if (aux == 0)
            {
                retorno = "0";
            }
            else
            {
                auxString = aux.ToString();
                char[] array = auxString.ToCharArray();
                Array.Reverse(array);
                int sumatoria = 0;

                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] == '1')
                    {
                        sumatoria += (int)Math.Pow(2, i);
                    }
                }
                retorno = Convert.ToString(sumatoria);
            }

            return retorno;
        }

        public string DecimalABinario(double numero)
        {
            string retorno = "Valor Inválido";
            int aux;
            string auxString;

            auxString = numero.ToString();

            int.TryParse(auxString, out aux);
            if (aux < 0)
            {
                Math.Abs(aux);
            }

            List<char> listaBinario = new List<char>();
            while(aux >= 0)
            {
                listaBinario.Add(aux % 2 == 0 ? '0' : '1');
                if(aux == 0)
                {
                    retorno = "0";
                    break;
                }
                aux /= 2;
            }

            listaBinario.Reverse();
            retorno = string.Join(string.Empty, listaBinario);
            return retorno;
        }

        public string DecimalABinario(string numero)
        {
            string retorno = "Valor Inválido";
            double doble;

            if(double.TryParse(numero, out doble))
            {
                Numero valor = new Numero(doble); //preciso el constructor para llamar al método de abajo
                retorno = valor.DecimalABinario(doble);
            }
            return retorno;
        }

        public static double operator -(Numero n1, Numero n2) => n1.numero - n2.numero; //resto el campo de los objetos creados en los parámetros

        public static double operator *(Numero n1, Numero n2) => n1.numero * n2.numero;

        public static double operator +(Numero n1, Numero n2) => n1.numero + n2.numero;

        public static double operator /(Numero n1, Numero n2)
        {
            double retorno = double.MinValue;
            if(n2.numero != 0) //valido que no sea división por 0
            {
               retorno = n1.numero / n2.numero;
            }
            return retorno;
        }
    }
}
