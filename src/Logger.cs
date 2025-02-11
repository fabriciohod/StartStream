namespace StartStream
{
    public class Logger
    {
        private readonly string _logDirectory;
        private readonly LogLevel _logLevel;

        public enum LogLevel { Debug, Info, Warning, Error, Critical }

        public Logger(string logDirectory, LogLevel logLevel = LogLevel.Info)
        {
            _logDirectory = logDirectory;
            _logLevel = logLevel;
        }

        void Log(string message, LogLevel level = LogLevel.Info)
        {
            if (level < _logLevel)
                return;
            
            string logMessage = $"{DateTime.Now:MM-dd HH:mm} [{level}] {message}";
            Console.WriteLine(logMessage);
            WriteToFile(logMessage);
        }

        void WriteToFile(string message)
        {
            try
            {
                if (!Directory.Exists(_logDirectory))
                    Directory.CreateDirectory(_logDirectory);

                string logFileName = $"log-{DateTime.Now:yyyy-MM-dd}.log";
                string logFilePath = Path.Combine(_logDirectory, logFileName);

                File.AppendAllText(logFilePath, message + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to log file: {ex.Message}");
            }
        }

        public void Debug(string message) => Log(message, LogLevel.Debug);
        public void Info(string message) => Log(message, LogLevel.Info);
        public void Warning(string message) => Log(message, LogLevel.Warning);
        public void Error(string message) => Log(message, LogLevel.Error);
        public void Critical(string message) => Log(message, LogLevel.Critical);
    }
}