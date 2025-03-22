public class GameService
{
    private readonly Grid _grid = new();

    public GameService()
    {
        var shipsToPlace = new Dictionary<ShipType, int>
        {
            {ShipType.Battleship, 1},
            {ShipType.Destroyer, 2}
        };
        RandomShipPlacement.PlaceShips(_grid, shipsToPlace);
    }

    public (HitResult, Ship?) Shoot(string input)
    {
        var position = ParseInput(input);
        return _grid.Shoot(position);
    }

    public bool IsGameOver() => _grid.Ships.All(ship => ship.IsSunk);

    private Position ParseInput(string input)
    {
        int row = char.ToUpper(input[0]) - 'A';
        int col = int.Parse(input[1..]) - 1;

        return new Position(row, col);
    }
}
