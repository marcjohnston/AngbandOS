// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.ConsoleElements;

/// <summary>
/// The first row is zero-based.
/// </summary>
/// <typeparam name="T"></typeparam>
internal class ConsoleTableWithRowHighlighting<T> : ConsoleTable
{
    private ColorEnum HighlightRowColor { get; }
    private ColorEnum DefaultRowColor { get; }
    private int? CurrentHighLitRow = null;
    private T[] RowSource { get; }
    private void HighlightRow(int rowIndex, ColorEnum color)
    {
        foreach (ConsoleTableColumn column in Columns)
        {
            ConsoleString consoleString = (ConsoleString)Rows[rowIndex][column.Name]!; // Row and column must exist.
            consoleString.SetColor(color);
        }
    }

    public T? CurrentRow => CurrentHighLitRow is null ? default : RowSource[CurrentHighLitRow.Value];

    /// <summary>
    /// Highlight a row or remove the row highlighting.  Specify null, to remove the row highlighting.
    /// </summary>
    /// <param name="rowIndex"></param>
    public void HighlightRow(int? rowIndex)
    {
        if (CurrentHighLitRow is not null)
        {
            HighlightRow(CurrentHighLitRow.Value, DefaultRowColor);
        }
        CurrentHighLitRow = rowIndex;
        if (CurrentHighLitRow is not null)
        {
            HighlightRow(CurrentHighLitRow.Value, HighlightRowColor);
        }
    }

    public ConsoleTableWithRowHighlighting(T[] rowSource,  params (string Name, Func<T, string> GetRowValue)[] columns) : this(rowSource, ColorEnum.White, ColorEnum.BrightRed, columns) { }

    public ConsoleTableWithRowHighlighting(T[] rowSource, ColorEnum defaultRowColor, ColorEnum highlightRowColor, params (string Name, Func<T, string> GetRowValue)[] columns)
    {
        DefaultRowColor = defaultRowColor;
        HighlightRowColor = highlightRowColor;
        RowSource = rowSource;

        foreach ((string Name, Func<T, string> GetRowValue) in columns)
        {
            AddColumn(Name);
        }
        foreach (T row in rowSource)
        {
            ConsoleTableRow tableRow = AddRow();
            foreach ((string Name, Func<T, string> GetRowValue) column in columns)
            {
                tableRow[column.Name] = new ConsoleString(DefaultRowColor, column.GetRowValue(row));
            }
        }
    }
}