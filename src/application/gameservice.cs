// public class GameService
// {
//     private readonly Grid _grid = new();

//     public GameService()
//     {
//         var shipsToPlace = new Dictionary<ShipType, int>
//         {
//             {ShipType.Battleship, 1},
//             {ShipType.Destroyer, 2}
//         };
//         RandomShipPlacement.PlaceShips(_grid, shipsToPlace);
//     }

//     public (HitResult, Ship?) Shoot(string input)
//     {
//         var position = ParseInput(input);
//         return _grid.Shoot(position);
//     }

//     public bool IsGameOver() => _grid.Ships.All(ship => ship.IsSunk);

//     private Position ParseInput(string input)
//     {
//         int row = char.ToUpper(input[0]) - 'A';
//         int col = int.Parse(input[1..]) - 1;

//         return new Position(row, col);
//     }
// }
using BattleshipGame.Domain.Models;
using BattleshipGame.Infrastructure;

namespace BattleshipGame.Application;

public class GameService
{
    private readonly Grid _grid = new();

    public GameService() => RandomShipPlacement.PlaceShips(_grid);

    public (bool hit, Ship? ship, bool sunk) Shoot(string input)
    {
        var position = Parse(input);
        return _grid.Shoot(position);
    }

    public bool IsGameOver() => _grid.Ships.All(ship => ship.IsSunk);

    private Position Parse(string input)
    {
        if (input.Length < 2) throw new ArgumentException("Invalid input format.");

        int row = char.ToUpper(input[0]) - 'A';
        if (!int.TryParse(input[1..], out int col))
            throw new ArgumentException("Invalid column number.");

        return new Position(row, col - 1);
    }
}
