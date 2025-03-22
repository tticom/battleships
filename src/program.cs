using BattleshipGame.Application;

var game = new GameService();

Console.WriteLine("🎯 Battleships Game Started!");

while (!game.IsGameOver())
{
    Console.Write("Target (e.g., A5): ");
    string? input = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(input))
        continue;

    try
    {
        var (hit, ship, sunk) = game.Shoot(input);
        if (!hit) Console.WriteLine("💦 Miss!");
        else if (sunk) Console.WriteLine($"🔥 Sunk {ship!.Type}!");
        else Console.WriteLine("💥 Hit!");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

Console.WriteLine("🎉 All ships sunk! You won!");
