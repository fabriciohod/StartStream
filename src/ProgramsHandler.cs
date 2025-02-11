using System.Diagnostics;

namespace StartStream
{
    public static class ProgramsHandler
    {
        static readonly List<Process?> RunningProcesses = new();
        static readonly Logger Logger = new Logger("logs");

        public static string ConfigPath = "Programs.yaml";
        public static void OpenPrograms()
        {
            List<ProgramItem> programs = ConfigReader.LoadProgramsFromYaml(ConfigPath);

            if (programs.Count == 0)
            {
                Console.WriteLine("No programs found in Programs.json.");
                Logger.Error("No programs found in Programs.json.");
                Console.ReadKey();
                return;
            }

            foreach (ProgramItem program in programs)
            {
                try
                {
                    ProcessStartInfo startInfo = new()
                    {
                        FileName = program.Path,
                        WorkingDirectory = Path.GetDirectoryName(program.Path) ?? "",
                        UseShellExecute = true,
                        Arguments = program.LaunchOptions,
                        Verb = program.RunAsAdmin ? "runas" : "",
                    };

                    Process? process = Process.Start(startInfo);
                    RunningProcesses.Add(process);

                    Console.WriteLine($"Started: {program.Name}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to start {program.Name}: {ex.Message}");
                    Logger.Error($"Failed to start {program.Name}: {ex.Message}");
                }
            }

            Console.WriteLine("All programs processed.");
            Console.ReadKey();
        }

        public static void ClosePrograms()
        {
            if (RunningProcesses.Count == 0)
            {
                Console.WriteLine("No programs found in Programs.json.");
                Logger.Error("No programs found in Programs.json.");
                Console.ReadKey();
                return;
            }

            foreach (Process? process in RunningProcesses)
            {
                try
                {
                    Console.WriteLine("Closing " + process?.ProcessName);
                    if (process?.ProcessName != null) 
                        KillProcess(process.ProcessName);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to close {process?.ProcessName}: {ex.Message}");
                    Logger.Error($"Failed to close {process?.ProcessName}: {ex.Message}");
                }
            }

            Console.WriteLine("All programs processed.");
            Console.ReadKey();
        }

        public static void KillProcess(string processName)
        {
            Process[] processes = Process.GetProcessesByName(processName);

            try
            {

                if (processes.Length == 0)
                {
                    Console.WriteLine($"No running process found for: {processName}");
                    return;
                }

                foreach (Process process in processes)
                {
                    process.Kill();
                    process.WaitForExit();
                    Console.WriteLine($"Closed process: {processName}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to close {processName}: {ex.Message}");
                Logger.Error($"Failed to close {processName}: {ex.Message}");
            }
        }

    }
}
