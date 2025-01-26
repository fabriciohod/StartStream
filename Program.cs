using StartStream;

while (true)
{
    Console.Clear();
    Console.WriteLine("===============================");
    Console.WriteLine("         Program Manager       ");
    Console.WriteLine("===============================");
    Console.WriteLine("[1] Open programs for live");
    Console.WriteLine("[2] Close programs for live");
    Console.WriteLine("[3] Exit");
    Console.Write("Enter your choice: ");

    string input = Console.ReadLine();

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
