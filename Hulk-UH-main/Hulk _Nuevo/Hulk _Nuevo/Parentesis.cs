using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hulk__Nuevo
{
    internal class Parentesis
    {
        public static void Start(List<string> tokens, int posicion)
        {
            int count = 0;
            for(int i = posicion; i < tokens.Count; i++) 
            {
                if (tokens[i] == "(")
                {
                    count++;
                }
                if (tokens[i] == ")")
                {
                    count--;
                }
                if (tokens[i] == ")"&&count==0) 
                { 
                    List<string> temp= new List<string>();
                    for(int j=posicion+1; j<i; j++)
                    {
                        temp.Add(tokens[j]);
                    }
                    tokens.RemoveRange(posicion+1, i - posicion-1);
                    tokens.Insert(posicion+1, Parser.Start(temp));
                }
            }
        }
    }
}
