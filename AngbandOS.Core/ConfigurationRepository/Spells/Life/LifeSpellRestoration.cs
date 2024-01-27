// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Life;

[Serializable]
internal class LifeSpellRestoration : Spell
{
    private LifeSpellRestoration(SaveGame saveGame) : base(saveGame) { }
    public override void Cast()
    {
        SaveGame.TryRestoringAbilityScore(Ability.Strength);
        SaveGame.TryRestoringAbilityScore(Ability.Intelligence);
        SaveGame.TryRestoringAbilityScore(Ability.Wisdom);
        SaveGame.TryRestoringAbilityScore(Ability.Dexterity);
        SaveGame.TryRestoringAbilityScore(Ability.Constitution);
        SaveGame.TryRestoringAbilityScore(Ability.Charisma);
        SaveGame.RunScript(nameof(RestoreLevelScript));
    }

    public override string Name => "Restoration";
    
}