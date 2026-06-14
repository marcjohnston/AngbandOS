using AngbandOS.Core.Interface;
using System.Collections.Concurrent;

internal class ConsoleAndViewport : IConsoleAndViewPort
{
    public readonly ConcurrentQueue<char> KeyQueue = new();

    public int Height => 45;

    public int Width => 80;

    ColorEnum? lastConsoleBackColor = null;
    ColorEnum? lastConsoleForeColor = null;

    public void BatchPrint(PrintLine[] printLines)
    {
        foreach (PrintLine printLine in printLines)
        {
            Console.SetCursorPosition(printLine.col, printLine.row);
            foreach (char c in printLine.text)
            {
                if (lastConsoleBackColor is null || lastConsoleBackColor.Value != printLine.foreColor)
                {
                    ConsoleColor consoleBackColor = FromColorEnum(printLine.backColor);
                    Console.BackgroundColor = consoleBackColor;
                    lastConsoleBackColor = printLine.backColor;
                }
                if (lastConsoleForeColor is null || lastConsoleForeColor.Value != printLine.foreColor)
                {
                    ConsoleColor consoleForeColor = FromColorEnum(printLine.foreColor);
                    Console.ForegroundColor = consoleForeColor;
                    lastConsoleForeColor = printLine.foreColor;
                }
                Console.Write(c);
            }
        }
    }

    private ConsoleColor FromColorEnum(ColorEnum color)
    {
        switch (color)
        {
            case ColorEnum.Background:
                return ConsoleColor.Black;

            case ColorEnum.Black:
                return ConsoleColor.Black;

            case ColorEnum.Grey:
            case ColorEnum.Silver:
                return ConsoleColor.DarkGray;

            case ColorEnum.BrightGrey:
                return ConsoleColor.Gray;

            case ColorEnum.Beige:
            case ColorEnum.BrightBeige:
                return ConsoleColor.DarkYellow;

            case ColorEnum.White:
            case ColorEnum.BrightWhite:
                return ConsoleColor.White;

            case ColorEnum.Red:
                return ConsoleColor.DarkRed;

            case ColorEnum.BrightRed:
                return ConsoleColor.Red;

            case ColorEnum.Copper:
            case ColorEnum.Orange:
                return ConsoleColor.DarkYellow;

            case ColorEnum.BrightOrange:
                return ConsoleColor.Yellow;

            case ColorEnum.Brown:
            case ColorEnum.BrightBrown:
                return ConsoleColor.DarkYellow;

            case ColorEnum.Gold:
            case ColorEnum.Yellow:
                return ConsoleColor.Yellow;

            case ColorEnum.BrightYellow:
                return ConsoleColor.Yellow;

            case ColorEnum.Chartreuse:
            case ColorEnum.BrightChartreuse:
                return ConsoleColor.Green;

            case ColorEnum.Green:
                return ConsoleColor.DarkGreen;

            case ColorEnum.BrightGreen:
                return ConsoleColor.Green;

            case ColorEnum.Turquoise:
            case ColorEnum.BrightTurquoise:
                return ConsoleColor.Cyan;

            case ColorEnum.Blue:
                return ConsoleColor.DarkBlue;

            case ColorEnum.BrightBlue:
                return ConsoleColor.Blue;

            case ColorEnum.Diamond:
                return ConsoleColor.White;

            case ColorEnum.Purple:
                return ConsoleColor.DarkMagenta;

            case ColorEnum.BrightPurple:
                return ConsoleColor.Magenta;

            case ColorEnum.Pink:
            case ColorEnum.BrightPink:
                return ConsoleColor.Magenta;

            default:
                return ConsoleColor.Gray;
        }
    }

    void Print(int row, int col, string text, ColorEnum foreColor, ColorEnum backColor)
    {
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
        if (KeyQueue.TryDequeue(out var key))
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
