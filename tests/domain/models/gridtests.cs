public class GridTests
{
    [Fact]
    public void CanPlaceShipWithoutOverlap()
    {
        var grid = new Grid();
        var ship = new Ship(ShipType.Battleship, new List<Position>
        {
            new(0, 0), new(0, 1), new(0, 2), new(0, 3), new(0, 4)
        });

        bool result = grid.AddShip(ship);

        Assert.True(result);
    }
}
