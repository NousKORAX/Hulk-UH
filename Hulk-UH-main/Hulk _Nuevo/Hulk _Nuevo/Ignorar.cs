using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hulk__Nuevo
{
    internal class Ignorar
    {
        internal static int Start(List<string> Tokens, int posicion)
        {
            for (int i = posicion; i < Tokens.Count; i++) 
            {
                if (Tokens[i] == "\"")
                {
                    return i;
                }
            }
            return -1;  
        }
    }
}
