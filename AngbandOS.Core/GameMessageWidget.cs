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
    public GameMessageWidget(Game game, StringWidgetGameConfiguration stringWidgetGameConfiguration) : base(game)
    {
        Key = stringWidgetGameConfiguration.Key ?? stringWidgetGameConfiguration.GetType().Name;
        Color = stringWidgetGameConfiguration.Color;
        X = stringWidgetGameConfiguration.X;
        Y = stringWidgetGameConfiguration.Y;
        Width = stringWidgetGameConfiguration.Width;
    }

    /// <summary>
    /// Returns the name of the property that participates in change tracking.  This property is used to bind the <see cref="ChangeTrackers"/> property during the bind phase.
    /// </summary>
    public string[]? ChangeTrackerNames { get; } = null;

    public string Key { get; }

    public string GetKey => Key;

    public void Bind() { }

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

    private void MsgPrint(string?[] messages)
    {
        const string MorePrompt = "-more-";

        /// <summary>
        /// Renders the -more- prompt and waits for a key input.  Keys in the input buffer are preserved.
        /// </summary>
        /// <param name="cursorXPosition"></param>
        void ShowMorePrompt()
        {
            if (GameMessage.StringValue.Length > 0)
            {
                Game.Screen.Print(ColorEnum.BrightBlue, MorePrompt, 0, GameMessage.StringValue.Length + 1);
                while (!Shutdown)
                {
                    string save = _artificialKeyBuffer;
                    _artificialKeyBuffer = "";
                    Inkey();
                    _artificialKeyBuffer = save;
                    break;
                }
            }
            Game.Screen.Erase(0, 0);
            GameMessage.StringValue = "";
        }

        void Render(string message)
        {
            // Capitalize the first letter.
            if (message.Length > 2)
            {
                message = message.Substring(0, 1).ToUpper() + message.Substring(1);
            }
            if (!Game.IsDead)
            {
                MessageAdd(message);
            }

            // Check to see if the message being rendered is longer than one screen width.  If so, it will need to be split.  Compute the amount of space available.
            int lengthOfMore = MorePrompt.Length;
            int maxWidth = Screen.Width - lengthOfMore - 1;

            // Check to see if we need to -more- the current line.  Any form of the current message exceeding the current line will force a -more-.
            if (GameMessage.StringValue.Length + message.Length + 1 > maxWidth)
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
                    GameMessage.StringValue = message.Substring(0, check);

                    // Remove the first message.
                    message = message.Substring(check + 1);

                    // Render the first message.
                    Game.Screen.Print(ColorEnum.White, GameMessage.StringValue, 0, 0);

                    // Render more prompt to clear for next message.
                    ShowMorePrompt();
                }
            }

            GameMessage.StringValue = Game.DelimitIf(GameMessage.StringValue, " ", message);
            Game.Screen.Print(ColorEnum.White, GameMessage.StringValue, 0, 0);
        }

        // Allow the parameters to specify NULL as a single null string.
        if (messages is null)
        {
            messages = new string?[] { null };
        }

        foreach (string? message in messages)
        {
            if (message is null)
            {
                // Erases the message line and prepares the next message to be rendered at column 0.
                Game.Screen.PrintLine("", 0, 0);
                GameMessage.StringValue = "";
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
    /// <summary>
    /// Paint the widget on the screen.  No checks or resets of the validation status are or should be performed during this method.
    /// </summary>
    protected override void Paint()
    {
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
        };
        return JsonSerializer.Serialize(stringWidgetGameConfiguration, Game.GetJsonSerializerOptions());
    }
}
