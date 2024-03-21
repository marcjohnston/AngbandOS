// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class RedrawScript : Script, IScript
{
    private RedrawScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        Game.Screen.Clear();
        Game.SingletonRepository.FlaggedActions.Get(nameof(UpdateTorchRadiusFlaggedAction)).Set();
        Game.SingletonRepository.FlaggedActions.Get(nameof(UpdateHealthFlaggedAction)).Set();
        Game.SingletonRepository.FlaggedActions.Get(nameof(UpdateManaFlaggedAction)).Set();
        Game.SingletonRepository.FlaggedActions.Get(nameof(UpdateSpellsFlaggedAction)).Set();
        Game.SingletonRepository.FlaggedActions.Get(nameof(UpdateBonusesFlaggedAction)).Set();
        Game.SingletonRepository.FlaggedActions.Get(nameof(RemoveLightFlaggedAction)).Set();
        Game.SingletonRepository.FlaggedActions.Get(nameof(RemoveViewFlaggedAction)).Set();
        Game.SingletonRepository.FlaggedActions.Get(nameof(UpdateLightFlaggedAction)).Set();
        Game.SingletonRepository.FlaggedActions.Get(nameof(UpdateViewFlaggedAction)).Set();
        Game.SingletonRepository.FlaggedActions.Get(nameof(UpdateMonstersFlaggedAction)).Set();
        Game.SingletonRepository.FlaggedActions.Get(nameof(RedrawMapFlaggedAction)).Set();
        Game.SingletonRepository.FlaggedActions.Get(nameof(RedrawEquippyFlaggedAction)).Set();
        Game.SingletonRepository.FlaggedActions.Get(nameof(PrExtraRedrawActionGroupSetFlaggedAction)).Set();
        Game.SingletonRepository.FlaggedActions.Get(nameof(NoticeCombineAndReorderGroupSetFlaggedAction)).Set();
        Game.SingletonRepository.FlaggedActions.Get(nameof(PrBasicRedrawActionGroupSetFlaggedAction)).Set();

        // Invalidate the main form.  This will force all of the widgets to redraw.
        Game.MainForm.Invalidate();

        Game.HandleStuff();
        Game.UpdateScreen();
    }
}
