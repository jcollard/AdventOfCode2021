public abstract class AbstractSeaCucumber : ISeaCucumber
{
    protected readonly SeaFloor _seaFloor;
    public (int Row, int Col) Position { get; set; }
    public (int Row, int Col) NextPosition => this.CanMove ? TargetPosition : Position;
    public bool CanMove => !this._seaFloor.IsOccupied(TargetPosition.Row, TargetPosition.Col);
    private (int Row, int Col) TargetPosition => ((this.Position.Row + this.Speed.Row) % this._seaFloor.Rows, (this.Position.Col + this.Speed.Col) % this._seaFloor.Cols);
    public abstract (int Row, int Col) Speed { get; }
    public abstract char ToChar { get; }
    public AbstractSeaCucumber(SeaFloor seaFloor, int row, int col)
    {
        this._seaFloor = seaFloor;
        this.Position = (row, col);
    }
}