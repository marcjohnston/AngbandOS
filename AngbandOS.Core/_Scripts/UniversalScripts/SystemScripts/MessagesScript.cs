﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class MessagesScript : UniversalScript, IGetKey
{
    private MessagesScript(Game game) : base(game) { }

    /// <summary>
    /// Returns the entity serialized into a Json string.  Returns an empty string by default.
    /// </summary>
    /// <returns></returns>

    public virtual string Key => GetType().Name;

    public string GetKey => Key;
    public void Bind() { }

    /// <summary>
    /// Executes the messages script.
    /// </summary>
    /// <returns></returns>
    public override void ExecuteScript()
    {
        int messageNumber = Game.MessageNum();
        int index = 0;
        int horizontalOffset = 0;
        Game.FullScreenOverlay = true;
        ScreenBuffer savedScreen = Game.Screen.Clone();
        Game.SetBackground(BackgroundImageEnum.Normal);
        // Infinite loop showing a page of messages from the index
        while (!Game.Shutdown)
        {
            // Clear the screen
            Game.Screen.Clear();

            // Print the messages
            int row;
            for (row = 0; row < 40 && index + row < messageNumber; row++)
            {
                string msg = Game.GetMessageText((short)(index + row));
                msg = msg.Length >= horizontalOffset ? msg.Substring(horizontalOffset) : "";
                Game.Screen.Print(ColorEnum.White, msg, 41 - row, 0);
            }

            // Get a command
            Game.Screen.PrintLine($"Message Recall ({index}-{index + row - 1} of {messageNumber}), Offset {horizontalOffset}", 0, 0);
            Game.Screen.PrintLine("[Press 'p' for older, 'n' for newer, <dir> to scroll, or ESCAPE]", 43, 0);
            int keyCode = Game.Inkey();
            if (keyCode == '\x1b')
            {
                // Break out of the infinite loop
                break;
            }
            if (keyCode == '4')
            {
                horizontalOffset = horizontalOffset >= 40 ? horizontalOffset - 40 : 0;
                continue;
            }
            if (keyCode == '6')
            {
                horizontalOffset += 40;
                continue;
            }
            if (keyCode == '8' || keyCode == '\n' || keyCode == '\r')
            {
                if (index + 1 < messageNumber)
                {
                    index++;
                }
            }
            if (keyCode == 'p' || keyCode == ' ')
            {
                if (index + 40 < messageNumber)
                {
                    index += 40;
                }
            }
            if (keyCode == 'n')
            {
                index = index >= 40 ? index - 40 : 0;
            }
            if (keyCode == '2')
            {
                index = index >= 1 ? index - 1 : 0;
            }
        }
        // Tidy up after ourselves
        Game.Screen.Restore(savedScreen);
        Game.FullScreenOverlay = false;
    }
}
