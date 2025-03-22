using BattleshipGame.Domain.Enums;
using BattleshipGame.Domain.Models;

namespace BattleshipGame.Tests;

public class GridTests
{
    [Fact]
    public void AddShip_Succeeds_WithoutOverlap()
    {
        var grid = new Grid();
        var ship = new Ship(ShipType.Battleship, new List<Position>
        {
            new(0, 0), new(0, 1), new(0, 2), new(0, 3), new(0, 4)
        });

        Assert.True(grid.AddShip(ship));
    }

    [Fact]
    public void Shoot_Registers_Hit()
    {
        var grid = new Grid();
        var ship = new Ship(ShipType.Destroyer, new List<Position>
        {
            new(1, 1), new(1, 2), new(1, 3), new(1, 4)
        });
        grid.AddShip(ship);

        var (hit, _, _) = grid.Shoot(new Position(1, 1));

        Assert.True(hit);
    }

    [Fact]
    public void Shoot_Registers_Miss()
    {
        var grid = new Grid();
        var (hit, _, _) = grid.Shoot(new Position(0, 0));
        Assert.False(hit);
    }
}
