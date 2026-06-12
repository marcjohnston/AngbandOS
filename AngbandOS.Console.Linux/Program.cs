using AngbandOS.Core;
using AngbandOS.Core.Interface;
using AngbandOS.Core.Interface.Configuration;
using System.Collections.Concurrent;
using System.Drawing;

internal class ConsoleAndViewport : IConsoleAndViewPort
{
    public readonly ConcurrentQueue<char> KeyBuffer = new();

    public int Height => 45;

    public int Width => 80;

    public void BatchPrint(PrintLine[] printLines)
    {
        foreach (PrintLine printLine in printLines)
            Print(printLine.row, printLine.col, printLine.text, printLine.foreColor, printLine.backColor);
    }

    private Color FromHex(string hex)
    {
        string colorcode = hex;
        int argb = Int32.Parse(colorcode.Replace("#", ""), System.Globalization.NumberStyles.HexNumber);
        byte a = (byte)((argb & -16777216) >> 0x18);
        a = 255;
        byte r = (byte)((argb & 0xff0000) >> 0x10);
        byte g = (byte)((argb & 0xff00) >> 8);
        byte b = (byte)(argb & 0xff);
        Color value = Color.FromArgb(a, r, g, b);
        return value;
    }

    private void Print(int row, int col, string text, ColorEnum foreColor, ColorEnum backColor)
    {
        Console.SetCursorPosition(col, row);
        Console.Write(text);
    }

    public void CharacterRenamed(string name)
    {
    }

    public void Clear()
    {
        Console.Clear();
    }

    public void ExperienceLevelChanged(int level)
    {
    }

    public void GameExceptionThrown(string message)
    {
    }

    public void GameStarted()
    {
    }

    public void GameStopped()
    {
    }

    public void GameTimeElapsed()
    {
    }

    public char? GetKey()
    {
        if (KeyBuffer.TryDequeue(out var key))
        {
            return key;
        }
        return null;
    }

    public void GoldUpdated(int gold)
    {
    }

    public void InputReceived()
    {
    }

    public void MessagesReceived(IGameMessage[] gameMessages)
    {
    }

    public void MessagesUpdated()
    {
    }

    public void PlayerDied(string name, string diedFrom, int level)
    {
    }

    public void PlayMusic(MusicTrackEnum music)
    {
    }

    public void PlaySound(SoundEffectEnum sound)
    {
    }

    public void SetBackground(BackgroundImageEnum image)
    {
    }
}

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
                char c = '\0';
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                switch (consoleKeyInfo.Key)
                {
                    case ConsoleKey.LeftArrow:
                        c = '4';
                        break;
                    case ConsoleKey.RightArrow:
                        c = '6';
                        break;
                    case ConsoleKey.UpArrow:
                        c = '8';
                        break;
                    case ConsoleKey.DownArrow:
                        c = '2';
                        break;
                    default:
                        c = consoleKeyInfo.KeyChar;
                        break;
                }
                consoleAndViewPort.KeyBuffer.Enqueue(c);
            }

            Thread.Sleep(5);
        }
    }
}