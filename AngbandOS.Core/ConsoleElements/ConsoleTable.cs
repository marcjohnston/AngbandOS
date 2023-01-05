using System.Collections;

namespace AngbandOS.Core.ConsoleElements
{
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

        public override int Width
        {
            get
            {
                int totalWidth = 0;
                foreach (ConsoleTableColumn column in columns.Values)
                {
                    totalWidth += ColumnWidth(column.Name);
                }
                totalWidth += columns.Count > 0 ? columns.Count - 1 : 0; // Add a single space between each column.
                return totalWidth;
            }
        }

        public ConsoleAlignment? Alignment { get; set; } = null;

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

        public override void Print(SaveGame saveGame, ConsoleWindow containerWindow, ConsoleAlignment parentAlignment)
        {
            containerWindow.Clear(saveGame);
            ConsoleAlignment alignment = Alignment ?? parentAlignment;
            ConsoleLocation rowLocation = alignment.ComputeTopLeftLocation(this, containerWindow);
            Dictionary<ConsoleTableColumn, int> columnWidths = new Dictionary<ConsoleTableColumn, int>();

            foreach (ConsoleTableRow row in rows)
            {
                ConsoleLocation columnLocation = rowLocation.Clone();
                foreach (ConsoleTableColumn column in columns.Values)
                {
                    if (!columnWidths.TryGetValue(column, out int columnWidth))
                    {
                        columnWidth = ColumnWidth(column.Name);
                        columnWidths.Add(column, columnWidth);
                    }
                    ConsoleElement? element = row[column.Name];
                    if (element != null)
                    {
                        element.Print(saveGame, columnLocation.ToWindow(columnWidth, 1), column.Alignment);
                    }
                    columnLocation = columnLocation.Offset(columnWidth + 1, 0);
                }

                // Move the location to the next row.
                rowLocation = rowLocation.Offset(0, 1);
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
}
