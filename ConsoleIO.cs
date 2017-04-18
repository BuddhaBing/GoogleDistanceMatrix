using System;
using System.Collections.Generic;

public class ConsoleIo
{
    private List<String> messages = new List<String>();
    private List<String> userReponses = new List<String>();

    public ConsoleIo()
    {
        AddMessages();
        foreach(string message in messages)
        {
            Output($"Please enter the {message}");
            userReponses.Add(Input());
        }
    }

    private void AddMessages()
    {
        messages.Add("origin location");
        messages.Add("destination location");
        // UNCOMMENT THE LINE BELOW TO ADD TRAVEL MODE INPUT PROMPT
        // messages.Add("travel mode (driving; walking; bicycling; transit)");
    }

    public List<string> UserReponses
    {
        get
        {
            return userReponses;
        }
    }

    public void Output(String message)
    {
        Console.WriteLine(message);
    }

    private string Input()
    {
        return Console.ReadLine();
    }

}