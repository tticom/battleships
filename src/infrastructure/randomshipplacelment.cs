// public static class RandomShipPlacement
// {
//     private static readonly Random Random = new();

//     public static void PlaceShips(Grid grid, Dictionary<ShipType, int> shipsToPlace)
//     {
//         foreach (var (type, count) in shipsToPlace)
//         {
//             for (int i = 0; i < count; i++)
//             {
//                 bool placed = false;
//                 while (!placed)
//                 {
//                     var orientation = (Orientation)Random.Next(2);
//                     int row = Random.Next(Grid.Size);
//                     int col = Random.Next(Grid.Size);

//                     var positions = GeneratePositions(new Position(row, col), type, orientation);
//                     var ship = new Ship(type, positions);

//                     placed = grid.AddShip(ship);
//                 }
//             }
//         }
//     }

//     private static List<Position> GeneratePositions(Position start, ShipType type, Orientation orientation)
//     {
//         var positions = new List<Position>();
//         for (int i = 0; i < (int)type; i++)
//         {
//             positions.Add(orientation == Orientation.Horizontal
//                 ? new Position(start.Row, start.Column + i)
//                 : new Position(start.Row + i, start.Column));
//         }
//         return positions;
//     }
// }
using BattleshipGame.Domain.Enums;
using BattleshipGame.Domain.Models;

namespace BattleshipGame.Infrastructure;

public static class RandomShipPlacement
{
    private static readonly Random _rand = new();

    public static void PlaceShips(Grid grid)
    {
        var shipsToPlace = new List<ShipType>
        {
            ShipType.Battleship,
            ShipType.Destroyer, ShipType.Destroyer
        };

        foreach (var type in shipsToPlace)
        {
            bool placed = false;
            while (!placed)
            {
                var orientation = _rand.Next(2) == 0;
                int row = _rand.Next(Grid.Size);
                int col = _rand.Next(Grid.Size);

                var positions = new List<Position>();

                for (int i = 0; i < (int)type; i++)
                {
                    positions.Add(orientation
                        ? new Position(row, col + i)
                        : new Position(row + i, col));
                }

                var ship = new Ship(type, positions);
                placed = grid.AddShip(ship);
            }
        }
    }
}
