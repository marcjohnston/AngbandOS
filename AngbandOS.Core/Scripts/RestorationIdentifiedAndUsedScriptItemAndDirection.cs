// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class RestorationIdentifiedAndUsedScriptItemAndDirection : Script, IIdentifiedAndUsedScriptItemDirection
{
    private RestorationIdentifiedAndUsedScriptItemAndDirection(Game game) : base(game) { }

    /// <summary>
    /// Executes the script and returns false.
    /// </summary>
    /// <returns></returns>
    public (bool identified, bool used) ExecuteIdentifiedAndUsedScriptItemDirection(Item item, int dir)
    {
        bool identified = false;
        if (Game.RunSuccessfulScript(nameof(RestoreLevelScript)))
        {
            identified = true;
        }
        if (Game.TryRestoringAbilityScore(Ability.Strength))
        {
            identified = true;
        }
        if (Game.TryRestoringAbilityScore(Ability.Intelligence))
        {
            identified = true;
        }
        if (Game.TryRestoringAbilityScore(Ability.Wisdom))
        {
            identified = true;
        }
        if (Game.TryRestoringAbilityScore(Ability.Dexterity))
        {
            identified = true;
        }
        if (Game.TryRestoringAbilityScore(Ability.Constitution))
        {
            identified = true;
        }
        if (Game.TryRestoringAbilityScore(Ability.Charisma))
        {
            identified = true;
        }
        return (identified, true);
    }
}
