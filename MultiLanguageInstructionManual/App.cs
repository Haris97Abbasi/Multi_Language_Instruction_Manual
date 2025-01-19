using InstructionManualLibrary.BusinessLogic;
using System;

public class App
{
    private readonly IMessages _messages;

    public App(IMessages messages)
    {
        _messages = messages;
    }

    public void Run(string[] args)
    {
        Console.WriteLine("Available languages: en (English), de (German), fr (French), es (Spanish), it (Italian)");
        Console.WriteLine("Please enter the language code (e.g., 'en' for English):");

        string lang = Console.ReadLine().Trim();

        if (lang != "en" && lang != "de" && lang != "fr" && lang != "es" && lang != "it")
        {
            Console.WriteLine("Invalid language code. Defaulting to English.");
            lang = "en";
        }

        try
        {
            string message = _messages.Instructions(lang);
            Console.WriteLine(message);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}
