// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class EnterStoreScript : Script, IScript, ICastSpellScript, IGameCommandScript
{
    private EnterStoreScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Returns information about the script, or blank if there is no detailed information.  Returns blank, by default.
    /// </summary>
    public string LearnedDetails => "";

    /// <summary>
    /// Executes the enter store script and returns false.
    /// </summary>
    /// <returns></returns>
    public RepeatableResult ExecuteGameCommandScript()
    {
        ExecuteScript();
        return new RepeatableResult(false);
    }

    /// <summary>
    /// Executes the enter store script.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        GridTile tile = Game.Map.Grid[Game.MapY.IntValue][Game.MapX.IntValue];
        // Make sure we're actually on a shop tile
        if (!tile.FeatureType.IsShop)
        {
            Game.MsgPrint("You see no Stores here.");
            return;
        }
        Store which = Game.GetWhichStore();
        // We can't enter a house unless we own it
        if (which.DoorsLocked())
        {
            Game.MsgPrint("The door is locked.");
            return;
        }
        // Switch from the normal game interface to the store interface
        Game.SingletonRepository.Get<FlaggedAction>(nameof(RemoveLightFlaggedAction)).Check(true);
        Game.SingletonRepository.Get<FlaggedAction>(nameof(RemoveViewFlaggedAction)).Check(true);
        Game.FullScreenOverlay = true;
        Game.CommandArgument = 0;
        which.EnterStore();
    }
}
