using System.Diagnostics;

namespace StartStream
{
    public static class ProgramsHandler
    {
        public static string ConfigPath { get; set; } = "Programs.yaml";

        static readonly List<Process?> RunningProcesses = new();
        static readonly Logger Logger = new("logs");
        public static void OpenPrograms()
        {
            List<ProgramItem> programs = ConfigReader.LoadProgramsFromYaml(ConfigPath);

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

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Started: {program.Name}");

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"Press any key to go back to the menu.");
                    Console.ReadKey();

                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Failed to start {program.Name}: {ex.Message}");

                    Logger.Error($"Failed to start {program.Name}: {ex.Message}");
                }
                finally
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            Console.WriteLine("All programs processed.");
        }

        public static void ClosePrograms()
        {
            foreach (Process? process in RunningProcesses)
            {
                if (process == null)
                    continue;

                KillProcess(process);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("All programs processed.");
        }

        static void KillProcess(Process process)
        {
            try
            {
                if (process == null)
                    throw new Exception("Cannot kill a null process.");

                if (process.CloseMainWindow())
                    process.WaitForExit(100);

                if (!process.HasExited)
                    process.Kill();


                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Closed process: {process.ProcessName}");

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Press any key to go back to the menu.");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Failed to close {process.ProcessName}: {ex.Message}");

                Logger.Error($"Failed to close {process.ProcessName}: {ex.Message}");
            }
            finally
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}