// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class DetectionScript : Script, IScript, ICastSpellScript, IEatOrQuaffScript, IActivateItemScript
{
    private DetectionScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Detects traps, doors, stairs, treasures, gold, normal objects, normal monsters and invisible monsters and returns true, if anything was detected; false, otherwise.
    /// </summary>
    /// <returns></returns>
    public IdentifiedResult ExecuteEatOrQuaffScript()
    {
        bool isIdentified = Game.DetectTraps();
        isIdentified |= Game.DetectDoors();
        isIdentified |= Game.DetectStairs();
        isIdentified |= Game.DetectTreasure();
        isIdentified |= Game.DetectGold();
        isIdentified |= Game.RunIdentifiedScript(nameof(DetectNormalObjectsScript));
        isIdentified |= Game.DetectInvisibleMonsters();
        isIdentified |= Game.RunIdentifiedScript(nameof(DetectNormalMonstersScript));
        return new IdentifiedResult(isIdentified);
    }

    /// <summary>
    /// Executes the successful script and disposes of the result.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        ExecuteEatOrQuaffScript();
    }

    public UsedResult ExecuteActivateItemScript(Item item)
    {
        Game.MsgPrint("An image forms in your mind...");
        ExecuteEatOrQuaffScript();
        return new UsedResult(true);
    }
    public string LearnedDetails => "";
}
