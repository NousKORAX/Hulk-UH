using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hulk__Nuevo
{
    internal class ComaParser
    {
        internal static void Start(List<string> Tokens, int posicion)
        {
            int parentesis_count = 0;
            int letint_count = 0;
            for (int i = posicion+1; i < Tokens.Count; i++)
            {
                if (Tokens[i] == "(") { parentesis_count++; }
                if (Tokens[i] == "let") {  letint_count++; }
                if (Tokens[i] == "in") {  letint_count--; }
                if ((Tokens[i] == "," || Tokens[i]==")"||i==Tokens.Count-1)&&parentesis_count==0&&letint_count==0) 
                {
                    if(i==Tokens.Count - 1)
                    {
                        i++;
                    }
                    List<string> valores=new List<string>();    
                    for(int j=posicion+1; j < i; j++) 
                    {
                        valores.Add(Tokens[j]);
                    }
                    Tokens.RemoveRange(posicion+1, i-posicion-1);
                    Tokens.Insert(posicion+1, Parser.Start(valores));
                    i = posicion + 2;
                    posicion+=2;
                    if (i == Tokens.Count)
                    {
                        i--;
                    }
                }
                if (Tokens[i] == ")") 
                { parentesis_count--; if (i == Tokens.Count-1) { i--; } }
            }
        }
    }
}
