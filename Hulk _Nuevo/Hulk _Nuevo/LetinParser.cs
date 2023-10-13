using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hulk__Nuevo
{
    internal class LetinParser
    {
        internal static void Start(List<string> Tokens, int posicion)
        {
            int count = 0;
            for(int i = posicion;i < Tokens.Count;i++)
            {
                if (Tokens[i]=="let")count++;
                if (Tokens[i] == "in") count--;
                if (count == 0)
                {
                   List<string> input = new List<string>();
                   for(int j = posicion + 1; j < i; j++)
                    {
                        input.Add(Tokens[j]);
                    }
                   ComaParser.Start(input,-1);
                    input.Clear();
                   for(int j=i+1; j < Tokens.Count; j++)
                    {
                        input.Add(Tokens[j]);
                    }
                    Tokens.RemoveRange(posicion, Tokens.Count-posicion);
                    Tokens.Insert(posicion, Parser.Start(input));
                    Parser.Start(input);
                }
                
                

            }
             Tokens.Clear();    
             Tokens.Add("\"! SYNTAX ERROR: Expected 'in'\""); 
        }
    }
}
