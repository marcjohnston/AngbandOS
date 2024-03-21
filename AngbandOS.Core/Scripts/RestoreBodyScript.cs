// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Scripts;

[Serializable]
internal class RestoreBodyScript : Script, IScript
{
    private RestoreBodyScript(Game game) : base(game) { }

    /// <summary>
    /// Restores the ability score for strength, intelligence, wisdon, dexterity, constitution and charisma.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        Game.TryRestoringAbilityScore(Ability.Strength);
        Game.TryRestoringAbilityScore(Ability.Intelligence);
        Game.TryRestoringAbilityScore(Ability.Wisdom);
        Game.TryRestoringAbilityScore(Ability.Dexterity);
        Game.TryRestoringAbilityScore(Ability.Constitution);
        Game.TryRestoringAbilityScore(Ability.Charisma);
    }
}
