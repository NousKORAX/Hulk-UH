using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hulk__Nuevo
{
    internal class UsarFunctionParser
    {
        internal static void Start(List<string>Tokens, int posicion)
        {
            Dictionary<string, string> VariablesFuncion = new Dictionary<string, string>();
            int count = 0;
            for(int i=posicion+1; i < Tokens.Count; i++)
            {
                if (Tokens[i] == "(") { count++; }
                if (Tokens[i] == ")") { count--; }
                if(count == 0)
                {
                    List<string> valores= new List<string>();    
                    for(int j=posicion+2; j<i; j++)
                    {
                        valores.Add(Tokens[j]);
                    }
                    ComaParser.Start(valores,-1);
                    List<string> Variables = Parser.Nombre_Parametros[Tokens[posicion]];
                    for(int j=0; j<valores.Count; j+=2)
                    {
                        VariablesFuncion.Add(Variables[j], valores[j]);
                    }
                    
                    List<string> Cuerpo =new List<string>();
                    for (int j=0 ; j < Parser.Nombre_Cuerpo[Tokens[posicion]].Count ; j++)
                    {
                        Cuerpo.Add( SustituirVariable.Sustitucion(Parser.Nombre_Cuerpo[Tokens[posicion]][j], VariablesFuncion));
                    }
                    VariablesFuncion.Clear();
                    string resultado = Parser.Start(Cuerpo);
                    Tokens.RemoveRange(posicion, i - posicion+1);
                    Tokens.Insert(posicion, resultado);
                    break;
                }
            }

            Tokens.Clear();
            Tokens.Add("\"! SYNTAX ERROR: Missing closing parenthesis\"");
        }
    }
}
