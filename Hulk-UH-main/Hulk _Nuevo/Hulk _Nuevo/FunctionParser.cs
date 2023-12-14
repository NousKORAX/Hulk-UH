using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Hulk__Nuevo;

namespace Hulk__Nuevo
{
    internal class FunctionParser
    {
        internal static void Start(List<string> Tokens, int posicion)
        {
            List<string> Cuerpo=new List<string>();
            List<string> Parametros = new List<string>();
            for(int i = posicion+3; i < Tokens.Count; i++) 
            {

                if (Tokens[i] == ")")
                {
                    if (Parser.Nombre_Cuerpo.ContainsKey(Tokens[posicion + 1]))
                    {
                        Console.WriteLine("!SEMANTIC ERROR: reserved word");
                    }
                    Parser.Nombre_Parametros.Add(Tokens[posicion+1], Parametros);
                    for(int j = i+1; j < Tokens.Count; j++)
                    {
                        if (Tokens[j] == ">")
                        {
                            for(int k = j+1; k < Tokens.Count; k++)
                            {
                                Cuerpo.Add(Tokens[k]);
                            }
                            Parser.Nombre_Cuerpo.Add(Tokens[posicion+1], Cuerpo);
                            break;
                        }
                    }
                    break;
                }
                Parametros.Add(Tokens[i]);
            }
        }
    }
}
