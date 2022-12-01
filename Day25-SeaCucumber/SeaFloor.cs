using System.Text;

public class SeaFloor
{
    private Dictionary<(int Row, int Col), ISeaCucumber> _cucumbers = new();

    public int Rows { get; init; }
    public int Cols { get; init; }
    public int Steps { get; private set; } = 0;

    public SeaFloor(string[] initialState)
    {
        (int row, int col) pos = (0, 0);
        foreach (string s in initialState)
        {
            pos.col = 0;
            foreach (char ch in s)
            {

                ISeaCucumber? cucumber = ISeaCucumber.Make(ch, this, pos.row, pos.col);
                if (cucumber != null)
                {
                    _cucumbers[(pos.row, pos.col)] = cucumber;
                }
                pos.col++;
            }
            pos.row++;
        }
        this.Rows = pos.row;
        this.Cols = pos.col;
    }

    public bool Step()
    {
        bool changed = false;
        changed |= processCumbers(MoveableEastCucumbers);
        changed |= processCumbers(MoveableSouthCucumbers);
        Steps += changed ? 1 : 0;
        return changed;
    }

    private IEnumerable<ISeaCucumber> MoveableEastCucumbers => this._cucumbers.Values.Where(cucumber => cucumber.ToChar == '>' && cucumber.CanMove).ToList();
    private IEnumerable<ISeaCucumber> MoveableSouthCucumbers => this._cucumbers.Values.Where(cucumber => cucumber.ToChar == 'v' && cucumber.CanMove).ToList();

    private bool processCumbers(IEnumerable<ISeaCucumber> toProcess)
    {
        bool changed = false;
        foreach (ISeaCucumber sc in toProcess)
        {
            this._cucumbers.Remove(sc.Position);
            sc.Position = sc.NextPosition;
            this._cucumbers[sc.Position] = sc;
            changed = true;
        }
        return changed;
    }

    public bool IsOccupied(int row, int col) => _cucumbers.ContainsKey((row, col));

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();
        for (int row = 0; row < this.Rows; row++)
        {
            for (int col = 0; col < this.Cols; col++)
            {
                if (this._cucumbers.TryGetValue((row, col), out ISeaCucumber? value) && value != null)
                {
                    builder.Append(value.ToChar);
                }
                else
                {
                    builder.Append('.');
                }
            }
            builder.Append('\n');
        }
        return builder.ToString().Trim();
    }
}