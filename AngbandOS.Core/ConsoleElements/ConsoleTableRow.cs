namespace AngbandOS.Core.ConsoleElements;

internal class ConsoleTableRow
{
    private ConsoleTable Table { get; }
    private Dictionary<string, ConsoleElement?> Data = new Dictionary<string, ConsoleElement?>();

    public ConsoleElement? this[string columnName]
    {
        get => Data[columnName];
        set => Data[columnName] = value;
    }

    public ConsoleTableRow(ConsoleTable table)
    {
        Table = table;

        foreach (ConsoleTableColumn column in Table.Columns)
        {
            Data.Add(column.Name, null);
        }
    }
}
