namespace AngbandOS.Core.ConsoleElements
{
    internal class ConsoleTableColumn
    {
        public string Name;
        public ConsoleAlignment Alignment { get; set; } = new ConsoleTopLeftAlignment();

        public ConsoleTableColumn(string name)
        {
            Name = name;
        }
    }
}
