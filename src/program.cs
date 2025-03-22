var game = new GameService();
Console.WriteLine("Welcome to Battleships!");

while (!game.IsGameOver())
{
    Console.Write("Enter target (e.g., A5): ");
    string input = Console.ReadLine() ?? "";

    try
    {
        var (result, ship) = game.Shoot(input);
        Console.WriteLine(result switch
        {
            HitResult.Miss => "Miss!",
            HitResult.Hit => "Hit!",
            HitResult.Sunk => $"You sunk a {ship?.Type}!",
            _ => "Error"
        });
    }
    catch
    {
        Console.WriteLine("Invalid input. Try again.");
    }
}

Console.WriteLine("Congratulations, all ships sunk!");
