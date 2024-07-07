// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class SpecialEnlightenmentScript : Script, INoticeableScript
{
    private SpecialEnlightenmentScript(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns true because the action is always noticed.
    /// </summary>
    /// <returns></returns>
    public bool ExecuteNoticeableScript()
    {
        // *Enlightenment* shows you the whole level, increases your intelligence and
        // wisdom, identifies all your items, and detects everything
        Game.MsgPrint("You begin to feel more enlightened...");
        Game.MsgPrint(null);
        Game.RunScript(nameof(LightScript));
        Game.TryIncreasingAbilityScore(Ability.Intelligence);
        Game.TryIncreasingAbilityScore(Ability.Wisdom);
        Game.DetectTraps();
        Game.DetectDoors();
        Game.DetectStairs();
        Game.DetectTreasure();
        Game.DetectObjectsGold();
        Game.RunScript(nameof(DetectNormalObjectsScript));
        Game.RunScript(nameof(IdentifyAllItemsScript));
        Game.RunScript(nameof(SelfKnowledgeScript));
        return true;
    }
}