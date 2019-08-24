using System;
using NLog;
using NLog.Config;
using NLog.Targets;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace MeteoTestSuite.Utilities
{
    public class MyLogger
    {
        private readonly ILogger _log;

        public MyLogger()
        {
            var config = new LoggingConfiguration();

            var fileTarget = new FileTarget();
            config.AddTarget("File", fileTarget);

            fileTarget.FileName = $"{AppDomain.CurrentDomain.BaseDirectory}/Result/Meteo.log";
            fileTarget.Layout = @"${date:format=yyyy.MM.dd HH\:mm\:ss} ${level:uppercase=true} ${logger}   ${message}";

            config.LoggingRules.Add(new LoggingRule("*", LogLevel.Info, fileTarget));

            LogManager.Configuration = config;
            _log = LogManager.GetLogger("Meteo");
        }

        public MyLogger TestStart(string browserName)
        {
            _log.Info("================ Started ================");
            _log.Info($"Test name: {TestContext.CurrentContext.Test.Name}");
            _log.Info($"Browser: {browserName}");

            return this;
        }

        public MyLogger TestEnd()
        {
            switch (TestContext.CurrentContext.Result.Outcome.Status)
            {
                case TestStatus.Passed:
                    _log.Info("Test outcome: " + TestContext.CurrentContext.Result.Outcome.Status.ToString().ToUpper());
                    break;
                case TestStatus.Failed:
                    _log.Error("Test outcome: " +
                               TestContext.CurrentContext.Result.Outcome.Status.ToString().ToUpper());
                    _log.Error("Test message:");
                    _log.Error(TestContext.CurrentContext.Result.Message);
                    break;
                default:
                    _log.Warn("Test outcome: " + TestContext.CurrentContext.Result.Outcome.Status.ToString().ToUpper());
                    _log.Warn("Test message: " + TestContext.CurrentContext.Result.Message);
                    break;
            }

            _log.Info("================ Finished ================");

            return this;
        }
    }
}