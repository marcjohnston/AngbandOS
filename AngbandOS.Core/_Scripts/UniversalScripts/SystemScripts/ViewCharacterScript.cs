// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class ViewCharacterScript : UniversalScript, IGetKey
{
    private ViewCharacterScript(Game game) : base(game) { }

    /// <summary>
    /// Returns the entity serialized into a Json string.  Returns an empty string by default.
    /// </summary>
    /// <returns></returns>

    public virtual string Key => GetType().Name;

    public string GetKey => Key;
    public void Bind() { }

    public override bool RequiresRerendering => true;

    /// <summary>
    /// Renders details about character.
    /// </summary>
    /// <returns></returns>
    public override void ExecuteScript()
    {
        // Save the current screen
        Game.FullScreenOverlay = true;
        ScreenBuffer savedScreen = Game.Screen.Clone();
        Game.SetBackground(BackgroundImageEnum.Paper);
        // Load the character viewer
        while (!Game.Shutdown)
        {
            RenderCharacterScript showCharacterSheet = (RenderCharacterScript)Game.SingletonRepository.Get<IScript>(nameof(RenderCharacterScript));
            showCharacterSheet.ExecuteScript();
            Game.Screen.Print(ColorEnum.Orange, "[Press 'c' to change name, or ESC]", 43, 23);
            char keyPress = Game.Inkey();
            // Escape breaks us out of the loop
            if (keyPress == '\x1b')
            {
                break;
            }
            // 'c' changes name
            if (keyPress == 'c' || keyPress == 'C')
            {
                Game.InputPlayerName();
            }
            Game.MsgPrint(string.Empty);
        }
        // Restore the screen
        Game.SetBackground(BackgroundImageEnum.Overhead);
        Game.Screen.Restore(savedScreen);
        Game.FullScreenOverlay = false;
        Game.RefreshMap.SetChangedFlag(); // TODO: Needs to convert to dependencies in the MapWidget
        Game.SingletonRepository.Get<FlaggedAction>(nameof(RedrawEquippyFlaggedAction)).Set();
        Game.SingletonRepository.Get<FlaggedAction>(nameof(PrExtraRedrawActionGroupSetFlaggedAction)).Set();
        Game.SingletonRepository.Get<FlaggedAction>(nameof(PrBasicRedrawActionGroupSetFlaggedAction)).Set();

        // Invalidate the main screen.
        Game.ConsoleView.Invalidate();

        Game.HandleStuff();
    }
}
