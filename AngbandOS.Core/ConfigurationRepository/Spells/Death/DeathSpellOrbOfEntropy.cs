// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Spells.Death;

[Serializable]
internal class DeathSpellOrbOfEntropy : Spell
{
    private DeathSpellOrbOfEntropy(SaveGame saveGame) : base(saveGame) { }
    protected override string? CastScriptName => nameof(OrbOfEntropyScript);

    protected override string? CastFailedScriptName => nameof(WildDeathMagicScript);

    public override string Name => "Orb of Entropy";

    protected override string LearnedDetails
    {
        get
        {
            int s = SaveGame.ExperienceLevel + (SaveGame.ExperienceLevel / (SaveGame.BaseCharacterClass.ID == CharacterClass.Mage || SaveGame.BaseCharacterClass.ID == CharacterClass.HighMage ? 2 : 4));
            return $"dam 3d6+{s}";
        }
    }
}