/*
*                                  CodeKata Number 14
*                                  Pulsonix Assessment
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

namespace CodeKata
{
	public class CodeKata_14
	{
		public static void SmartHome()
        {
			var userInput = "";
			var clock = new List<int?>();
			var organiser = new List<string[]>
            {
				null,
				null,
				null
            };

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
						clock = ClockMode(clock);
						break;
					case "organiser":
						organiser = OrganiserMode(organiser);
						break;
					case "lights":
						break;
					case "reset":
						break;
					case "exit":
						break;
					default:
                        Console.WriteLine("Your input was not recognised. Please try again");
						break;
				}

			} while (userInput != "exit");
			
        }

        #region Clock
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

		public static List<int?> ClockMode(List<int?> timers)
        {
			var option = "";

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

			return timers;
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
		#endregion

		#region Organiser
		private static void OrganiserScript()
		{
			Console.Clear();

			Console.WriteLine("\n==========================   Welcome to your Smart Home controller   ==========================\n" +
				"\t\t\t     ********** Organiser MODE ********** \n\n" +
				"All subsequent commands would be treated as commands for the organiser");

			Console.WriteLine("--------------------------------------------------------------------------------------------------------------" +
				"\n Available commands\n" +
				"  * STORELIST[items]: This should create a new list that stores the specified items.\n" +
				"  * RETURNLISTS: This should return the stored lists to the user in the specified format. \n" +
				"  * DELETELIST_<list_num>: The command deletes the list specified but the list num.\n" +
				"  * E: exit\n--------------------------------------------------------------------------------------------------------------");
		}

		public static List<string[]> OrganiserMode(List<string[]> organiser)
		{
			
			var option = "";

			do
			{
				Console.Clear();

				OrganiserScript();

				Console.Write("\nEnter your selection: ");
				option = Console.ReadLine().Trim();

				if (option.ToLower().StartsWith("storelist["))
				{
					organiser = Storelist(organiser, option);
				}
				else if (option.ToLower().Contains("returnlists"))
				{
					// TODO
				}
				else if (option.ToLower().Contains("deletelist_"))
				{
					// TODO
				}
				else if (option.ToLower() == "e")
					break;

				else
				{
					Console.WriteLine("\nUnfortunately your input was not recognized. Please, type your input again.");
					Thread.Sleep(3000);
				}

			} while (option.ToLower() != "e");

			return organiser;
		}

		public static List<string[]> Storelist(List<string[]> storage, string list)
		{
			ClockScript();
			Console.WriteLine("\n__________   Store List   __________");

			var time = DateTime.Now;
			var shoppingList = $"{time}," + list.Remove(list.Length - 1, 1).Replace(" ", "").Remove(0, 10);
			storage[2] = shoppingList.Split(',');

			if (storage[0] != null && storage[1] != null)
            {
				Console.WriteLine("\nTwo lists already exists in Storelist!");
                Console.WriteLine($"List 1 created at {storage[0][0]}");
                Console.WriteLine($"List 2 created at {storage[1][0]}");
				return storage;
			}

			if (storage[0] == null)
            {
				var num = 1;

				if (storage[1] == null)
					num = 2;

				for (int i = 0; i < num; i++)
                {
					storage.RemoveAt(0);
					storage.Add(null);
				}
			}
				
			if (storage[0] != null && storage[1] == null)
			{
				storage.RemoveAt(1);
				storage.Add(null);
			}

			Console.Write("\nProcessing");

			for (int i = 0; i < 5; i++)
            {
                Console.Write(".");
				Thread.Sleep(250);
			}
			
			Console.WriteLine($"\n\nStorelist has been created at {time}");

			Console.WriteLine("\nPress any key to exit");
			var exit = Console.ReadKey();

			return storage;
		}

		public static void Returnlist(List<string[]> storage)
		{
			ClockScript();
			Console.WriteLine("\n__________   Return List   __________");

			if (storage[0] != null)
			{
				Console.WriteLine("\nList 1:" +
					$"\nDate Created: {storage[0][0]}" +
					"\nItems: ");
                for (int i = 1; i <= storage[0].Count(); i++)
                    Console.WriteLine(storage[0][0]);
			}
			else if (storage[1] != null)
			{
				Console.WriteLine("\nList 2:" +
					$"\nDate Created: {storage[1][0]}" +
					"\nItems: ");
				for (int i = 1; i <= storage[1].Count(); i++)
					Console.WriteLine(storage[1][0]);
			}

			if (storage[0] == null)
			{
				var num = 1;

				if (storage[1] == null)
					num = 2;

				for (int i = 0; i < num; i++)
				{
					storage.RemoveAt(0);
					storage.Add(null);
				}
			}

			if (storage[0] != null && storage[1] == null)
			{
				storage.RemoveAt(1);
				storage.Add(null);
			}

			Console.Write("\nProcessing");

			for (int i = 0; i < 5; i++)
			{
				Console.Write(".");
				Thread.Sleep(250);
			}

			Console.WriteLine($"\n\nStorelist has been created at {storage}");

			Console.WriteLine("\nPress any key to exit");
			var exit = Console.ReadKey();

		}
		#endregion

	}
}