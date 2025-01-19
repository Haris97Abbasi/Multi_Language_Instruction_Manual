﻿using InstructionManualLibrary.BusinessLogic;

public class App
{
    private readonly IMessages _messages;

    public App(IMessages messages)
    {
        _messages = messages;
    }

    public void Run(string[] args)
    {
        string lang = "en";

        //for (int i = 0; i < args.Length; i++)
        //{
        //    if (args[i].ToLower().StartsWith("lang="))
        //    {
        //        lang = args[i].Substring(5);
        //        break;
        //    }
        //}

        string message = _messages.Instructions(lang);

        Console.WriteLine(message);
    }
}
