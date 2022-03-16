﻿/*
*                                  CodeKata Number 14
*                                  Pulsonix Assessment
*/

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;

namespace CodeKata
{
	public class CodeKata_14
	{
		public static void SmartHome()
        {
			var userInput = "";

			do
            {
				Console.Clear();

				Console.WriteLine("\n==========================   Welcome to your Smart Home controller   ==========================\n\n" +
				"Please choose one of the following options by typing it in the console and pressing Enter\n" +
				" 1. Clock\n" +
				" 2. Organiser\n" +
				" 3. Lighting\n" +
				" 4. Reset\n" +
				" 5. Exit\n");

				Console.Write("Enter your selection: ");
				userInput = Console.ReadLine().Trim().ToLower();

				switch (userInput)
				{
					case "clock":
						ClockMode();
						break;
					case "organiser":
						ClockMode();
						break;
					case "lights":
						ClockMode();
						break;
					case "reset":
						ClockMode();
						break;
					case "exit":
						break;
					default:
                        Console.WriteLine("Your input was not recognised. Please try again");
						break;
				}

			} while (userInput != "exit");
			
        }

		private static void ClockScript()
        {
			Console.Clear();

			Console.WriteLine("\n==========================   Welcome to your Smart Home controller   ==========================\n" +
				"\t\t\t\t********** CLOCK MODE ********** \n\n" +
				"All subsequent commands would be treated as commands for the clock");

			Console.WriteLine("--------------------------------------------------------------------------------------------------------------" +
				"\n Available commands\n" +
				"  * CURRENTDT: Returns the current date time to the user.\n" +
				"  * STOPW_<int>: Starts a stopwatch for the time specified but the integer. \n" +
				"  * LASTSTOPWTIMERS: Returns the last 10(if available) stopwatch timers as a comma separated list.\n" +
				"  * E: exit\n--------------------------------------------------------------------------------------------------------------");
		}

		public static void ClockMode()
        {
			var option = "";
			var timers = new List<int?>();

			do
            {
				Console.Clear();

				ClockScript();

				Console.Write("\nEnter your selection: ");
				option = Console.ReadLine().Trim().ToLower();

				if (option == "currentdt")
					CurrentTime();

				else if (option.Contains("stopw_"))
                {
					timers.Add(StopWatch(option));

                    if (timers.Contains(null))
						timers.RemoveAll(null);

					while (timers.Count > 10)
						timers.RemoveAt(0);
				}

				else if (option == "laststopwtimers")
					LastStopeWatches(timers);

				else if (option == "e")
					break;

				else
                {
					Console.WriteLine("\nUnfortunately your input was not recognized. Please, type your input again.");
					Thread.Sleep(3000);
				}
					
			} while (option != "e");
		}

		public static void CurrentTime()
		{
			var exit = true;

            do
            {
				ClockScript();
                Console.WriteLine("\n__________   Date and Time   __________");
				Console.WriteLine($"\nCurrent Date and Time is:\n{DateTime.Now}");
				Console.WriteLine("\nPress e exit");

				if (Console.KeyAvailable)
				{
					ConsoleKeyInfo cki = Console.ReadKey();
					if (cki.Key.ToString().ToLower() == "e")
						exit = false;
				}
				Thread.Sleep(850);
			} while (exit);
		}

		public static int? StopWatch(string timer)
		{
			ClockScript();
			Console.WriteLine("\n__________   Stop Watch   __________");
			var timeInString = timer.Replace("stopw_", "");

			if(Regex.Replace(timeInString, @"[0-9]", "") != "")
            {
				Console.WriteLine("\nInputted Timer is not valid\nPlease, retry again");
				return null;
			}

			var time = Int32.Parse(timeInString);
			Console.WriteLine($"\nTimer for {time} starting now");
			Console.Write($"Countdown");

			for (int i = time; i > 0; i--)
			{
				Thread.Sleep(1000);
				Console.Write(".");
			}

			Console.WriteLine($"\n\nTimer terminated!!!");

			Console.WriteLine("\nPress any key to exit");
			var exit = Console.ReadKey();
			return time;
		}

		public static void LastStopeWatches(List<int?> timers)
        {
			ClockScript();
			Console.WriteLine("\n__________   Stop Watch List   __________");

			Console.WriteLine("\nLatest Ten StopWatch Times:");

            for (int i = 1; i <= timers.Count; i++)
                Console.WriteLine($"{i}. {timers[i-1]}");

            Console.WriteLine("\nPress any key to exit");
			var exit = Console.ReadKey();
		}
	}
}