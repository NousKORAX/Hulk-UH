using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hulk__Nuevo
{
    internal class ParserMetodos
    {
        internal static void Letin (List<string>Tokens, int posicion)
        {
             LetinParser.Start(Tokens, posicion);
            
        }
        internal static void Function(List<string> Tokens, int posicion)
        {
            FunctionParser.Start(Tokens, posicion);
        }
        internal static void If(List<string> Tokens, int posicion)
        {
            IfParser.Start(Tokens, posicion);
        }
        internal static void Print(List<string> Tokens, int posicion)
        {
            PrintParser.Start(Tokens, posicion);
        }
        internal static void UsarFunction(List<string> Tokens, int posicion)
        {
            UsarFunctionParser.Start(Tokens, posicion);

        }
        internal static void ConcatenarString(List<string> Tokens, int posicion)
        {
            Tokens.Remove("@");
            
        }
        internal static void Comparar(List<string> Tokens, int posicion)
        {
            List<string> MiembroIzquierdo = new List<string>();
            List<string> MiembroDerecho = new List<string>();
            for (int i=0; i<posicion; i++)
            {
                MiembroIzquierdo.Add(Tokens[i]);
            }
            for(int i=posicion+1;i<Tokens.Count;i++)
            {
                MiembroDerecho.Add(Tokens[i]); 
            }
            string Valor = (Comparador.Start(Parser.Start(MiembroIzquierdo), Tokens[posicion], Parser.Start(MiembroDerecho))).ToString();
            Tokens.Clear();
            Tokens.Add(Valor);

        }
        internal static void Coma(List<string>Tokens, int posicion)
        {
            ComaParser.Start(Tokens, posicion);
        }
    }
}
