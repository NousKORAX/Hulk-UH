using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Hulk__Nuevo
{
    internal class Parser
    {
        //Diccionario donde se guardan las variables y el valor que se le hace corresponder
        internal static Dictionary<string, string> Variables = new Dictionary<string, string>();

        //Diccionario donde se guarda el nombre de una funcion y los parametros que debe recibir
        internal static Dictionary<string, List<string>> Nombre_Parametros=new Dictionary<string, List<string>>();

        //Diccionario donde se guarda el nombre de una funcion y el cuerpo de esta
        internal static Dictionary<string, List<string>> Nombre_Cuerpo=new Dictionary<string, List<string>>();


        //En este metodo se reciba una lista de Strings que no son mal que los tokens del input.
        internal static string Start(List<string> Tokens)
        {
            
           
            bool ignorar = false;
            //Se comprueba si exista alguna variable declarada y se sustituye su valor en caso de que se este utilizando.
            if (Variables.Count != 0)
            {
                for(int i = 0; i < Tokens.Count; i++)
                {
                    Tokens[i] = SustituirVariable.Sustitucion(Tokens[i], Variables);
                }
            }
            
            //En este string se iran acumulando los tokens para generar expresiones
            string value = "";

            //Se comienzan a recorrer los tokens para poder parsear el input
            for (int i = 0; i < Tokens.Count; i++)
            {
                if (Tokens[i].Contains("SYNTAX"))
                {
                    return Tokens[i];
                }
                if (Tokens[i] == "\"") { ignorar = !ignorar; }
                //Se comprueba si el token coincide con la palabra recervada "let"

                if (EsFuncion(Tokens[i]))
                {
                    //Se envia al metodo para parsear una funcion la lista de tokens y la posicion donde aparecio el nombre de la funcion
                    ParserMetodos.UsarFunction(Tokens, i);

                    //Se reinician el valor y el ciclo
                    i = -1; value = ""; continue;
                }
                if (Tokens[i] == "(") { Parentesis.Start(Tokens, i); }
                //Se comprueba si el token coincide con la palabra recervada "function"
                if (Tokens[i] == "function") 
                {  
                    //Se envia la declaracion de funcion al metodo correspondiente
                    ParserMetodos.Function(Tokens, i); 

                    //Finaliza el proceso recursivo
                    return ""; 
                }
                if (Tokens[i] == "let")
                {
                    //Se envia al metodo para parsear el let-in la lista de tokens y la posicion donde aparecio el "let"
                    ParserMetodos.Letin(Tokens, i);

                    //Se reinician el valor y el ciclo
                    value = ""; i = -1; continue;
                }

                //Se comprueba si el token coincide con la palabra recervada "if"
                if (Tokens[i] == "if") 
                {
                    //Se envia al metodo para parsear el if-else la lista de tokens y la posicion donde aparecio el "if"
                    ParserMetodos.If(Tokens, i);
                    
                    //Se reinician el valor y el ciclo
                    value = ""; i = -1; continue;
                }

                //Se comprueba si el token coincide con la palabra recervada "print"
                if (Tokens[i] == "print") 
                {
                    //Se envia al metodo para parsear el print la lista de tokens y la posicion donde aparecio el "print"
                    ParserMetodos.Print(Tokens, i); 

                    //Se reinician el valor y el ciclo
                    i = -1;value = ""; continue; 
                }

                //Se comprueba si el token coincide con la estructura de una comparacion
                if (Tokens[i] =="=="|| Tokens[i] == "<=" || Tokens[i] == ">=" || Tokens[i] == "!=" || Tokens[i] == ">" || Tokens[i] == "<")
                {
                    //Se envia al metodo para parsear la comparacion la lista de tokens y la posicion donde aparecio el comparador
                    ParserMetodos.Comparar(Tokens, i);

                    //Se reinician el valor y el ciclo
                    value = ""; i = -1; continue;
                }

                //Se comprueba si el token corresponde conuna
              
                if (Tokens[i] == ",") 
                { 
                    ParserMetodos.Coma(Tokens, i); 
                }
                
                
                if (Tokens[i] == "@") { ParserMetodos.ConcatenarString(Tokens, i); value = ""; i = -1; continue; }
                value += Tokens[i];
                if(i == Tokens.Count - 1)
                {
                    
                        // Expresión regular para reconocer la línea de código
                        string patron = @"^([^\d]\w*)\s*=\s*(.*)";
                        // Crear un objeto Regex con el patrón
                        Regex var = new Regex(patron);
                        Match Matchvar = var.Match(value);
                    if (Matchvar.Success) 
                    { 
                        Variables.Add(Matchvar.Groups[1].Value.Trim(), Lexer.Start(Matchvar.Groups[2].Value.Trim())); continue; }

                        
                    
                    // Expresión regular para reconocer la línea de código
                    string patron1 = @"[+\-*%/^]";
                    // Crear un objeto Regex con el patrón
                    Regex Aritmetica = new Regex(patron1);
                    Match MatchAritmetica = Aritmetica.Match(value);
                    if (MatchAritmetica.Success) 
                    { return Calculo.Evaluar(value); }

                    // Expresión regular para reconocer la línea de código
                    string patron2 = @"\s*""(.*)""\s*";
                    // Crear un objeto Regex con el patrón
                    Regex stringpatron = new Regex(patron2);
                    Match Matchstringpatron = stringpatron.Match(value);
                    if (Matchstringpatron.Success)
                    {
                        while (Tokens.Contains("\""))
                        {
                            Tokens.Remove("\"");
                        }
                        value = string.Join(" " , Tokens);
                        
                        return value.Trim(); 
                    }

                    double n;
                    if (double.TryParse(value, out n))

                    {

                        return value;
                    }
                    if (bool.TryParse(value, out bool result)) {  return value; }






                }

            }
            //value = "";
            //int Distancia_Minima = 3;
            //foreach (string reservada in Palabras_Reservadas.Palabras)
            //{
            //    if (ErrorLevens.Start(reservada, Tokens[0]) < Distancia_Minima)

            //    {
            //        Distancia_Minima = ErrorLevens.Start(reservada, Tokens[0]);
            //        value = reservada;
            //    }
            //}

            return value;
            
        
        }
        internal static string Search(string Objetivo, List<string> Tokens)
        {
            throw new NotImplementedException();
        }
        internal static bool EsFuncion(string Token)
        {
            for (int i = 0;i<Nombre_Cuerpo.Count;i++)
            {
                if (Nombre_Cuerpo.ContainsKey(Token)) {  return true; }
            }
            return false;
        }
    }
}
