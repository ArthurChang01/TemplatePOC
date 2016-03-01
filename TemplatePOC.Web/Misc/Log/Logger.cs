using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TemplatePOC.Web.Misc.Log
{
    public class Logger
    {
        private readonly static Serilog.ILogger log = new LoggerConfiguration().WriteTo.NLog().MinimumLevel.Debug().CreateLogger();

        public static void Message_Debug(string msg)
        {
            log.Write(LogEventLevel.Debug, msg);
        }

        public static void Message_Info(string msg)
        {
            log.Write(LogEventLevel.Information, msg);
        }

        public static void Exception_Info(Exception ex, string msg = "")
        {
            log.Write(LogEventLevel.Information, ex, msg);
        }

        public static void Message_Error(string msg)
        {
            log.Write(LogEventLevel.Error, msg);
        }

        public static void Exception_Error(Exception ex, string msg = "")
        {
            log.Write(LogEventLevel.Error, ex, msg);
        }

        public static void Message_Fatal(string msg)
        {
            log.Write(LogEventLevel.Fatal, msg);
        }

        public static void Exception_Fatal(Exception ex, string msg = "")
        {
            log.Write(LogEventLevel.Fatal, ex, msg);
        }

    }
}