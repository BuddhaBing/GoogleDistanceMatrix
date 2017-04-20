# Google Distance Matrix API Tech Test

## Technologies
* [.NET Core v1.1](https://www.microsoft.com/net/core)
* [C#](https://msdn.microsoft.com/en-gb/library/67ef8sbd.aspx)

## The Brief

The Google distance matrix API is a simple example of a web-based API endpoint that we can pass data to and retrieve results from. The main function of the API, and the purpose of it for this test, is to provide the distance and duration between two points.

Information on the API can be found here:
https://developers.google.com/maps/documentation/distance-matrix/start

The goal of this exercise is to build a client that interacts with this API. It should be able to send different parameters to the API, and display both the distance and the duration from the API in a friendly manner. 

The client only needs to support the distance and duration between two points, but may need other parameters such as mode for which more information can be found here:

https://developers.google.com/maps/documentation/distance-matrix/intro#travel_modes 

This is not intended to be a fully-featured solution, but more a proof of concept that could be extended if necessary.

## My Approach and Challenges

The biggest challenge for me in this test was to try to understand the brief correctly, and I battled with whether to make the app into a browser based web app, or a simple console app. The specification stated that the app is not intended to be a "fully-featured solution, but more a proof of concept that could be extended if necessary", so I eventually settled on a simple console app, in the hope of avoiding over-engineering. If I were to do the test again, I think I would start by asking a clarifying question before starting.

The other challenge was that I have only been exposed to C# in one other project, which was a Unity3D video game, so it was quite different from this test, and I had never used .NET before. Initially I thought that the fact that my preferred development environment is a Mac could pose an issue with .NET, but with .NET Core, Microsoft have made development much easier on macOS and Linux machines.

Testing was also fairly difficult, as it is a simple app that calls an API and interprets the data, and a lot of the methods are private and therefore untestable. I considered making some of them public, but this would mean breaking encapsulation for the sake of testing, which didn't sit well with me. In the end I just tested the public methods, working on the assumption that if the public methods work, and they call a private method, then the private method must also work.

I wanted to keep everything as modular as possible, so that it could be extended at a later date if necessary. The most important part of this was the output, as I had chosen to make this into a console app. I isolated the console/terminal input and output into a separate class, so that if the input and output method was required to be changed, it would be simple to do.

## <a name="install">Installation</a>

Please ensure that [.Net Core](https://www.microsoft.com/net/core) is installed on your operating system of choice.

```
$ git clone https://github.com/treborb/GoogleDistanceMatrix.git
$ cd GoogleDistanceMatrix
$ dotnet restore
```

## <a name="usage">Usage</a>

```
$ dotnet run
```
You will then be given a prompt to enter an origin location and a destination location.

Enter this information in order to be presented with the distance and duration of the journey.

If you would like to add a travel mode, open the file "ConsoleIO.cs" and uncomment line 24. This will enable the prompt for travel modes.

## <a name="tests">Running the tests</a>
```
$ dotnet xunit
```



