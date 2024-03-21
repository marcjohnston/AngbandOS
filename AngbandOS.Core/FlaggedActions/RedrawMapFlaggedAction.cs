// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.FlaggedActions;

[Serializable]
internal class RedrawMapFlaggedAction : FlaggedAction
{
    private RedrawMapFlaggedAction(Game game) : base(game) { }
    protected override void Execute()
    {
        // Save the cursor visible state, we will temporarily reset it.
        bool v = Game.Screen.CursorVisible;

        // Turn off the cursor visible.
        Game.Screen.CursorVisible = false; // TODO: Is this really needed, if we have a double-buffer?
        for (int y = Game.PanelRowMin; y <= Game.PanelRowMax; y++)
        {
            for (int x = Game.PanelColMin; x <= Game.PanelColMax; x++)
            {
                Game.MapInfo(y, x, out ColorEnum a, out char c);
                if (Game.InvulnerabilityTimer.Value != 0)
                {
                    a = ColorEnum.White;
                }
                else if (Game.EtherealnessTimer.Value != 0)
                {
                    a = ColorEnum.Black;
                }
                Game.Screen.Print(a, c, y - Game.PanelRowPrt, x - Game.PanelColPrt);
            }
        }
        Game.RedrawSingleLocation(Game.MapY, Game.MapX);

        // Restore the cursor visible.
        Game.Screen.CursorVisible = v;
    }
}
