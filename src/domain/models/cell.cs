namespace BattleshipGame.Domain.Models;

public class Cell
{
    public Position Position { get; }
    public Ship? Ship { get; set; }
    public bool IsHit { get; set; }

    public Cell(int row, int column)
    {
        Position = new Position(row, column);
    }
}
