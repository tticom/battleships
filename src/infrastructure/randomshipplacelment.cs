public static class RandomShipPlacement
{
    private static readonly Random Random = new();

    public static void PlaceShips(Grid grid, Dictionary<ShipType, int> shipsToPlace)
    {
        foreach (var (type, count) in shipsToPlace)
        {
            for (int i = 0; i < count; i++)
            {
                bool placed = false;
                while (!placed)
                {
                    var orientation = (Orientation)Random.Next(2);
                    int row = Random.Next(Grid.Size);
                    int col = Random.Next(Grid.Size);

                    var positions = GeneratePositions(new Position(row, col), type, orientation);
                    var ship = new Ship(type, positions);

                    placed = grid.AddShip(ship);
                }
            }
        }
    }

    private static List<Position> GeneratePositions(Position start, ShipType type, Orientation orientation)
    {
        var positions = new List<Position>();
        for (int i = 0; i < (int)type; i++)
        {
            positions.Add(orientation == Orientation.Horizontal
                ? new Position(start.Row, start.Column + i)
                : new Position(start.Row + i, start.Column));
        }
        return positions;
    }
}
