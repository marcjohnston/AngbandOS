﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.ConsoleElements;

internal class ConsoleTable : ConsoleElement
{
    private readonly Dictionary<string, ConsoleTableColumn> columns = new Dictionary<string, ConsoleTableColumn>();
    private readonly List<ConsoleTableRow> rows = new List<ConsoleTableRow>();

    public ConsoleTableColumn Column(string columnName)
    {
        return columns[columnName];
    }

    public ConsoleTableColumn[] Columns
    {
        get
        {
            return columns.Values.ToArray();
        }
    }

    public ConsoleTableRow[] Rows
    {
        get
        {
            return rows.ToArray();
        }
    }

    public override int Width
    {
        get
        {
            int totalWidth = 0;
            int visibleColumns = 0;
            foreach (ConsoleTableColumn column in columns.Values)
            {
                if (column.IsVisible)
                {
                    totalWidth += ColumnWidth(column.Name);
                    visibleColumns++;
                }
            }
            totalWidth += visibleColumns > 0 ? visibleColumns - 1 : 0; // Add a single space between each column.
            return totalWidth;
        }
    }

    private int ColumnWidth(string columnName)
    {
        int maxWidth = 0;
        foreach (ConsoleTableRow consoleRow in rows)
        {
            ConsoleElement? consoleElement = consoleRow[columnName];
            int width = consoleElement == null ? 0 : consoleElement.Width;
            if (width > maxWidth)
            {
                maxWidth = width;
            }
        }
        return maxWidth;
    }
    public override int Height
    {
        get
        {
            return rows.Count;
        }
    }

    public ConsoleTableRow AddRow()
    {
        ConsoleTableRow row = new ConsoleTableRow(this);
        rows.Add(row);
        return row;
    }

    public int TopRow = 0;

    public override void Render(Game game, ConsoleWindow containerWindow, ConsoleAlignment parentAlignment)
    {
        ConsoleAlignment alignment = Alignment ?? parentAlignment;
        ConsoleLocation rowLocation = alignment.ComputeTopLeftLocation(this, containerWindow);
        rowLocation.ToWindow(Width, Height).Clear(game, ColorEnum.Background);
        Dictionary<ConsoleTableColumn, int> columnWidths = new Dictionary<ConsoleTableColumn, int>();

        int rowIndex = TopRow;
        if (rowIndex < 0)
        {
            rowIndex = 0;
        }

        for (int windowRowIndex = 0; windowRowIndex <= containerWindow.Height; windowRowIndex++)
        {
            if (rowIndex >= rows.Count)
            {
                break;
            }

            ConsoleTableRow row = rows[rowIndex];
            ConsoleLocation columnLocation = rowLocation.Clone();
            foreach (ConsoleTableColumn column in columns.Values)
            {
                if (column.IsVisible)
                {
                    if (!columnWidths.TryGetValue(column, out int columnWidth))
                    {
                        columnWidth = ColumnWidth(column.Name);
                        columnWidths.Add(column, columnWidth);
                    }
                    ConsoleElement? element = row[column.Name];
                    if (element != null)
                    {
                        element.Render(game, columnLocation.ToWindow(columnWidth, 1), column.Alignment);
                    }
                    columnLocation = columnLocation.Offset(columnWidth + 1, 0);
                }
            }

            // Move the location to the next row.
            rowLocation = rowLocation.Offset(0, 1);
            rowIndex++;
        }
    }

    public ConsoleTable(params string[] columnNames)
    {
        foreach (string columnName in columnNames)
        {
            columns.Add(columnName, new ConsoleTableColumn(columnName));
        }
    }
}
