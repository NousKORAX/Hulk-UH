using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Hulk__Nuevo
{
    internal class IfParser
    {
        internal static void Start(List<string> Token, int posicion)
        {
            int count = 0;
            for (int i = posicion + 1; i < Token.Count; i++)
            {
                if (Token[i] == "(") { count++; }
                if (Token[i] == ")") {  count--; }
                if (count == 0)
                {
                    List<string>Valores=new List<string>();
                    for(int j=posicion+2; j < i; j++) 
                    {
                        Valores.Add(Token[j]);
                    }
                    bool EvaluacionIf = Convert.ToBoolean(ComprobarComparador.Start(Valores).Trim());
                    if (EvaluacionIf)
                    {
                        count = 1;
                        Valores.Clear();
                        for(int j=i+1; j < Token.Count; j++)
                        {
                            if (Token[j] == "if") { count++; }
                            if (Token[j] == "else") { count--; }
                            if(count == 0)
                            {
                                Token.RemoveRange(posicion, Token.Count-posicion);
                                Token.Insert(posicion,Parser.Start(Valores).Trim());
                                break;
                            }
                            Valores.Add(Token[j]);

                        }
                        break;
                    }
                    else
                    {
                        count = 1;
                        Valores.Clear();
                        for (int j = i + 1; j < Token.Count; j++)
                        {
                            if (Token[j] == "if") { count++; }
                            if (Token[j] == "else") { count--; }
                            if (count == 0)
                            {
                                for(int k=j+1;k< Token.Count; k++)
                                {
                                    Valores.Add(Token[k]);
                                }
                                Token.RemoveRange(posicion, Token.Count - posicion);
                                Token.Insert(posicion, Parser.Start(Valores).Trim());
                                
                                break;
                            }
                            

                        }
                        break;
                    }
                }
            }
            Token.Clear();
            Token.Add("! SYNTAX ERROR: Missing closing parenthesis");
        }
        
    }
}
