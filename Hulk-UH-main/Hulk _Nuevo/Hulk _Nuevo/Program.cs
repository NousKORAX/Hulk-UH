using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hulk__Nuevo;
Parser.Variables.Add("PI", "3, 14");
while (true)
{
    
    Console.Write(">");
    string input = Console.ReadLine();
    if (input[input.Length - 1] == ';')
    {
        input = input.Remove(input.Length - 1, 1);
        Console.WriteLine(Lexer.Start(input.Trim()));
        Parser.Variables.Clear();
        
    }
    else
    {
        Console.WriteLine('>' + "Expresion no valida.");
    }
}
