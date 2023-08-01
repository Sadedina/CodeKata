/*
*                                  CodeKata Number 14
*                                  Pulsonix Assessment
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

namespace CodeKata.Asos
{
    public class CodeKata14
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
            var lights = new Time[]
            {
                new Time()
                {
                    Hours = 18,
                    Minutes = 00
                },
                new Time()
                {
                    Hours = 00,
                    Minutes = 00
                }
            };

            do
            {
                Console.Clear();

                Console.WriteLine("\n==========================   Welcome to your Smart Home controller   ==========================\n\n" +
                "Please choose one of the following options by typing it in the console and pressing Enter\n" +
                " 1. Clock\n" +
                " 2. Organiser\n" +
                " 3. Lights\n" +
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
                        lights = LightsMode(lights); //TODO
                        break;
                    case "reset":
                        ResetMode(out clock, out organiser, out lights);
                        break;
                    case "exit":
                        ExitMode();
                        break;
                    default:
                        Console.WriteLine("Your input was not recognised. Please try again");
                        Thread.Sleep(1000);
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
                Console.WriteLine("\nPress any key to exit");

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo cki = Console.ReadKey();
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

            if (Regex.Replace(timeInString, @"[0-9]", "") != "")
            {
                Console.WriteLine("\nInputted Timer is not valid\nPlease, retry again");
                return null;
            }

            var time = int.Parse(timeInString);
            Thread.Sleep(250);
            Console.WriteLine($"\nTimer for {time} starting now");

            for (int i = time; i >= 0; i--)
            {
                Console.Clear();
                ClockScript();
                Console.WriteLine("\n__________   Stop Watch   __________");
                Console.WriteLine($"\nTimer for {time} starting now");
                Console.WriteLine($"Timer: {i}");
                Thread.Sleep(1000);
            }

            Console.WriteLine($"\nTimer terminated!!!");

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
                Console.WriteLine($"{i}. {timers[i - 1]}");

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
            string option, optionCaseSensitive;

            do
            {
                Console.Clear();

                OrganiserScript();

                Console.Write("\nEnter your selection: ");
                optionCaseSensitive = Console.ReadLine().Trim();
                option = optionCaseSensitive.ToLower();

                if (option.StartsWith("storelist["))
                    organiser = Storelist(organiser, optionCaseSensitive);

                else if (option.Contains("returnlists"))
                    Returnlist(organiser);

                else if (option.Contains("deletelist_"))
                    organiser = Deletelist(organiser, option);

                else if (option == "e")
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
            OrganiserScript();
            Console.WriteLine("\n__________   Store List   __________");

            ConsoleKeyInfo exit;
            var time = DateTime.Now;
            var refactoredList = list.Remove(list.Length - 1, 1).Replace(" ", "").Remove(0, 10);
            var shoppingList = $"{time}," + refactoredList;
            storage[2] = shoppingList.Split(',');

            if (refactoredList == "")
            {
                Console.WriteLine("\nList is empty. This cannot be added to the database.\nPlease, try again.");

                Console.WriteLine("\nPress any key to exit");
                exit = Console.ReadKey();
                return storage;
            }


            if (storage[0] != null && storage[1] != null)
            {
                Console.WriteLine("\nTwo lists already exists in Storelist!");
                Console.WriteLine($"List 1 created at {storage[0][0]}");
                Console.WriteLine($"List 2 created at {storage[1][0]}");

                Console.WriteLine("\nPress any key to exit");
                exit = Console.ReadKey();
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
            exit = Console.ReadKey();

            return storage;
        }

        public static void Returnlist(List<string[]> storage)
        {
            OrganiserScript();
            Console.WriteLine("\n__________   Return List   __________");

            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("");

                if (storage[0] == null && storage[1] == null)
                {
                    Console.WriteLine("There's no List saved in the database");
                    break;
                }
                else if (storage[i] != null)
                {
                    Console.WriteLine($"List {i + 1}:" +
                        $"\nDate Created: {storage[i][0]}" +
                        "\nItems: ");

                    for (int j = 1; j < storage[i].Count(); j++)
                        Console.WriteLine(storage[i][j]);
                }
                else
                    Console.WriteLine($"List {i + 1} does not exist");
            };

            Console.WriteLine("\nPress any key to exit");
            var exit = Console.ReadKey();
        }

        public static List<string[]> Deletelist(List<string[]> storage, string listNumber)
        {
            OrganiserScript();
            Console.WriteLine("\n__________   Delete List   __________");

            ConsoleKeyInfo exit;
            var toDelete = listNumber.Replace("deletelist_", "");

            if (Regex.Replace(toDelete, @"[1-2]", "") != "")
            {
                Console.WriteLine($"\nThe following value [{toDelete}] is not valid\nPlease, retry again");
                Thread.Sleep(250);

                Console.WriteLine("\nPress any key to exit");
                exit = Console.ReadKey();
                return storage;
            }

            var pos = Convert.ToInt32(toDelete) - 1;

            if (storage[pos] == null)
            {
                Console.WriteLine($"\nThe List {toDelete} is empty. You can only delete a list with content");
                Thread.Sleep(250);

                Console.WriteLine("\nPress any key to exit");
                exit = Console.ReadKey();
                return storage;
            }

            Console.Write("\nProcessing");

            for (int i = 0; i < 5; i++)
            {
                Console.Write(".");
                Thread.Sleep(250);
            }

            var time = storage[pos][0];
            storage[pos] = null;

            Console.WriteLine($"\n\nThe List {toDelete} created at {time} has now been deleted");

            Thread.Sleep(250);

            Console.WriteLine("\nPress any key to exit");
            exit = Console.ReadKey();

            return storage;
        }
        #endregion

        #region Lights
        private static void LightsScript()
        {
            Console.Clear();

            Console.WriteLine("\n==========================   Welcome to your Smart Home controller   ==========================\n" +
                "\t\t\t     ********** Lights MODE ********** \n\n" +
                "All subsequent commands would be treated as commands for the lights");

            Console.WriteLine("--------------------------------------------------------------------------------------------------------------" +
                "\n Available commands\n" +
                "  * RETURN_AUTO_OFF: Returns the AUTO_OFF time to the user.\n" +
                "  * RETURN_AUTO_ON: Returns the AUTO_ON time to the user.\n" +
                "  * CHANGE_AUTO_OFF_<integer>:  Changes the AUTO_OFF value to the one specified by the user.\n" +
                "  * CHANGE_AUTO_ON_<integer>: Changes the AUTO_ON value to the one specified by the user.\n" +
                "  * LIGHT_STATUS: Returns the user ON if the lights are turned on and OFF if lights are off.\n" +
                "  * E: exit\n--------------------------------------------------------------------------------------------------------------");
        }

        public static Time[] LightsMode(Time[] lights)
        {
            string option, optionCaseSensitive;

            do
            {
                Console.Clear();
                LightsScript();
                ConsoleKeyInfo exit;

                Console.Write("\nEnter your selection: ");
                optionCaseSensitive = Console.ReadLine().Trim();
                option = optionCaseSensitive.ToLower();

                if (option.StartsWith("return_auto_off"))
                    LightAutoStatus(lights, 1);

                else if (option.StartsWith("return_auto_on"))
                    LightAutoStatus(lights, 0);

                else if (option.StartsWith("change_auto_off_"))
                {
                    var temp = Time(option.Remove(0, 16));

                    if (temp != null)
                    {
                        lights[1] = temp;
                        Console.WriteLine($"\nAuto Off has been changes to {lights[1].ToString()}");
                    }

                    Console.WriteLine("\nPress any key to exit");
                    exit = Console.ReadKey();
                }
                else if (option.StartsWith("change_auto_on_"))
                {
                    var temp = Time(option.Remove(0, 15));

                    if (temp != null)
                    {
                        lights[0] = temp;
                        Console.WriteLine($"\nAuto On has been changes to {lights[0].ToString()}");
                    }

                    Console.WriteLine("\nPress any key to exit");
                    exit = Console.ReadKey();
                }
                else if (option.Contains("light_status"))
                    LightStatus(lights);

                else if (option == "e")
                    break;

                else
                {
                    Console.WriteLine("\nUnfortunately your input was not recognized. Please, type your input again.");
                    Thread.Sleep(3000);
                }

            } while (option.ToLower() != "e");

            return lights;
        }

        public static Time Time(string time)
        {
            if (Regex.Replace(time, @"[0-9]", "") != "" || time.Count() != 4 || int.Parse(time) > 2400)
            {
                Console.WriteLine("\nInputted Time is not valid\nPlease, retry again");
                return null;
            }

            Console.Clear();
            LightsScript();
            Console.WriteLine("\n__________   Light Change Settings   __________");

            if (int.Parse(time) == 2400)
                return new Time()
                {
                    Hours = 00,
                    Minutes = 00
                };

            return new Time()
            {
                Hours = int.Parse(time.Remove(2, 2)),
                Minutes = int.Parse(time.Remove(0, 2))
            };
        }

        public static void LightAutoStatus(Time[] lights, int status)
        {
            LightsScript();
            Console.WriteLine("\n__________   Light View Settings   __________");

            ConsoleKeyInfo exit;

            if (status == 0)
                Console.WriteLine($"\nAuto On: {lights[status].ToString()}");

            if (status == 1)
                Console.WriteLine($"\nAuto Off: {lights[status].ToString()}");

            Console.WriteLine("\nPress any key to exit");
            exit = Console.ReadKey();

        }

        public static void LightStatus(Time[] lights)
        {
            LightsScript();
            Console.WriteLine("\n__________   Light Status   __________");

            ConsoleKeyInfo exit;
            var ct = new Time()
            {
                Hours = DateTime.Now.Hour,
                Minutes = DateTime.Now.Minute
            };
            var time = TimeSpan.Parse(ct.ToString());
            var on = TimeSpan.Parse(lights[0].ToString());
            var off = TimeSpan.Parse(lights[1].ToString());

            // Auto on 18:00 and auto off 00:00
            if (new TimeSpan(0) <= off && off <= on)
                off = +new TimeSpan(24);

            if (on <= time && time <= off)
                Console.WriteLine("\nLights are currently ON!!");
            else
                Console.WriteLine("\nLights are currently OFF!!");

            Console.WriteLine("\nPress any key to exit");
            exit = Console.ReadKey();
        }
        #endregion

        #region Reset
        private static void ResetScript()
        {
            Console.Clear();

            Console.WriteLine("\n==========================   Welcome to your Smart Home controller   ==========================\n" +
                "\t\t\t\t********** Reset MODE ********** ");
        }

        public static void ResetMode(out List<int?> clock, out List<string[]> organiser, out Time[] lights)
        {
            ResetScript();

            clock = new List<int?>();
            organiser = new List<string[]>
            {
                null,
                null,
                null
            };
            lights = new Time[]
            {
                new Time()
                {
                    Hours = 18,
                    Minutes = 00
                },
                new Time()
                {
                    Hours = 00,
                    Minutes = 00
                }
            };

            Console.Write("\nResetting");

            for (int i = 0; i < 5; i++)
            {
                Console.Write(".");
                Thread.Sleep(250);
            }

            Console.WriteLine($"\n\nAll data has been reset to default values");
        }
        #endregion

        #region Exit
        public static void ExitMode()
        {
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------" +
            "\n\n--------------------------------------------------------------------------------------------------------------" +
                "\n\nThank you for using this application\n" +
                "Till next time\n" +
                "\nBYE!!\n\n");
        }
        #endregion
    }

    public class Time
    {
        public int Hours { get; set; }
        public int Minutes { get; set; }

        public override string ToString()
        {
            return string.Format(
                "{0:00}:{1:00}",
                Hours, Minutes);
        }
    }
}