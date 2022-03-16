using System;
using System.Collections.Generic;

namespace CodeKata
{
    class Program
    {
        static void Main(string[] args)
        {
            CodeKata_14.SmartHome();

            var time = new List<int?>()
            {
                5, 10, 13, 15, 15
            };

            var storage = new List<string[]>
            {
                //new string[] { DateTime.Now.ToString(), "Applex10", "Bananax24"},
                null,
                null
                //new string[] { DateTime.Now.ToString(), "Applex10", "Bananax24"}
                //new string[] { DateTime.Now.AddMinutes(10).ToString(), "Applex10", "Bananax24"}
            };

            //CodeKata_14.LastStopeWatches(time);
            //CodeKata_14.Storelist(storage, "STORELIST[Applex10, Bananax24]");
            //CodeKata_14.OrganiserMode(storage);
            
        }
    }
}