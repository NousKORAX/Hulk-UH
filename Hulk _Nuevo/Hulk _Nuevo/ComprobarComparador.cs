using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hulk__Nuevo
{
    internal class ComprobarComparador
    {
        public static string Start(List<string> Tokens)
        {
            for(int i = 0; i < Tokens.Count; i++)
            {
                if (Tokens[i] == "==" || Tokens[i] == "<=" || Tokens[i] == ">=" || Tokens[i] == "!=" || Tokens[i] == ">" || Tokens[i] == "<")
                {
                   
                    ParserMetodos.Comparar(Tokens, i);
                    return Tokens[0];
                    
                   
                }
            }
            return "false";
        }
    }
}
