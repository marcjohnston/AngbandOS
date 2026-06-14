using AngbandOS.Core;
using AngbandOS.Core.Interface.Configuration;

public class Program
{
    static void Main(string[] args)
    {
        GameServer gameServer = new();
        ConsoleAndViewport consoleAndViewPort = new ConsoleAndViewport();
      //  Console.SetWindowSize(consoleAndViewPort.Width, consoleAndViewPort.Height);
        GameConfiguration gameConfiguration = new AngbandOS.GamePacks.Cthangband.CthangbandGameConfiguration();

        Thread gameThread = new Thread(() =>
        {
            gameServer.PlayNewGame(consoleAndViewPort, null, null, gameConfiguration);
        });

        gameThread.IsBackground = true;
        gameThread.Start();

        // Main thread handles console I/O
        while (gameThread.IsAlive)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                switch (consoleKeyInfo.Key)
                {
                    case ConsoleKey.Tab:
                        consoleAndViewPort.KeyQueue.Enqueue('\x09');
                        break;

                    case ConsoleKey.Enter:
                        consoleAndViewPort.KeyQueue.Enqueue('\x0D');
                        break;

                    case ConsoleKey.PageUp:
                        if (consoleKeyInfo.Modifiers == ConsoleModifiers.Shift)
                        {
                            consoleAndViewPort.KeyQueue.Enqueue('.');
                        }
                        consoleAndViewPort.KeyQueue.Enqueue('9');
                        break;

                    case ConsoleKey.PageDown:
                        if (consoleKeyInfo.Modifiers == ConsoleModifiers.Shift)
                        {
                            consoleAndViewPort.KeyQueue.Enqueue('.');
                        }
                        consoleAndViewPort.KeyQueue.Enqueue('3');
                        break;

                    case ConsoleKey.End:
                        if (consoleKeyInfo.Modifiers == ConsoleModifiers.Shift)
                        {
                            consoleAndViewPort.KeyQueue.Enqueue('.');
                        }
                        consoleAndViewPort.KeyQueue.Enqueue('1');
                        break;

                    case ConsoleKey.Home:
                        if (consoleKeyInfo.Modifiers == ConsoleModifiers.Shift)
                        {
                            consoleAndViewPort.KeyQueue.Enqueue('.');
                        }
                        consoleAndViewPort.KeyQueue.Enqueue('7');
                        break;

                    case ConsoleKey.LeftArrow:
                        if (consoleKeyInfo.Modifiers == ConsoleModifiers.Shift)
                        {
                            consoleAndViewPort.KeyQueue.Enqueue('.');
                        }
                        consoleAndViewPort.KeyQueue.Enqueue('4');
                        break;

                    case ConsoleKey.UpArrow:
                        if (consoleKeyInfo.Modifiers == ConsoleModifiers.Shift)
                        {
                            consoleAndViewPort.KeyQueue.Enqueue('.');
                        }
                        consoleAndViewPort.KeyQueue.Enqueue('8');
                        break;

                    case ConsoleKey.RightArrow:
                        if (consoleKeyInfo.Modifiers == ConsoleModifiers.Shift)
                        {
                            consoleAndViewPort.KeyQueue.Enqueue('.');
                        }
                        consoleAndViewPort.KeyQueue.Enqueue('6');
                        break;

                    case ConsoleKey.DownArrow:
                        if (consoleKeyInfo.Modifiers == ConsoleModifiers.Shift)
                        {
                            consoleAndViewPort.KeyQueue.Enqueue('.');
                        }
                        consoleAndViewPort.KeyQueue.Enqueue('2');
                        break;

                    case ConsoleKey.Clear:
                        consoleAndViewPort.KeyQueue.Enqueue('5');
                        break;
                    default:
                        consoleAndViewPort.KeyQueue.Enqueue(consoleKeyInfo.KeyChar);
                        break;
                }
            }

            Thread.Sleep(5);
        }
    }
}