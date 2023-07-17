// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class MessagesScript : Script
{
    private MessagesScript(SaveGame saveGame) : base(saveGame) { }

    public override bool Execute()
    {
        int messageNumber = SaveGame.MessageNum();
        int index = 0;
        int horizontalOffset = 0;
        SaveGame.FullScreenOverlay = true;
        ScreenBuffer savedScreen = SaveGame.Screen.Clone();
        SaveGame.SetBackground(BackgroundImageEnum.Normal);
        // Infinite loop showing a page of messages from the index
        while (!SaveGame.Shutdown)
        {
            // Clear the screen
            SaveGame.Screen.Clear();

            // Print the messages
            int row;
            for (row = 0; row < 40 && index + row < messageNumber; row++)
            {
                string msg = SaveGame.GetMessageText((short)(index + row));
                msg = msg.Length >= horizontalOffset ? msg.Substring(horizontalOffset) : "";
                SaveGame.Screen.Print(ColourEnum.White, msg, 41 - row, 0);
            }

            // Get a command
            SaveGame.Screen.PrintLine($"Message Recall ({index}-{index + row - 1} of {messageNumber}), Offset {horizontalOffset}", 0, 0);
            SaveGame.Screen.PrintLine("[Press 'p' for older, 'n' for newer, <dir> to scroll, or ESCAPE]", 43, 0);
            int keyCode = SaveGame.Inkey();
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
        SaveGame.Screen.Restore(savedScreen);
        SaveGame.FullScreenOverlay = false;
        return false;
    }
}
