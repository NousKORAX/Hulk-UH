using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Hulk__Nuevo
{
    internal class Adicionales
    {

        public static void StartLog(List<string> Token, int pos)
        {
            int count = 0;
            List<string> args1 = new List<string>();
            List<string> args2 = new List<string>();
            for (int i = pos; i < Token.Count; i++)
            {
                if (Token[i] != "(") { count++; }
                if (Token[i] != ")") { count--; }
                if (count == 0 && Token[i] == ")")
                {
                    for (int j = pos + 2; j < i; j++)
                    {

                        if (Token[j] == ",")
                        {
                            for (int k = j + 1; k < i; k++)
                            {
                                args2.Add(Token[k]);
                            }
                            break;
                        }
                        args1.Add(Token[j]);
                    }

                    Token.RemoveRange(pos, i - pos + 1);
                    Token.Insert(pos, log(Parser.Start(args2), Parser.Start(args1)));
                }
            }
        }

        public static string log(string arg1, string arg2)
        {
            List<string> result = new List<string>();

            try
            {
                double arg1_double = Convert.ToDouble(arg1);
                double arg2_double = Convert.ToDouble(arg2);

                if (arg1_double <= 0 || arg2_double <= 0)
                {
                    throw new ArgumentException("The arguments must be greater than 0");
                }

                double log_result = Math.Log(arg1_double, arg2_double);
                result.Add(log_result.ToString());

            }
            catch (FormatException e)
            {
                throw new ArgumentException("The arguments must be a valid number", e);
            }
            catch (OverflowException e)
            {
                throw new ArgumentException("The arguments must be within the range of a double", e);
            }
            catch (ArgumentException e)
            {
                throw new ArgumentException("Invalid arguments", e);
            }

            return result[0].ToString();
        }
        public static void StartSINCOS(List<string> Token, int pos)
        {
            int count = 0;
            List<string> result = new List<string>();
            for (int i = 0; i < Token.Count; i++)
            {
                if (Token[i] == "(") { count++; }
                if (Token[i] == ")") {  count--; }
                if (count == 0 && Token[i] == ")") 
                { 
                   for (int j = pos+2;j<i;j++)
                   {
                        result.Add(Token[j]);
                   }
                   Token.RemoveRange(pos, i-pos+1);
                    if (Token[pos] == "SIN") { Token.Insert(pos, Math.Sin(Convert.ToDouble(Parser.Start(result))).ToString()); }
                    else
                    {
                        Token.Insert(pos, Math.Cos(Convert.ToDouble(Parser.Start(result))).ToString());
                    }
                }
            }
        }
    }
}


