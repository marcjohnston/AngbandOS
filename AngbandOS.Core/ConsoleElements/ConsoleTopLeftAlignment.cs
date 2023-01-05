namespace AngbandOS.Core.ConsoleElements
{
    internal class ConsoleTopLeftAlignment : ConsoleAlignment
    {
        public override ConsoleLocation ComputeTopLeftLocation(ConsoleElement consoleElement, ConsoleWindow parentWindow)
        {
            return parentWindow.TopLeft;
        }
    }
}
