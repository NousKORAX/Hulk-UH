using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hulk__Nuevo
{
    internal class PrintParser
    {
        internal static void Start(List<string> Tokens, int posicion)
        {
            int count = 0;
            for (int i = posicion+1; i < Tokens.Count; i++)
            {
                if (Tokens[i] == "(") { count++; }
                if (Tokens[i] == ")") {  count--; }
                if(count == 0)
                { 
                    Tokens.RemoveAt(posicion);
                    Tokens.RemoveAt(posicion);
                    Tokens.RemoveAt(i-2);
                    break;
                }
            }
        }
    }
}
