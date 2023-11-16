using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        Console.WriteLine("Inserisci percorso File:");

        string? file = Console.ReadLine();

        try
        {
            var variabileConta = ContaParole(file);

            Console.WriteLine("Frequenza parole all'interno del file:\n");

            foreach(var elemento in variabileConta)
            {
                Console.WriteLine($"{elemento.Key} {elemento.Value}");
            }

        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Errore : File non trovaro. Inserisci un percorso valido."); 
        }
    }

    static Dictionary<string?,int> ContaParole(string? file)
    {
        var variabileConta = new Dictionary<string,int>(StringComparer.OrdinalIgnoreCase);

        foreach (var elemento in File.ReadAllText(file).Split(' ', '\n', '\r', '\t', '.', ',', ';', ':', '!', '?'))
        {
            if (!string.IsNullOrWhiteSpace(elemento))
            {
                string? parolaSenzaSpazi = elemento.Trim();

                if(variabileConta.TryGetValue(parolaSenzaSpazi, out int conta)){

                    variabileConta[parolaSenzaSpazi] = conta ++;
                }
                else
                {
                    variabileConta[parolaSenzaSpazi] = 1;
                }
            }
        }
        return variabileConta;
    }

    
}