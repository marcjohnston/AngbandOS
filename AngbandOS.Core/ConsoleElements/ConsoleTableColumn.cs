namespace AngbandOS.Core.ConsoleElements
{
    internal class ConsoleTableColumn
    {
        public string Name;
        public bool IsVisible = true;
        public ConsoleAlignment Alignment { get; set; } = new ConsoleTopLeftAlignment();

        public ConsoleTableColumn(string name)
        {
            Name = name;
        }
    }
}
