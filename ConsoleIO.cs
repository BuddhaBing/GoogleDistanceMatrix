using System;
using System.Collections.Generic;

public class ConsoleIo
{
    private List<String> messages = new List<String>();
    private List<String> userReponses = new List<String>();

    public List<string> Start()
    {
        messages.Add("Please enter the origin location");
        messages.Add("Please enter the destination location");
        foreach(string message in messages)
        {
            Output(message);
            userReponses.Add(Input());
        }
        return userReponses;
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