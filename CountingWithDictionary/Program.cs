using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {

        Console.WriteLine("Inserisci percorso File:\n"); // C:\Users\Administrator.DESKTOP-95RB6IG\Desktop\File.txt

        string? file = Console.ReadLine();

        try
        {

            var variabileConta = ContaParole(file);

            Console.WriteLine("Frequenza parole all'interno del file:\n");

            foreach(var elemento in variabileConta)
            {
                Console.WriteLine($"{elemento.Key} {elemento.Value}");
            }

        } catch (FileNotFoundException)
        {
            Console.WriteLine("File non trovato. Inserisci un percorso valido");
        }

    }

    static Dictionary<string?,int> ContaParole(string? file){


        var variabileConta = new Dictionary<string?,int> (StringComparer.OrdinalIgnoreCase);

        foreach(var parola in File.ReadAllText(file).Split(' ', '\n', '\r', '\t', '.', ',', ';', ':', '!', '?'))
        {
            if (!string.IsNullOrWhiteSpace(parola))
            {
                string? parolaSenzaSpazi = parola.Trim();

                variabileConta[parolaSenzaSpazi] = variabileConta.TryGetValue(parolaSenzaSpazi, out int conta) ? conta + 1  : 1;
            }
        }

        return variabileConta;

    }    
    

    
}