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
    private RestoreBodyScript(SaveGame saveGame) : base(saveGame) { }

    /// <summary>
    /// Restores the ability score for strength, intelligence, wisdon, dexterity, constitution and charisma.
    /// </summary>
    /// <returns></returns>
    public void ExecuteScript()
    {
        SaveGame.TryRestoringAbilityScore(Ability.Strength);
        SaveGame.TryRestoringAbilityScore(Ability.Intelligence);
        SaveGame.TryRestoringAbilityScore(Ability.Wisdom);
        SaveGame.TryRestoringAbilityScore(Ability.Dexterity);
        SaveGame.TryRestoringAbilityScore(Ability.Constitution);
        SaveGame.TryRestoringAbilityScore(Ability.Charisma);
    }
}
