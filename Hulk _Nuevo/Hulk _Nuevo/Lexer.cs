using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Hulk__Nuevo;


namespace Hulk__Nuevo
{
    internal class Lexer
    {
        
        internal static string Start(string input)
        {
            List<string> Tokens = new List<string>();
        string token = "";
            for (int i = 0; i < input.Length; i++)
            {
               
                if (Cambio(input[i]))
                {
                    if (token != "") { Tokens.Add(token); token = ""; }
                    if (!EsEspacio(input[i]))Tokens.Add(input[i].ToString());
                    continue;
                }
                

                token += input[i];
                if (EsFinal(input.Length-1, i)) { Tokens.Add(token); }
                
                
            }
            bool Cambio(char caracter) 
            { 
                switch(caracter)
                {
                    case '(': return true;
                    case ')': return true;
                    case ',': return true;
                    case '.': return true;
                    case '-': return true;
                    case '+': return true;
                    case '*': return true;
                    case ':': return true;
                    case '?': return true;
                    case '!': return true;
                    case '=': return true;
                    case '<': return true;
                    case '>': return true;
                    case ' ': return true;
                    case '"': return true;
                    
                }
                return false;
            }

            bool EsFinal(int posicion, int length)
            {
                return posicion == length;
            }
            bool EsEspacio(char caracter)
            {
                if(caracter==' ')return true;
                return false;
            }
            bool EsComparador(string caracter1, string caracter2, string caracter3)
            {
                
                    if (caracter2=="=")
                    {
                        switch(caracter1 ) 
                        {
                        case "<": return true;
                            case">": return true;
                        case "=": return true;
                        }
                    }
                    switch (caracter2)
                    {
                        case "<": return true;
                        case ">": return true;
                        
                    }


                return false;
                
            }
            for(int i = 1; i < Tokens.Count-1; i++)
            {

                if (EsComparador(Tokens[i - 1], Tokens[i], Tokens[i + 1]))
                {
                    if (Tokens[i] == "=")
                    { 
                        string cambio = Tokens[i - 1].ToString() + Tokens[i];
                        Tokens.RemoveRange(i - 1, 2);
                        Tokens.Insert(i - 1, cambio);
                    }
                   
                   
                }
            }
            return Parser.Start(Tokens);

            
        }
    }
}
    
