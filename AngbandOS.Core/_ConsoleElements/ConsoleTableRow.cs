// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

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
