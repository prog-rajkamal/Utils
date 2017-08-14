using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;

namespace AppLogger
{
    

    public class LogTest
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger
     (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
        static LogTest()
        {
            //XmlConfigurator.Configure();
        }
        static void Main(string[] args)
        {
          //  BasicConfigurator.Configure();
            Console.WriteLine("Shit is happening");
            logger.Debug("Here is a debug log.");
            logger.Info("... and an Info log.");
            logger.Warn("... and a warning.");
            logger.Error("... and an error.");
            logger.Fatal("... and a fatal error.");
            log4net.Config.Log4NetConfigurationSectionHandler ac;

            //log4net.Appender.
            //log4net.Config.Log4NetConfigurationSectionHandler,log4net
        }
    }


}
