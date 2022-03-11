/*
    SMART HOME
    Design the workings of a smart home controller that can serve a clock, an organiser and a lighting controller. 
    The smart home controller listens to the following commands from the command line interface. 
    Please note that the user commands are not case sensitive. 
    •	CLOCK: Enables the clock functionality of the controller. Notifies the user that the clock is currently active and all subsequent commands would be treated as commands for the clock. 

    •	ORGANISER: Enables the list organiser functionality of the controller. Notifies the user that the organiser is currently active and all subsequent commands would be treated as commands for the organiser.

    •	LIGHTS: Enables the lighting controls of the controller. Notifies the user that the lighting controller is currently active and all subsequent commands would be treated as commands for the lighting controller.

    •	RESET: Resets all functionality of the controller. This will include but not exclusive to resetting Clock’s stopwatch timer list, Users lists in the organiser and resetting the Lights auto on and auto off to their default values. 


    CLOCK : 
    The Clock is capable of displaying the system date, time and running a Stopwatch. It accepts the following commands: 
    •	CURRENTDT: Returns the current date time to the user. 

    •	STOPW_<int>: Starts a stopwatch for the time specified but the integer. 
    e.g . STOPW_10 would start a stopwatch for 10 secs and notify the user when the stopwatch reaches 0.

    •	LASTSTOPWTIMERS: Returns the last 10(if available) stopwatch timers as a comma separated list. 


    ORGANISER:
    The Organiser is useful for maintaining lists of items, like to-do lists or shopping lists. The organiser has the capability of saving 2 lists with their created date times and displaying them back to the user when requested. It accepts the following commands: 
    •	STORELIST[items]: This should create a new list that stores the specified items. 
    E.g. STORELIST [Applex10, Bananax24] creates a list that stores Applex10 and Bananax24 as its elements. 
    The lists are treated as list 1 or 2 based on their creation date and time. 
    If the user calls STORELIST and 2 lists already exists, the user should be notified of that the contents of the lists should be returned back to the user in the format specified in RETURNLISTS. 

    •	RETURNLISTS: This should return the stored lists to the user in the specified format. 
    E.g. the list [Applex10, Bananax24, GrapeBoxesx5] should be returned as 
    List 1: 
    Date Created: **Creation Date Time**
    Items:  
    Applex10
    Bananax24
    GrapeBoxesx5

    •	DELETELIST_<list_num> : The command deletes the list specified but the list num. 
    E.g. DELETELIST_1 will delete list 1. List 2 will not become List 1 until a new list has been inserted.Therefore DELETELIST_2 after using DELETELIST_1 is a valid command.


    LIGHTS: 
    The light controller stores its own AUTO_OFF and AUTO_ON times for the lights in the house. The default AUTO_ON is 18:00 and default AUTO_OFF is 00:00.These parameters are user configurable. The light controller should also be able to return the ON or OFF status of the lights when queried by the user based on the AUTO_OFF, AUTO_ON and system date. It accepts the following commands : 
    •	RETURN_AUTO_OFF: Returns the AUTO_OFF time to the user. 
    •	RETURN_AUTO_ON:  Returns the AUTO_ON time to the user. 
    •	CHANGE_AUTO_OFF_<integer>:  Changes the AUTO_OFF value to the one specified by the user. 
    E.g. CHANGE_AUTO_OFF_2200 will change the AUTO_OFF value to 22:00
    •	CHANGE_AUTO_ON_<integer>: Changes the AUTO_ON value to the one specified by the user. 
    E.g. CHANGE_AUTO_ON_1500 will change the AUTO_ON value to 15:00.
    •	LIGHT_STATUS: Returns the user ON if the lights are turned on and OFF if lights are off. 
*/