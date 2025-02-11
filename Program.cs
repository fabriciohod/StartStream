using StartStream;

while (true)
{
    ParsingArgs(args);
    WriteOptions();
    string input = Console.ReadLine() ?? "";

    switch (input)
    {
        case "1":
            ProgramsHandler.OpenPrograms();
            break;
        case "2":
            ProgramsHandler.ClosePrograms();
            break;
        case "3":
            return;
        default:
            Console.WriteLine("Invalid choice. Press any key to try again.");
            Console.ReadKey();
            break;
    }
}

void ParsingArgs(string[] strings)
{
    if (strings.Length <= 0) 
        return;
    
    if (strings[0] == "--config" && strings.Length > 1)
        ProgramsHandler.ConfigPath = strings[1];
}

void WriteOptions()
{
    Console.Clear();
    Console.WriteLine("===============================");
    Console.WriteLine("         Program Manager       ");
    Console.WriteLine("===============================");
    Console.WriteLine("[1] Open programs for live");
    Console.WriteLine("[2] Close programs for live");
    Console.WriteLine("[3] Exit");
    Console.Write("Enter your choice: ");
}
