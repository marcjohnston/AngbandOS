// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Scripts;

[Serializable]
internal class RestoreLevelScript : Script, IScript, ICastSpellScript, IEatOrQuaffScript, IActivateItemScript
{
    private RestoreLevelScript(Game game) : base(game) { }

    public void ExecuteCastSpellScript(Spell spell)
    {
        ExecuteScript();
    }

    /// <summary>
    /// Executes the script and returns the success value as whether or not the action was noticed.
    /// </summary>
    /// <returns></returns>
    public IdentifiedResultEnum ExecuteEatOrQuaffScript()
    {
        // Restore life levels restores any lost experience
        if (Game.ExperiencePoints.IntValue < Game.MaxExperienceGained.IntValue)
        {
            Game.MsgPrint("You feel your life energies returning.");
            Game.ExperiencePoints.IntValue = Game.MaxExperienceGained.IntValue;
            Game.CheckExperience();
            return IdentifiedResultEnum.True;
        }
        return IdentifiedResultEnum.False;
    }

    /// <summary>
    /// Executes the successful script and disposes of the result.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        ExecuteEatOrQuaffScript();
    }

    public UsedResultEnum ExecuteActivateItemScript(Item item)
    {
        ExecuteScript();
        return UsedResultEnum.True;
    }
    public string LearnedDetails => "";
}
