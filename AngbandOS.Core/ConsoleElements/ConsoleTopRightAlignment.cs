namespace AngbandOS.Core.ConsoleElements;

internal class ConsoleTopRightAlignment : ConsoleAlignment
{
    public override ConsoleLocation ComputeTopLeftLocation(ConsoleElement consoleElement, ConsoleWindow parentWindow)
    {
        return parentWindow.TopRight.Offset(-consoleElement.Width + 1, 0);
    }
}
