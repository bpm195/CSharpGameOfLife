using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace GameOfLife
{
    class ConfiguredSettings
    {
        public static List<int> BornConditions { get; private set; }
        public static List<int> StayAliveConditions { get; private set; }
        public static String InputFile { get; private set; }
        public static String DisplayDead { get; private set; }
        public static String DisplayAlive { get; private set; }

        public static void intitialize()
        {
            BornConditions = CommaSeperatedStringToListInt(ConfigurationManager.AppSettings["BornConditions"]);
            StayAliveConditions = CommaSeperatedStringToListInt(ConfigurationManager.AppSettings["StayAliveConditions"]);
            InputFile = ConfigurationManager.AppSettings["InputFile"];
            DisplayDead = ConfigurationManager.AppSettings["DisplayDead"];
            DisplayAlive = ConfigurationManager.AppSettings["DisplayAlive"];
            
        }

        public static List<int> CommaSeperatedStringToListInt(string values)
        {
            var separator = new char[]{','};
            var valueArray = values.Split(separator);
            var retList = new List<int>();

            foreach(string s in valueArray){
                retList.Add(Convert.ToInt32(s));
            }

            return retList;
        }
    }
}
