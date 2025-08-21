// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal sealed class GameMessageWidget : Widget, IGetKey, IToJson
{
    public GameMessageWidget(Game game, GameMessageWidgetGameConfiguration gameMessageWidgetGameConfiguration) : base(game)
    {
        Key = gameMessageWidgetGameConfiguration.Key ?? gameMessageWidgetGameConfiguration.GetType().Name;
        Color = gameMessageWidgetGameConfiguration.Color;
        X = gameMessageWidgetGameConfiguration.X;
        Y = gameMessageWidgetGameConfiguration.Y;
        Width = gameMessageWidgetGameConfiguration.Width;
        MorePrompt = gameMessageWidgetGameConfiguration.MorePrompt;
    }

    public string Key { get; }

    public string GetKey => Key;

    public void Bind()
    {
        ChangeTrackers = new IChangeTracker[] { Game.SingletonRepository.Get<IChangeTracker>(nameof(GameMessageStringProperty)) };
    }

    /// <summary>
    /// Returns the color that the widget <see cref="Text"/> will be drawn.  Returns the color white by default.
    /// </summary>
    public ColorEnum Color { get; } = ColorEnum.White;

    /// <summary>
    /// Returns the x-coordinate on the <see cref="View"/> where the widget will be drawn.
    /// </summary>
    public int X { get; }

    /// <summary>
    /// Returns the y-coordinate on the <see cref="View"/> where the widget will be drawn.
    /// </summary>
    public int Y { get; }

    /// <summary>
    /// Returns the width of the widget.  A width that is equal to the length of the <see cref="Text"/> property is returned by default.
    /// </summary>
    public int? Width { get; } = null;

    public string MorePrompt { get; }

    /// <summary>
    /// Renders the -more- prompt and waits for a key input.  Keys in the input buffer are preserved.
    /// </summary>
    /// <param name="cursorXPosition"></param>
    private void ShowMorePrompt()
    {
        if (Game.GameMessage.StringValue.Length > 0)
        {
            Game.Screen.Print(ColorEnum.BrightBlue, MorePrompt, Y, X + Game.GameMessage.StringValue.Length + 1);
            while (!Game.Shutdown)
            {
                Game.Inkey(true);
                break;
            }
        }
        int width = Width ?? Game.Screen.Width;
        Game.Screen.Erase(Y, X, width);
        Game.GameMessage.StringValue = "";
    }

    private void Render(string message)
    {
        int width = Width ?? Game.Screen.Width;

        // Capitalize the first letter.
        if (message.Length > 2) // TODO: Configurable?
        {
            message = message.Substring(0, 1).ToUpper() + message.Substring(1);
        }
        if (!Game.IsDead) // TODO: Why
        {
            Game.MessageAdd(message);
        }

        // Check to see if the message being rendered is longer than one screen width.  If so, it will need to be split.  Compute the amount of space available.
        int lengthOfMore = MorePrompt.Length;
        int maxWidth = width - lengthOfMore - 1 - X;

        // Check to see if we need to -more- the current line.  Any form of the current message exceeding the current line will force a -more-.
        if (Game.GameMessage.StringValue.Length + message.Length + 1 > maxWidth)
        {
            // Close the current line to prepare for the current message.
            ShowMorePrompt();
        }

        // At this point, either the msg fits within the screen, or msg itself is longer than one screen width and the message line is blank.
        // Determine if the message is too long for a line by itself.
        while (message.Length > maxWidth)
        {
            // Find a place to break 
            int check = maxWidth;
            while (check > 0 && message[check] != ' ')
            {
                check--;
            }

            // Check to see if there were any spaces to break on.
            if (check == 0)
            {
                // There were none.  Force break on non-breaking character.
                check = maxWidth;
            }
            else
            {
                // Extract the first message.
                Game.GameMessage.StringValue = message.Substring(0, check);

                // Remove the first message.
                message = message.Substring(check + 1);

                // Render the first message.
                Game.Screen.Print(ColorEnum.White, Game.GameMessage.StringValue, Y, X);

                // Render more prompt to clear for next message.
                ShowMorePrompt();
            }
        }

        Game.GameMessage.StringValue = Game.DelimitIf(Game.GameMessage.StringValue, " ", message);
        Game.Screen.Print(ColorEnum.White, Game.GameMessage.StringValue, Y, X);
    }

    /// <summary>
    /// Paint the widget on the screen.  No checks or resets of the validation status are or should be performed during this method.
    /// </summary>
    protected override void Paint()
    {
        while (Game.GameMessage.MessageQueue.Count > 0)
        {
            string? message = Game.GameMessage.MessageQueue.Dequeue();
            if (message is null)
            {
                // Erases the message line and prepares the next message to be rendered at column 0.
                Game.Screen.PrintLine("", Y, X);
                Game.GameMessage.StringValue = "";
            }
            else if (message == string.Empty)
            {
                ShowMorePrompt();
            }
            else
            {
                Render(message);
            }
        }
    }

    public string ToJson()
    {
        GameMessageWidgetGameConfiguration stringWidgetGameConfiguration = new GameMessageWidgetGameConfiguration()
        {
            Key = Key,
            Color = Color,
            X = X,
            Y = Y,
            Width = Width,
            MorePrompt = MorePrompt,
        };
        return JsonSerializer.Serialize(stringWidgetGameConfiguration, Game.GetJsonSerializerOptions());
    }
}
