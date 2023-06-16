namespace AngbandOS.Core.ConsoleElements;

internal abstract class ConsoleAlignment
{
    public abstract ConsoleLocation ComputeTopLeftLocation(ConsoleElement consoleElement, ConsoleWindow parentWindow);
}
