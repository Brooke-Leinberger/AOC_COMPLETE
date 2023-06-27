using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace Year2015
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Day day = new Day9();
            day.Test();
            day.LoadInputs(read_inputs(day.getURL()));
            Console.WriteLine("Part 1: {0}\nPart 2: {1}", day.Part1(), day.Part2());
        }

        private static string read_inputs(string url)
        {
            //Shamelessly stolen from C# docs
            
            // Create a request for the URL. 		
            WebRequest request = WebRequest.Create (url);
            // If required by the server, set the credentials.
            request.Credentials = CredentialCache.DefaultCredentials;
            string session = File.ReadAllText("/home/brooke/RiderProjects/AOC/session.txt");
            request.Headers.Add("Cookie", $"session={session}");
            // Get the response.
            HttpWebResponse response = (HttpWebResponse)request.GetResponse ();
            // Display the status.
            Console.WriteLine (response.StatusDescription);
            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream ();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader (dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd ();
            // Display the content.
            // Cleanup the streams and the response.
            reader.Close ();
            dataStream.Close ();
            response.Close ();

            return responseFromServer;
        }
    }
}